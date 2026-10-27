using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
namespace TutAcadSupport {
internal static class Rules {
 public static void Require(bool value,string message){if(!value)throw new InvalidOperationException(message);}
 public static void Text(string value,string name,int max){Require(!String.IsNullOrWhiteSpace(value),name+" is required.");Require(value.Trim().Length<=max,name+" is too long.");}
 public const int MinimumRegistrationAge=17;
 public static void BirthDate(DateTime birth,DateTime today){
  Require(birth.Date>=new DateTime(1900,1,1) && birth.Date<=today.Date,"Enter a valid date of birth.");
  Require(birth.Date<=today.Date.AddYears(-MinimumRegistrationAge),"You must be at least 17 years old to register.");
 }
 public static void PersonName(string value,string name){Text(value,name,50);Require(Regex.IsMatch(value.Trim(),@"^[\p{L}\p{M} .'’-]+$") && Regex.IsMatch(value,@"\p{L}"),name+" must contain letters, with spaces, apostrophes, hyphens or full stops only.");}
 public static void Contact(string value){
  Text(value,"Contact",100);value=value.Trim();
  if(value.Contains("@")){
   try{var address=new MailAddress(value);Require(address.Address==value && address.Host.Contains(".") && !address.Host.EndsWith("."),"Enter a valid email address.");}
   catch{throw new InvalidOperationException("Enter a valid email address.");}
  }else{
   string digits=Regex.Replace(value,@"[^0-9]","");
   Require(Regex.IsMatch(value,@"^\+?[0-9 ()-]+$") && digits.Length>=10 && digits.Length<=15,"Enter a phone number containing 10 to 15 digits, or a valid email address.");
  }
 }
 public static void Period(DateTime start,DateTime end,DateTime now){Require(start>now,"Choose a future time.");Require(end>start && start.Date==end.Date,"End time must follow start time on the same day.");}
 public static bool Overlaps(DateTime a,DateTime b,DateTime c,DateTime d){return a<d && b>c;}
 public static void ChangeAllowed(string status,DateTime start,DateTime now){Require(status=="Scheduled","Only scheduled bookings can be changed or cancelled.");Require(start>=now.AddHours(48),"Changes and cancellations require at least 48 hours' notice.");}
 public static void Password(string value){Require(!String.IsNullOrWhiteSpace(value) && value.Length>=8 && value.Length<=128,"Use a password of 8 to 128 characters.");}
 public static string[] Hash(string password){byte[] salt=new byte[16];using(var rng=RandomNumberGenerator.Create())rng.GetBytes(salt);return new[]{Convert.ToBase64String(salt),Derive(password,salt)};}
 public static string Derive(string password,byte[] salt){using(var k=new Rfc2898DeriveBytes(password,salt,150000,HashAlgorithmName.SHA256))return Convert.ToBase64String(k.GetBytes(32));}
 public static bool Verify(string password,string salt,string hash){byte[] expected=Convert.FromBase64String(hash),actual=Convert.FromBase64String(Derive(password,Convert.FromBase64String(salt)));int diff=expected.Length^actual.Length;for(int i=0;i<Math.Min(expected.Length,actual.Length);i++)diff|=expected[i]^actual[i];return diff==0;}
}
}
