using System;
using TutAcadSupport;
internal static class RulesTests {
 static int count;
 static void Pass(string label,Action action){action();count++;Console.WriteLine("PASS "+label);}
 static void Reject(string label,Action action){try{action();}catch(InvalidOperationException){count++;Console.WriteLine("PASS "+label);return;}throw new Exception("Expected rejection: "+label);}
 static void Check(bool value){if(!value)throw new Exception("Assertion failed");}
 static int Main(){try{
 var today=new DateTime(2026,10,26);
 Reject("one year old",()=>Rules.BirthDate(today.AddYears(-1),today));
 Reject("16 years old",()=>Rules.BirthDate(today.AddYears(-16),today));
 Reject("17th birthday tomorrow",()=>Rules.BirthDate(today.AddYears(-17).AddDays(1),today));
 Pass("17th birthday today",()=>Rules.BirthDate(today.AddYears(-17),today));
 Pass("17th birthday yesterday",()=>Rules.BirthDate(today.AddYears(-17).AddDays(-1),today));
 Pass("adult",()=>Rules.BirthDate(today.AddYears(-35),today));
 Reject("future birth",()=>Rules.BirthDate(today.AddDays(1),today));
 Reject("before supported date range",()=>Rules.BirthDate(new DateTime(1899,12,31),today));
 Reject("leap-day birthday before 17 years",()=>Rules.BirthDate(new DateTime(2008,2,29),new DateTime(2025,2,28)));
 Pass("leap-day birthday after 17 years",()=>Rules.BirthDate(new DateTime(2008,2,29),new DateTime(2025,3,1)));
 foreach(string name in new[]{"Bongani","O'Connor","Anne-Marie","José","李","D’Angelo"})Pass("valid name "+name,()=>Rules.PersonName(name,"Name"));
 foreach(string name in new[]{"12345","---"," ","Name123"})Reject("invalid name",()=>Rules.PersonName(name,"Name"));
 foreach(string contact in new[]{"0712345678","+27 71 234 5678","(011) 123-4567","student@example.co.za"})Pass("valid contact",()=>Rules.Contact(contact));
 foreach(string contact in new[]{"----------","() () () ()","12345","1234567890123456","abc@example","abc@","Name <abc@example.com>"})Reject("invalid contact",()=>Rules.Contact(contact));
 Reject("blank password",()=>Rules.Password("        "));
 Pass("valid password",()=>Rules.Password("Student123!"));
 Pass("password hashing unchanged",()=>{var h=Rules.Hash("Student123!");Check(Rules.Verify("Student123!",h[0],h[1]));Check(!Rules.Verify("wrong",h[0],h[1]));});
 var start=today.AddDays(3).AddHours(10);var end=start.AddHours(1);
 Pass("future session",()=>Rules.Period(start,end,today));
 Reject("past session",()=>Rules.Period(today.AddHours(-2),today.AddHours(-1),today));
 Reject("zero-length session",()=>Rules.Period(start,start,today));
 Reject("reverse session",()=>Rules.Period(end,start,today));
 Reject("overnight session",()=>Rules.Period(start,start.AddDays(1),today));
 Pass("adjacent sessions do not clash",()=>Check(!Rules.Overlaps(start,end,end,end.AddHours(1))));
 Pass("overlap detected",()=>Check(Rules.Overlaps(start,end,start.AddMinutes(30),end.AddHours(1))));
 Pass("exactly 48-hour notice",()=>Rules.ChangeAllowed("Scheduled",today.AddHours(48),today));
 Reject("less than 48-hour notice",()=>Rules.ChangeAllowed("Scheduled",today.AddHours(48).AddSeconds(-1),today));
 Reject("completed cannot change",()=>Rules.ChangeAllowed("Completed",start,today));
 Console.WriteLine(count+" checks passed.");return 0;
 }catch(Exception e){Console.Error.WriteLine(e);return 1;}}
}
