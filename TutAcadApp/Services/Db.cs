using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
namespace TutAcadSupport {
internal static class Db {
 public static string Root { get { var d=new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory); while(d!=null){if(File.Exists(Path.Combine(d.FullName,"IS-project-root.txt")))return d.FullName;d=d.Parent;}throw new IOException("Extract the entire IS project folder. Keep Database, TutAcadApp and IS-project-root.txt together."); } }
 public static string FileName { get {return Path.Combine(Root,"Database","TutAcadSupport.accdb");} }
 public static string Provider="";
 public static string ConnectionString {get { var b=new OleDbConnectionStringBuilder();b.Provider=Provider;b.DataSource=FileName;b.PersistSecurityInfo=false;return b.ConnectionString;}}
 public static string Detect() {
  if(!File.Exists(FileName))throw new IOException("Database not found: "+FileName);
  var errors=new StringBuilder();
  foreach(string p in new[]{"Microsoft.ACE.OLEDB.16.0","Microsoft.ACE.OLEDB.12.0"}) {
   Provider=p;
   try {using(var c=Open()){}return p;}catch(Exception ex){errors.AppendLine(p+": "+ex.Message);}
  }
  Provider="";throw new InvalidOperationException("Cannot open Access in this "+(Environment.Is64BitProcess?"64":"32")+"-bit process.\r\n"+errors);
 }
 public static OleDbConnection Open(){var c=new OleDbConnection(ConnectionString);try{c.Open();return c;}catch{c.Dispose();throw;}}
 public static OleDbCommand Command(OleDbConnection c,OleDbTransaction t,string sql,params object[] args){
  var cmd=new OleDbCommand(sql,c,t);foreach(var v in args){var p=new OleDbParameter();
   if(v is DateTime)p.OleDbType=OleDbType.Date;else if(v is int)p.OleDbType=OleDbType.Integer;else if(v is bool)p.OleDbType=OleDbType.Boolean;else if(v is double)p.OleDbType=OleDbType.Double;
   else {p.OleDbType=OleDbType.VarWChar;p.Size=255;}p.Value=v??DBNull.Value;cmd.Parameters.Add(p);}return cmd;
 }
 public static DataTable Query(string sql,params object[] args){using(var c=Open())return Query(c,null,sql,args);}
 public static DataTable Query(OleDbConnection c,OleDbTransaction t,string sql,params object[] args){using(var cmd=Command(c,t,sql,args))using(var a=new OleDbDataAdapter(cmd)){var d=new DataTable();a.Fill(d);return d;}}
 public static int Exec(OleDbConnection c,OleDbTransaction t,string sql,params object[] args){using(var cmd=Command(c,t,sql,args))return cmd.ExecuteNonQuery();}
 public static void Exec(string sql,params object[] args){using(var c=Open())Exec(c,null,sql,args);}
 public static string Id(string prefix,int length=12){return prefix+Guid.NewGuid().ToString("N").Substring(0,length-prefix.Length).ToUpperInvariant();}
 public static void Log(Exception ex){try{File.AppendAllText(Path.Combine(Root,"application-errors.log"),DateTime.Now.ToString("s")+" "+ex+Environment.NewLine);}catch{}}
}
}
