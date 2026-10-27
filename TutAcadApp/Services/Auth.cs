using System;
using System.Data;
namespace TutAcadSupport {
internal static class Auth {
 public static string Role="",PersonID="",Username="",Name="";
 public static void Need(params string[] roles){Rules.Require(Array.IndexOf(roles,Role)>=0,"Sign in with an authorised account to use this function.");}
 public static void Logout(){Role=PersonID=Username=Name="";}
 public static void Login(string username,string password){
  Rules.Text(username,"Username",50);Rules.Require(!String.IsNullOrEmpty(password),"Enter your password.");
  var d=Db.Query("SELECT * FROM AppUser WHERE Username=? AND IsActive=?",username.Trim(),true);
  Rules.Require(d.Rows.Count==1 && Rules.Verify(password,d.Rows[0]["PasswordSalt"].ToString(),d.Rows[0]["PasswordHash"].ToString()),"Incorrect username or password.");
  var r=d.Rows[0];string role=r["UserRole"].ToString(),id=r["PersonID"].ToString();
  Rules.Require(role=="Student"||role=="Tutor"||role=="Administrator","Account role is invalid. Contact your administrator.");
  string table=role=="Student"?"Student":role=="Tutor"?"Tutor":"Administrator",key=role=="Student"?"StudentNumber":role=="Tutor"?"TutorID":"AdminID";
  var person=Db.Query("SELECT FirstName,LastName FROM "+table+" WHERE "+key+"=?",id);Rules.Require(person.Rows.Count==1,"Account profile not found. Contact your administrator.");
  Role=role;PersonID=id;Username=username.Trim();Name=person.Rows[0][0]+" "+person.Rows[0][1];
 }
 static readonly System.Collections.Generic.Dictionary<string,string[]> Catalogue=new System.Collections.Generic.Dictionary<string,string[]>{
  {"Science",new[]{"BSc Biological Sciences","BSc Chemistry","BSc Computer Science","BSc Mathematics","BSc Physics","BSc Statistics"}},
  {"Commerce",new[]{"BCom Accounting","BCom Economics","BCom Finance","BCom Information Systems","BCom Marketing","BCom Management"}},
  {"Engineering",new[]{"BEng Chemical Engineering","BEng Civil Engineering","BEng Electrical Engineering","BEng Industrial Engineering","BEng Mechanical Engineering"}}};
 public static string[] Faculties(){var r=new string[Catalogue.Count];Catalogue.Keys.CopyTo(r,0);return r;}
 public static string[] Programmes(string faculty){string[] p;return faculty!=null&&Catalogue.TryGetValue(faculty,out p)?p:new string[0];}
 public static void Register(string number,string first,string last,string contact,string faculty,string programme,DateTime birth,string password){
  Rules.Require(System.Text.RegularExpressions.Regex.IsMatch(number??"",@"\A[0-9]{7,10}\z"),"Student number must contain 7 to 10 digits.");Rules.PersonName(first,"First name");Rules.PersonName(last,"Last name");Rules.Contact(contact);Rules.Require(Array.IndexOf(Programmes(faculty),programme)>=0,"Select a faculty and a programme offered in that faculty.");Rules.Password(password);Rules.BirthDate(birth,DateTime.Today);
  var hash=Rules.Hash(password);
  using(var c=Db.Open())using(var t=c.BeginTransaction()){
   Rules.Require(Db.Query(c,t,"SELECT StudentNumber FROM Student WHERE StudentNumber=?",number).Rows.Count==0,"That student number is already registered.");
   Rules.Require(Db.Query(c,t,"SELECT Username FROM AppUser WHERE Username=?",number).Rows.Count==0,"That username already exists.");
   Db.Exec(c,t,"INSERT INTO Student (StudentNumber,FirstName,LastName,DateOfBirth,ContactInformation,Faculty,ProgrammeOfStudy,AcademicRiskLevel) VALUES (?,?,?,?,?,?,?,?)",number,first.Trim(),last.Trim(),birth.Date,contact.Trim(),faculty.Trim(),programme.Trim(),"Medium");
   Db.Exec(c,t,"INSERT INTO AppUser (Username,PasswordHash,PasswordSalt,UserRole,PersonID,IsActive) VALUES (?,?,?,?,?,?)",number,hash[1],hash[0],"Student",number,true);t.Commit();
  }
 }
 public static void ChangePassword(string oldPassword,string newPassword){Need("Student","Tutor","Administrator");Rules.Password(newPassword);var d=Db.Query("SELECT PasswordSalt,PasswordHash FROM AppUser WHERE Username=?",Username);Rules.Require(d.Rows.Count==1,"Account not found. Sign in again.");Rules.Require(Rules.Verify(oldPassword,d.Rows[0][0].ToString(),d.Rows[0][1].ToString()),"Current password is incorrect.");var h=Rules.Hash(newPassword);Db.Exec("UPDATE AppUser SET PasswordHash=?,PasswordSalt=? WHERE Username=?",h[1],h[0],Username);}
}
}
