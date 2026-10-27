using System;using System.Threading;using System.Windows.Forms;
namespace TutAcadSupport {
internal static class Program {
 [STAThread] static int Main(){
  Application.EnableVisualStyles();Application.SetCompatibleTextRenderingDefault(false);
  bool first;using(var mutex=new Mutex(true,"TutAcadSupport_Group15",out first)){
   if(!first){MessageBox.Show("TutAcadSupport is already open. Switch to its existing window.");return 1;}
   Application.ThreadException+=(s,e)=>{Db.Log(e.Exception);MessageBox.Show("The action could not be completed. Your entries have been kept. Please return to Home and try again.","TutAcadSupport",MessageBoxButtons.OK,MessageBoxIcon.Error);};
   try{Db.Detect();Db.Query("SELECT TOP 1 Username FROM AppUser");Application.Run(new LoginForm());return 0;}
   catch(Exception ex){Db.Log(ex);MessageBox.Show("TutAcadSupport could not connect to its database. Keep the extracted Database and TutAcadApp folders together. This application requires the 64-bit Microsoft Access database provider.\r\n\r\n"+ex.GetBaseException().Message,"Unable to start",MessageBoxButtons.OK,MessageBoxIcon.Error);return 10;}
  }
 }
}}
