using System;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace TutAcadSupport {
internal static class View {
 public static bool Design {get{return LicenseManager.UsageMode==LicenseUsageMode.Designtime;}}
 public static void Run(Action action){try{action();}catch(Exception e){Db.Log(e);MessageBox.Show(e is System.Data.OleDb.OleDbException?"The database could not complete this action. Your entries have been kept. Refresh the page and try again. Details were saved to application-errors.log.":e.GetBaseException().Message,"Please check",MessageBoxButtons.OK,MessageBoxIcon.Warning);}}
 public static void Info(string message){if(ShellForm.Current!=null)ShellForm.Current.SetStatus(message);MessageBox.Show(message,"TutAcadSupport",MessageBoxButtons.OK,MessageBoxIcon.Information);}
 public static bool Confirm(string message){return MessageBox.Show(message,"Please confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes;}
 public static void Bind(ComboBox box,DataTable data,string value,string display){box.DataSource=null;box.ValueMember=value;box.DisplayMember=display;box.DataSource=data;}
 public static string Choice(ComboBox box){Rules.Require(box.SelectedValue!=null,"Please select an option.");return box.SelectedValue.ToString();}
 public static DataRow Row(DataGridView grid){Rules.Require(grid.CurrentRow!=null && grid.CurrentRow.Selected && grid.CurrentRow.DataBoundItem is DataRowView,"Please select a row.");return ((DataRowView)grid.CurrentRow.DataBoundItem).Row;}
 public static string Header(string name){if(name=="SessionID")return "Booking reference";if(name=="RequestID")return "Request reference";return Regex.Replace(Regex.Replace(name,"([a-z])([A-Z])","$1 $2"),"ID$","reference");}
 public static void Grid(DataGridView grid,DataTable data){grid.DataSource=data;grid.ClearSelection();grid.CurrentCell=null;foreach(DataGridViewColumn col in grid.Columns){col.HeaderText=Header(col.Name);if(col.ValueType==typeof(DateTime))col.DefaultCellStyle.Format="dd MMM yyyy HH:mm";col.MinimumWidth=65;}grid.ColumnHeadersDefaultCellStyle.WrapMode=DataGridViewTriState.True;grid.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;}
}
}
