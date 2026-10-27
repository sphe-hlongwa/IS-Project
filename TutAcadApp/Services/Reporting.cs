using System;using System.Data;
namespace TutAcadSupport {
internal static class Reporting {
 public static readonly string[] Names={"Outstanding requests aged 7+ days","Tutor workload by reporting period","Tutor performance and student feedback"};
 public static DataTable Generate(int type,DateTime from,DateTime to,out string heading){Auth.Need("Administrator");Rules.Require(type>=0&&type<3,"Select a report.");from=from.Date;to=to.Date;Rules.Require(type==0||to>=from,"The end date must not be before the start date.");DataTable result;
  if(type==0){result=Db.Query("SELECT r.RequestID,r.StudentNumber,s.FirstName & ' ' & s.LastName AS StudentName,r.CourseCode,c.CourseName,r.SubmissionDate,DateDiff('d',r.SubmissionDate,Date()) AS AgeInDays,r.[Status] FROM (TutoringRequest AS r INNER JOIN Student AS s ON r.StudentNumber=s.StudentNumber) INNER JOIN Course AS c ON r.CourseCode=c.CourseCode WHERE r.[Status]=? AND DateDiff('d',r.SubmissionDate,Date())>=7 ORDER BY r.SubmissionDate","Submitted");}
  else{result=new DataTable();result.Columns.Add("Tutor",typeof(string));result.Columns.Add(type==1?"ScheduledSessions":"CompletedSessions",typeof(int));if(type==1)result.Columns.Add("CompletedSessions",typeof(int));else{result.Columns.Add("AverageRating",typeof(double));result.Columns.Add("PositiveRatings",typeof(int));result.Columns.Add("NegativeRatings",typeof(int));}
   var tutors=School.Tutors();var sessions=Db.Query("SELECT TutorID,AttendanceStatus,Feedback FROM TutoringSession WHERE SessionDate>=? AND SessionDate<?",from,to.AddDays(1));
   foreach(DataRow tutor in tutors.Rows){int total=0,completed=0,positive=0,negative=0,rated=0;double sum=0;foreach(DataRow r in sessions.Rows){if(r["TutorID"].ToString()!=tutor["TutorID"].ToString())continue;string status=r["AttendanceStatus"].ToString();if(status!="Cancelled")total++;if(status=="Completed"){completed++;if(r["Feedback"]!=DBNull.Value){double score=Convert.ToDouble(r["Feedback"]);sum+=score;rated++;if(score>=7)positive++;if(score<=4)negative++;}}}if(type==1)result.Rows.Add(tutor["TutorName"],total,completed);else result.Rows.Add(tutor["TutorName"],completed,rated==0?(object)DBNull.Value:Math.Round(sum/rated,2),positive,negative);}
  }
  string id=Db.Id("RPT");DateTime generated=DateTime.Now;Db.Exec("INSERT INTO Report (ReportID,AdminID,ReportType,GeneratedDate,DateFrom,DateTo) VALUES (?,?,?,?,?,?)",id,Auth.PersonID,Names[type],generated,type==0?(object)DBNull.Value:from,type==0?(object)DBNull.Value:to);
  heading=id+" | "+Auth.Name+" | "+generated.ToString("dd MMM yyyy HH:mm")+"\n"+(type==0?"As at today; calendar age of at least 7 days.":from.ToString("dd MMM yyyy")+" to "+to.ToString("dd MMM yyyy"))+(type==2?" | Ratings: 0-10; positive 7-10, neutral 5-6, negative 0-4.":"");return result;
 }
}
}
