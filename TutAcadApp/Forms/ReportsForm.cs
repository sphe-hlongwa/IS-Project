/*using System;using System.Data;using System.Drawing;using System.Drawing.Printing;using System.IO;using System.Text;using System.Windows.Forms;
namespace TutAcadSupport {
 public partial class ReportsForm:Form {
  private DataTable data;private string title="",details="";private int rowIndex,page;
  public ReportsForm(){InitializeComponent();Ui.Behave(this);preview.Enabled=print.Enabled=export.Enabled=false;reportType.SelectedIndexChanged+=(s,e)=>CriteriaChanged();from.ValueChanged+=(s,e)=>CriteriaChanged();to.ValueChanged+=(s,e)=>CriteriaChanged();}
  private void CriteriaChanged(){from.Enabled=to.Enabled=reportType.SelectedIndex!=0;preview.Enabled=print.Enabled=export.Enabled=false;reportInfo.Text="Criteria changed. Select Generate report to update the results.";}
  private void Form_Load(object s,EventArgs e){if(View.Design)return;View.Run(()=>{Auth.Need("Administrator");reportType.Items.AddRange(Reporting.Names);reportType.SelectedIndex=0;from.Value=DateTime.Today.AddMonths(-1);to.Value=DateTime.Today;});}
  private void generate_Click(object s,EventArgs e){View.Run(()=>{string info;var generated=Reporting.Generate(reportType.SelectedIndex,from.Value,to.Value,out info);data=generated;preview.Enabled=print.Enabled=export.Enabled=true;details=info;title=reportType.Text;View.Grid(results,data);reportInfo.Text=details+" | "+data.Rows.Count+" rows";if(data.Rows.Count==0)View.Info("No records match the selected criteria.");});}
  private void preview_Click(object s,EventArgs e){View.Run(()=>Print(true));}
  private void print_Click(object s,EventArgs e){View.Run(()=>Print(false));}
  private void Print(bool preview){Rules.Require(data!=null,"Generate a report first.");using(var document=new PrintDocument()){document.DocumentName=title;document.DefaultPageSettings.Landscape=true;document.DefaultPageSettings.Margins=new Margins(35,35,40,40);document.BeginPrint+=(s,e)=>{rowIndex=0;page=0;};document.PrintPage+=PrintPage;if(preview){using(var dialog=new PrintPreviewDialog{Document=document,Width=1150,Height=780})dialog.ShowDialog(this);}else using(var dialog=new PrintDialog{Document=document,UseEXDialog=true})if(dialog.ShowDialog(this)==DialogResult.OK)document.Print();}}
  private void PrintPage(object sender,PrintPageEventArgs e){page++;float left=e.MarginBounds.Left,y=e.MarginBounds.Top,w=e.MarginBounds.Width;using(var heading=new Font("Segoe UI",15,FontStyle.Bold))using(var font=new Font("Segoe UI",8))using(var bold=new Font("Segoe UI",8,FontStyle.Bold)){
   e.Graphics.DrawString(title,heading,Brushes.Black,left,y);y+=32;e.Graphics.DrawString(details,font,Brushes.Black,new RectangleF(left,y,w,45));y+=50;float cw=w/data.Columns.Count;
   for(int i=0;i<data.Columns.Count;i++){e.Graphics.FillRectangle(Brushes.LightGray,left+i*cw,y,cw,42);e.Graphics.DrawString(View.Header(data.Columns[i].ColumnName),bold,Brushes.Black,new RectangleF(left+i*cw+3,y+4,cw-6,38));}y+=42;
   if(data.Rows.Count==0)e.Graphics.DrawString("No matching records.",font,Brushes.Black,left,y+10);
   float firstRowY=y;
   Rules.Require(e.MarginBounds.Bottom-25-firstRowY>=28,"The selected paper size is too small. Choose a larger paper size.");
   while(rowIndex<data.Rows.Count){var row=data.Rows[rowIndex];string[] values=new string[data.Columns.Count];float height=28;for(int i=0;i<values.Length;i++){values[i]=row[i] is DateTime?((DateTime)row[i]).ToString("dd MMM yyyy"):Convert.ToString(row[i]);height=Math.Max(height,e.Graphics.MeasureString(values[i],font,(int)cw-6).Height+10);}height=Math.Min(height,e.MarginBounds.Bottom-25-firstRowY);if(y>firstRowY && y+height>e.MarginBounds.Bottom-25){e.HasMorePages=true;return;}for(int i=0;i<values.Length;i++){e.Graphics.DrawRectangle(Pens.LightGray,left+i*cw,y,cw,height);e.Graphics.DrawString(values[i],font,Brushes.Black,new RectangleF(left+i*cw+3,y+4,cw-6,height-6));}y+=height;rowIndex++;}
   e.Graphics.DrawString("Stack Overflowed | Group 15 | Page "+page,font,Brushes.Gray,left,e.MarginBounds.Bottom-18);
  }e.HasMorePages=false;}
  private static string Csv(string value){if(value.Length>0 && "=+-@\t\r".IndexOf(value[0])>=0)value="'"+value;return "\""+value.Replace("\"","\"\"")+"\"";}
  private void export_Click(object s,EventArgs e){View.Run(()=>{Rules.Require(data!=null,"Generate a report first.");using(var dialog=new SaveFileDialog{Filter="CSV file|*.csv",FileName="TutAcadSupport-report.csv"}){if(dialog.ShowDialog(this)!=DialogResult.OK)return;using(var output=new StreamWriter(dialog.FileName,false,new UTF8Encoding(true))){for(int i=0;i<data.Columns.Count;i++){if(i>0)output.Write(',');output.Write(Csv(data.Columns[i].ColumnName));}output.WriteLine();foreach(DataRow row in data.Rows){for(int i=0;i<data.Columns.Count;i++){if(i>0)output.Write(',');output.Write(Csv(Convert.ToString(row[i])));}output.WriteLine();}}View.Info("Report exported.");}});}
 }
}*/
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class ReportsForm : Form
    {
        private DataTable data;
        private string title = "", details = "";
        private int rowIndex, page;

        public ReportsForm()
        {
            InitializeComponent();

            Ui.Behave(this);
            preview.Enabled = false;
            print.Enabled = false;
            export.Enabled = false;

            reportType.SelectedIndexChanged += (s, e) => CriteriaChanged();
            from.ValueChanged += (s, e) => CriteriaChanged();
            to.ValueChanged += (s, e) => CriteriaChanged();
        }

        private void CriteriaChanged()
        {
            from.Enabled = to.Enabled = reportType.SelectedIndex != 0;

            preview.Enabled = false;
            print.Enabled = false;
            export.Enabled = false;

            reportInfo.Text = "Criteria changed. Select Generate report to update the results.";
        }

        private void Form_Load(object s, EventArgs e)
        {
            if (View.Design)
                return;

            try
            {
                Auth.Need("Administrator");

                reportType.Items.AddRange(Reporting.Names);
                reportType.SelectedIndex = 0;

                from.Value = DateTime.Today.AddMonths(-1);
                to.Value = DateTime.Today;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Access denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while opening the reports page.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generate_Click(object s, EventArgs e)
        {
            try
            {
                string info;

                DataTable generated = Reporting.Generate(
                    reportType.SelectedIndex,
                    from.Value,
                    to.Value,
                    out info);

                data = generated;
                details = info;
                title = reportType.Text;

                preview.Enabled = true;
                print.Enabled = true;
                export.Enabled = true;

                results.DataSource = data;
                reportInfo.Text = details + " | " + data.Rows.Count + " rows";

                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("No records match the selected criteria.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to generate report",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while generating the report.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void preview_Click(object s, EventArgs e)
        {
            try
            {
                Print(true);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Print preview",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while preparing the print preview.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void print_Click(object s, EventArgs e)
        {
            try
            {
                Print(false);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while printing the report.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print(bool preview)
        {
            if (data == null)
            {
                MessageBox.Show("Generate a report first.");
                return;
            }

            using (PrintDocument document = new PrintDocument())
            {
                document.DocumentName = title;
                document.DefaultPageSettings.Landscape = true;
                document.DefaultPageSettings.Margins = new Margins(35, 35, 40, 40);

                document.BeginPrint += (s, e) =>
                {
                    rowIndex = 0;
                    page = 0;
                };

                document.PrintPage += PrintPage;

                if (preview)
                {
                    using (PrintPreviewDialog dialog = new PrintPreviewDialog())
                    {
                        dialog.Document = document;
                        dialog.Width = 1150;
                        dialog.Height = 780;
                        dialog.ShowDialog(this);
                    }
                }
                else
                {
                    using (PrintDialog dialog = new PrintDialog())
                    {
                        dialog.Document = document;
                        dialog.UseEXDialog = true;

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            document.Print();
                        }
                    }
                }
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            page++;

            float left = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float w = e.MarginBounds.Width;

            using (Font heading = new Font("Segoe UI", 15, FontStyle.Bold))
            using (Font font = new Font("Segoe UI", 8))
            using (Font bold = new Font("Segoe UI", 8, FontStyle.Bold))
            {
                e.Graphics.DrawString(title, heading, Brushes.Black, left, y);
                y += 32;

                e.Graphics.DrawString(details, font, Brushes.Black,
                    new RectangleF(left, y, w, 45));

                y += 50;

                float cw = w / data.Columns.Count;

                for (int i = 0; i < data.Columns.Count; i++)
                {
                    e.Graphics.FillRectangle(
                        Brushes.LightGray, left + i * cw, y, cw, 42);

                    e.Graphics.DrawString(
                        data.Columns[i].ColumnName,
                        bold,
                        Brushes.Black,
                        new RectangleF(left + i * cw + 3, y + 4, cw - 6, 38));
                }

                y += 42;

                if (data.Rows.Count == 0)
                {
                    e.Graphics.DrawString(
                        "No matching records.", font, Brushes.Black, left, y + 10);
                }

                float firstRowY = y;

                if (e.MarginBounds.Bottom - 25 - firstRowY < 28)
                {
                    throw new InvalidOperationException(
                        "The selected paper size is too small. Choose a larger paper size.");
                }

                while (rowIndex < data.Rows.Count)
                {
                    DataRow row = data.Rows[rowIndex];

                    string[] values = new string[data.Columns.Count];
                    float height = 28;

                    for (int i = 0; i < values.Length; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            values[i] = ((DateTime)row[i]).ToString("dd MMM yyyy");
                        }
                        else
                        {
                            values[i] = Convert.ToString(row[i]);
                        }

                        height = Math.Max(
                            height,
                            e.Graphics.MeasureString(values[i], font, (int)cw - 6).Height + 10);
                    }

                    height = Math.Min(
                        height, e.MarginBounds.Bottom - 25 - firstRowY);

                    if (y > firstRowY && y + height > e.MarginBounds.Bottom - 25)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    for (int i = 0; i < values.Length; i++)
                    {
                        e.Graphics.DrawRectangle(
                            Pens.LightGray, left + i * cw, y, cw, height);

                        e.Graphics.DrawString(
                            values[i],
                            font,
                            Brushes.Black,
                            new RectangleF(left + i * cw + 3, y + 4, cw - 6, height - 6));
                    }

                    y += height;
                    rowIndex++;
                }

                e.Graphics.DrawString(
                    "Stack Overflowed | Group 15 | Page " + page,
                    font,
                    Brushes.Gray,
                    left,
                    e.MarginBounds.Bottom - 18);
            }

            e.HasMorePages = false;
        }

        private static string Csv(string value)
        {
            if (value.Length > 0 && "=+-@\t\r".IndexOf(value[0]) >= 0)
            {
                value = "'" + value;
            }

            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        private void export_Click(object s, EventArgs e)
        {
            if (data == null)
            {
                MessageBox.Show("Generate a report first.");
                return;
            }

            try
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "CSV file|*.csv";
                    dialog.FileName = "TutAcadSupport-report.csv";

                    if (dialog.ShowDialog(this) != DialogResult.OK)
                        return;

                    using (StreamWriter output = new StreamWriter(
                        dialog.FileName, false, new UTF8Encoding(true)))
                    {
                        for (int i = 0; i < data.Columns.Count; i++)
                        {
                            if (i > 0)
                                output.Write(',');

                            output.Write(Csv(data.Columns[i].ColumnName));
                        }

                        output.WriteLine();

                        foreach (DataRow row in data.Rows)
                        {
                            for (int i = 0; i < data.Columns.Count; i++)
                            {
                                if (i > 0)
                                    output.Write(',');

                                output.Write(Csv(Convert.ToString(row[i])));
                            }

                            output.WriteLine();
                        }
                    }

                    MessageBox.Show("Report exported.");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("The report could not be saved. Check that the file is not open elsewhere.\n\n" + ex.Message,
                    "Export error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to save the report in that location.",
                    "Export error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occurred while exporting the report.",
                    "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

