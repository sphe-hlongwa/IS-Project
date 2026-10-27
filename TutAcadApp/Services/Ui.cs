using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace TutAcadSupport {

// ---------------------------------------------------------------------------------------------
// Central theme. Change a colour here and the whole application follows.
// Palette: midnight ink + navy, champagne gold accent, warm ivory canvas.
// ---------------------------------------------------------------------------------------------
internal static class Theme {
 public static readonly Color Ink = Color.FromArgb(13, 23, 42);          // deepest midnight (menu, status, brand panel)
 public static readonly Color Navy = Color.FromArgb(22, 40, 70);         // headings
 public static readonly Color NavyButton = Color.FromArgb(28, 50, 84);   // primary buttons
 public static readonly Color NavyHover = Color.FromArgb(44, 72, 114);   // primary hover
 public static readonly Color Gold = Color.FromArgb(196, 160, 88);       // champagne gold accent
 public static readonly Color GoldDeep = Color.FromArgb(150, 116, 48);   // gold for text on light backgrounds
 public static readonly Color GoldSoft = Color.FromArgb(247, 240, 224);  // hover / selection wash
 public static readonly Color Ivory = Color.FromArgb(251, 249, 245);     // page canvas
 public static readonly Color Panel = Color.FromArgb(243, 239, 231);     // tinted form panel
 public static readonly Color Card = Color.White;                        // card surface
 public static readonly Color Border = Color.FromArgb(229, 222, 208);    // hairlines
 public static readonly Color Text = Color.FromArgb(36, 40, 52);
 public static readonly Color Muted = Color.FromArgb(112, 116, 128);
 public static readonly Color Danger = Color.FromArgb(128, 40, 54);      // deep burgundy
 public static readonly Color DangerHover = Color.FromArgb(158, 56, 72);
 public static readonly Color DisabledBack = Color.FromArgb(236, 232, 223);
 public static readonly Color DisabledText = Color.FromArgb(150, 150, 156);
 public static readonly Color AltRow = Color.FromArgb(252, 250, 246);

 public const string Serif = "Georgia";
 public const string Sans = "Segoe UI";
 public static Font Display(float size) { return new Font(Serif, size, FontStyle.Bold); }
 public static Font Body(float size) { return new Font(Sans, size, FontStyle.Regular); }
 public static Font Strong(float size) { return new Font("Segoe UI Semibold", size, FontStyle.Regular); }
}

// Dark menu / status strip colours
internal class DarkColors : ProfessionalColorTable {
 public override Color MenuStripGradientBegin { get { return Theme.Ink; } }
 public override Color MenuStripGradientEnd { get { return Theme.Ink; } }
 public override Color StatusStripGradientBegin { get { return Theme.Ink; } }
 public override Color StatusStripGradientEnd { get { return Theme.Ink; } }
 public override Color ToolStripBorder { get { return Theme.Ink; } }
 public override Color MenuItemSelected { get { return Color.FromArgb(34, 56, 92); } }
 public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(34, 56, 92); } }
 public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(34, 56, 92); } }
 public override Color MenuItemPressedGradientBegin { get { return Color.FromArgb(34, 56, 92); } }
 public override Color MenuItemPressedGradientMiddle { get { return Color.FromArgb(34, 56, 92); } }
 public override Color MenuItemPressedGradientEnd { get { return Color.FromArgb(34, 56, 92); } }
 public override Color MenuItemBorder { get { return Theme.Gold; } }
 public override Color MenuBorder { get { return Theme.Gold; } }
 public override Color ToolStripDropDownBackground { get { return Color.FromArgb(19, 33, 58); } }
 public override Color ImageMarginGradientBegin { get { return Color.FromArgb(19, 33, 58); } }
 public override Color ImageMarginGradientMiddle { get { return Color.FromArgb(19, 33, 58); } }
 public override Color ImageMarginGradientEnd { get { return Color.FromArgb(19, 33, 58); } }
 public override Color SeparatorDark { get { return Color.FromArgb(60, 76, 104); } }
 public override Color SeparatorLight { get { return Color.FromArgb(60, 76, 104); } }
}

// Light toolbar colours (breadcrumb bar)
internal class LightColors : ProfessionalColorTable {
 public override Color ToolStripGradientBegin { get { return Theme.Card; } }
 public override Color ToolStripGradientMiddle { get { return Theme.Card; } }
 public override Color ToolStripGradientEnd { get { return Theme.Card; } }
 public override Color ToolStripBorder { get { return Theme.Border; } }
 public override Color ButtonSelectedGradientBegin { get { return Theme.GoldSoft; } }
 public override Color ButtonSelectedGradientMiddle { get { return Theme.GoldSoft; } }
 public override Color ButtonSelectedGradientEnd { get { return Theme.GoldSoft; } }
 public override Color ButtonSelectedHighlight { get { return Theme.GoldSoft; } }
 public override Color ButtonSelectedBorder { get { return Theme.Gold; } }
 public override Color ButtonPressedGradientBegin { get { return Theme.GoldSoft; } }
 public override Color ButtonPressedGradientMiddle { get { return Theme.GoldSoft; } }
 public override Color ButtonPressedGradientEnd { get { return Theme.GoldSoft; } }
 public override Color ButtonPressedBorder { get { return Theme.Gold; } }
 public override Color ButtonPressedHighlight { get { return Theme.GoldSoft; } }
}

// Dark menu renderer: draws a gold underline under the active page.
internal class MenuRenderer : ToolStripProfessionalRenderer {
 public MenuRenderer() : base(new DarkColors()) { RoundedEdges = false; }
 protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
  base.OnRenderMenuItemBackground(e);
  if (!e.Item.IsOnDropDown && (e.Item.Tag as string) == "active") {
   using (var b = new SolidBrush(Theme.Gold)) e.Graphics.FillRectangle(b, 8, e.Item.Height - 4, e.Item.Width - 16, 3);
  }
 }
}

internal class ToolbarRenderer : ToolStripProfessionalRenderer {
 public ToolbarRenderer() : base(new LightColors()) { RoundedEdges = false; }
}


// Logo: uses Assets\logo.png from the project root when present, otherwise an original gold monogram.
internal static class Logo {
 static Image custom; static bool tried, darkVariant;
 static Image Custom() {
  if (tried) return custom;
  tried = true;
  try {
   string dir = System.IO.Path.Combine(Db.Root, "Assets");
   string dark = System.IO.Path.Combine(dir, "logo-dark.png"), normal = System.IO.Path.Combine(dir, "logo.png");
   string path = System.IO.File.Exists(dark) ? dark : normal;
   darkVariant = path == dark;
   if (System.IO.File.Exists(path)) using (var img = Image.FromFile(path)) custom = new Bitmap(img);
  } catch { custom = null; }
  return custom;
 }

 // Aspect-correct logo on a white rounded plate (so dark artwork stays readable on dark backgrounds).
 public static Image Plate(int maxW, int maxH, int pad) {
  var img = Custom();
  if (img == null) return Mark(Math.Min(maxH, 72));
  float scale = Math.Min((maxW - 2f * pad) / img.Width, (maxH - 2f * pad) / img.Height);
  int w = (int)Math.Round(img.Width * scale), h = (int)Math.Round(img.Height * scale);
  var bmp = new Bitmap(w + pad * 2, h + pad * 2);
  using (var g = Graphics.FromImage(bmp)) {
   g.SmoothingMode = SmoothingMode.AntiAlias;
   g.InterpolationMode = InterpolationMode.HighQualityBicubic;
   g.PixelOffsetMode = PixelOffsetMode.HighQuality;
   if (!darkVariant) using (var path = new GraphicsPath()) {
    int r = Math.Max(6, pad), d = r * 2;
    path.AddArc(0, 0, d, d, 180, 90); path.AddArc(bmp.Width - d - 1, 0, d, d, 270, 90);
    path.AddArc(bmp.Width - d - 1, bmp.Height - d - 1, d, d, 0, 90); path.AddArc(0, bmp.Height - d - 1, d, d, 90, 90);
    path.CloseFigure();
    using (var b = new SolidBrush(Color.White)) g.FillPath(b, path);
   }
   g.DrawImage(img, new Rectangle(pad, pad, w, h));
  }
  return bmp;
 }
 public static Image Mark(int size) {
  var bmp = new Bitmap(size, size);
  using (var g = Graphics.FromImage(bmp)) {
   g.SmoothingMode = SmoothingMode.AntiAlias;
   g.InterpolationMode = InterpolationMode.HighQualityBicubic;
   g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
   var img = Custom();
   if (img != null) {
    float scale = Math.Min((float)size / img.Width, (float)size / img.Height);
    float w = img.Width * scale, h = img.Height * scale;
    g.DrawImage(img, (size - w) / 2, (size - h) / 2, w, h);
   } else {
    float pen = Math.Max(1.5f, size / 22f);
    using (var p = new Pen(Theme.Gold, pen)) g.DrawEllipse(p, pen, pen, size - pen * 2 - 1, size - pen * 2 - 1);
    using (var f = new Font(Theme.Serif, size * 0.46f, FontStyle.Bold))
    using (var b = new SolidBrush(Theme.Gold)) {
     var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
     g.DrawString("T", f, b, new RectangleF(0, 0, size, size), fmt);
    }
   }
  }
  return bmp;
 }
}

// Left-hand brand panel used on the sign-in screen
public class BrandPanel : Panel {
 Image mark;
 public BrandPanel() { DoubleBuffered = true; Dock = DockStyle.Left; BackColor = Theme.Ink; }
 protected override void OnResize(EventArgs e) { base.OnResize(e); Invalidate(); }
 protected override void OnPaint(PaintEventArgs e) {
  var g = e.Graphics;
  g.SmoothingMode = SmoothingMode.AntiAlias;
  g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
  if (Width < 2 || Height < 2) return;
  using (var br = new LinearGradientBrush(ClientRectangle, Color.FromArgb(10, 18, 34), Color.FromArgb(30, 52, 88), 60f)) g.FillRectangle(br, ClientRectangle);
  // decorative gold rings
  using (var pen = new Pen(Color.FromArgb(40, Theme.Gold), 1.5f)) {
   g.DrawEllipse(pen, Width - 220, Height - 260, 420, 420);
   g.DrawEllipse(pen, Width - 160, Height - 200, 300, 300);
   g.DrawEllipse(pen, -120, -120, 300, 300);
  }
  // gold edge
  using (var br = new SolidBrush(Theme.Gold)) g.FillRectangle(br, Width - 3, 0, 3, Height);
  int x = Math.Max(32, Width / 10);
  int w = Width - x * 2;
  if (mark == null) mark = Logo.Plate(Math.Min(w, 300), 190, 0);
  float y = Math.Max(36, Height * 0.10f);
  g.DrawImage(mark, x, (int)y, mark.Width, mark.Height);
  y += mark.Height + 40;
  using (var f = new Font(Theme.Sans, 9.5f, FontStyle.Bold))
  using (var br = new SolidBrush(Theme.Gold)) g.DrawString("TUTORIAL SUPPORT PORTAL", f, br, x, y);
  using (var f = new Font(Theme.Serif, 30f, FontStyle.Bold))
  using (var br = new SolidBrush(Color.FromArgb(250, 247, 240))) g.DrawString("TutAcad\nSupport", f, br, new RectangleF(x, y + 48, w, 140));
  if (Height > 560)
  using (var f = new Font(Theme.Sans, 11f))
  using (var br = new SolidBrush(Color.FromArgb(190, 200, 218))) g.DrawString("Book tutors, manage availability and keep track of every tutorial session in one place.", f, br, new RectangleF(x, y + 200, w, 90));
 }
}

// Dashboard tile: title + description, gold edge, hover highlight. Designable control.
public class TileButton : Button {
 string title = "", subtitle = ""; bool hot;
 public TileButton() {
  SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
  FlatStyle = FlatStyle.Flat; FlatAppearance.BorderSize = 0; BackColor = Theme.Card;
  Cursor = Cursors.Hand; Size = new Size(340, 104); Margin = new Padding(0, 0, 18, 18);
 }
 [DefaultValue(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
 public string Title { get { return title; } set { title = value ?? ""; Invalidate(); } }
 [DefaultValue(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
 public string Subtitle { get { return subtitle; } set { subtitle = value ?? ""; Invalidate(); } }
 protected override void OnMouseEnter(EventArgs e) { hot = true; Invalidate(); base.OnMouseEnter(e); }
 protected override void OnMouseLeave(EventArgs e) { hot = false; Invalidate(); base.OnMouseLeave(e); }
 protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
 protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }
 protected override void OnPaint(PaintEventArgs e) {
  var g = e.Graphics;
  g.SmoothingMode = SmoothingMode.AntiAlias;
  g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
  var r = new Rectangle(0, 0, Width - 1, Height - 1);
  using (var bg = new SolidBrush(hot ? Theme.GoldSoft : Theme.Card)) g.FillRectangle(bg, r);
  if (hot || Focused) using (var pen = new Pen(Theme.Gold, 1f)) g.DrawRectangle(pen, r);
  using (var bar = new SolidBrush(Theme.Gold)) g.FillRectangle(bar, 0, 0, 5, Height);
  using (var f = new Font(Theme.Serif, 12f, FontStyle.Bold))
  using (var br = new SolidBrush(Theme.Navy)) g.DrawString(title, f, br, new RectangleF(24, 16, Width - 60, 30));
  using (var f = new Font(Theme.Sans, 9f))
  using (var br = new SolidBrush(Theme.Muted)) g.DrawString(subtitle, f, br, new RectangleF(24, 48, Width - 70, 48));
  using (var f = new Font(Theme.Sans, 16f, FontStyle.Bold))
  using (var br = new SolidBrush(Theme.Gold)) g.DrawString("\u203A", f, br, Width - 36, Height / 2 - 18);
 }
}

// White input holder with a hairline border that turns gold while its text box has focus.
public class SoftBorderPanel : Panel {
 bool focus;
 public SoftBorderPanel() { DoubleBuffered = true; ResizeRedraw = true; BackColor = Theme.Card; Padding = new Padding(10, 8, 10, 4); }
 protected override void OnControlAdded(ControlEventArgs e) {
  base.OnControlAdded(e);
  var tb = e.Control as TextBox;
  if (tb != null) { tb.Enter += (s, a) => { focus = true; Invalidate(); }; tb.Leave += (s, a) => { focus = false; Invalidate(); }; }
 }
 protected override void OnPaint(PaintEventArgs e) {
  base.OnPaint(e);
  using (var pen = new Pen(focus ? Theme.Gold : Color.FromArgb(226, 220, 207))) e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
 }
}

internal static class Ui {
 public static IEnumerable<Control> All(Control parent){foreach(Control c in parent.Controls){yield return c;foreach(Control nested in All(c))yield return nested;}}

 // Behaviour only: look and layout live in each form's Designer file.
 public static void Behave(Form form){
  // The shell hosts the pages (each page fits itself), so only stand-alone/page forms need Fit.
  if(!(form is ShellForm)){
   form.Shown+=(s,e)=>Fit(form);
   form.Resize+=(s,e)=>Fit(form);
   form.VisibleChanged+=(s,e)=>{if(form.Visible)Fit(form);};
  }
  if(form is LoginForm)LoginLayout(form);
  var tip=new ToolTip();
  form.Disposed+=(s,e)=>tip.Dispose();
  foreach(Control c in All(form)){
   var tile=c as TileButton;
   if(tile!=null){tip.SetToolTip(tile,tile.Title);continue;}
   var b=c as Button;
   if(b!=null){tip.SetToolTip(b,b.Text);StyleButton(b);continue;}
   var g=c as DataGridView;
   if(g!=null)StyleGrid(g);
  }
 }

 // ------------------------------------------------------------------ buttons
 static bool IsDanger(Button b){return b.Text.StartsWith("Delete")||b.Text.StartsWith("Cancel selected");}
 static bool IsSecondary(Button b){string t=b.Text;return t.StartsWith("Refresh")||t=="Cancel"||t.StartsWith("Add another")||t.StartsWith("Discard")||t.StartsWith("Create a student")||t.StartsWith("Print")||t.StartsWith("Export")||t.StartsWith("Manage ")||t.StartsWith("Find ");}
 public static void StyleButton(Button b){
  bool danger=IsDanger(b), secondary=!danger&&IsSecondary(b);
  b.FlatStyle=FlatStyle.Flat;
  b.Cursor=Cursors.Hand;
  b.Font=Theme.Strong(10F);
  b.FlatAppearance.BorderSize=0;
  Action style=()=>{
   if(!b.Enabled){b.BackColor=Theme.DisabledBack;b.ForeColor=Theme.DisabledText;b.FlatAppearance.BorderColor=Theme.DisabledBack;return;}
   if(danger){b.BackColor=Theme.Card;b.ForeColor=Theme.Danger;b.FlatAppearance.BorderColor=Theme.Danger;b.FlatAppearance.MouseOverBackColor=Color.FromArgb(250,238,240);b.FlatAppearance.MouseDownBackColor=Color.FromArgb(244,222,226);}
   else if(secondary){b.BackColor=Theme.Card;b.ForeColor=Theme.Navy;b.FlatAppearance.BorderColor=Color.FromArgb(180,172,150);b.FlatAppearance.MouseOverBackColor=Theme.GoldSoft;b.FlatAppearance.MouseDownBackColor=Color.FromArgb(240,229,200);}
   else{b.BackColor=Theme.NavyButton;b.ForeColor=Color.White;b.FlatAppearance.BorderColor=Theme.NavyButton;b.FlatAppearance.MouseOverBackColor=Theme.NavyHover;b.FlatAppearance.MouseDownBackColor=Theme.Ink;}
  };
  b.EnabledChanged+=(s,e)=>style();
  style();
 }

 public static void StyleGrid(DataGridView g){
  g.EnableHeadersVisualStyles=false;
  g.BorderStyle=BorderStyle.None;
  g.BackgroundColor=Theme.Card;
  g.GridColor=Color.FromArgb(236,231,220);
  g.CellBorderStyle=DataGridViewCellBorderStyle.SingleHorizontal;
  g.ColumnHeadersBorderStyle=DataGridViewHeaderBorderStyle.None;
  g.RowHeadersVisible=false;
  g.ColumnHeadersDefaultCellStyle.BackColor=Theme.Navy;
  g.ColumnHeadersDefaultCellStyle.ForeColor=Color.White;
  g.ColumnHeadersDefaultCellStyle.SelectionBackColor=Theme.Navy;
  g.ColumnHeadersDefaultCellStyle.SelectionForeColor=Color.White;
  g.ColumnHeadersDefaultCellStyle.Font=Theme.Strong(9.5F);
  g.ColumnHeadersDefaultCellStyle.Padding=new Padding(8,8,8,8);
  g.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleLeft;
  g.DefaultCellStyle.BackColor=Theme.Card;
  g.DefaultCellStyle.ForeColor=Theme.Text;
  g.DefaultCellStyle.Padding=new Padding(8,0,8,0);
  g.DefaultCellStyle.SelectionBackColor=Theme.GoldSoft;
  g.DefaultCellStyle.SelectionForeColor=Theme.Navy;
  g.AlternatingRowsDefaultCellStyle.BackColor=Theme.AltRow;
  g.AlternatingRowsDefaultCellStyle.SelectionBackColor=Theme.GoldSoft;
  g.AlternatingRowsDefaultCellStyle.SelectionForeColor=Theme.Navy;
  g.RowTemplate.Height=36;
  g.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;
 }



 // Sign-in screen: brand panel takes 42% of the width and the form card stays centred.
 public static void LoginLayout(Form form){
  BrandPanel brand=null;
  foreach(Control c in All(form))if(c is BrandPanel){brand=(BrandPanel)c;break;}
  var hosts=form.Controls.Find("scrollHost",true);
  Action layout=()=>{
   if(brand!=null){brand.Visible=form.ClientSize.Width>=760;brand.Width=(int)(form.ClientSize.Width*0.42);}
   if(hosts.Length==0)return;
   var host=hosts[0];
   int formWidth=Math.Min(460,Math.Max(300,host.ClientSize.Width-60));
   int side=Math.Max(24,(host.ClientSize.Width-formWidth)/2);
   host.Padding=new Padding(side,Math.Max(24,(host.ClientSize.Height-560)/2),side,24);
  };
  form.Resize+=(s,e)=>layout();
  form.Shown+=(s,e)=>layout();
  layout();
 }

 public static void Fit(Form form){
  if(form.IsDisposed)return;
  var hosts=form.Controls.Find("scrollHost",true);
  if(hosts.Length==0)return;
  var host=hosts[0];
  if(!(form is LoginForm)){
   int avail=host.ClientSize.Width-SystemInformation.VerticalScrollBarWidth;
   int side=Math.Max(20,(avail-1120)/2);
   if(host.Padding.Left!=side||host.Padding.Top!=24){host.Padding=new Padding(side,24,side,24);}
  }
  int width=Math.Max(280,host.ClientSize.Width-host.Padding.Horizontal-SystemInformation.VerticalScrollBarWidth-6);
  form.PerformLayout();
  foreach(Control c in All(form)){
   int inner=width-(c.Parent is FlowLayoutPanel?c.Parent.Padding.Horizontal:0);
   if(c is DataGridView&&c.Parent is FlowLayoutPanel)c.Width=Math.Max(260,inner-6);
   else if(c is Label){
    var l=(Label)c;
    if(l.Name=="welcome"){l.MaximumSize=Size.Empty;l.Width=Math.Max(260,inner-6);}
    else if(l.Parent is FlowLayoutPanel)l.MaximumSize=new Size(Math.Max(200,inner-6),0);
    else if(l.Parent is TableLayoutPanel&&l.Parent.Name.StartsWith("card"))l.MaximumSize=new Size(Math.Max(200,l.Parent.Width-l.Parent.Padding.Horizontal-8),0);
   }
   else if(c is FlowLayoutPanel&&c.Name.StartsWith("tiles"))c.MaximumSize=new Size(width,0);
  }
  form.PerformLayout();
 }

 // ------------------------------------------------------------------ shell chrome
 public static void StyleShell(MenuStrip menu,ToolStrip trail,StatusStrip status,ToolStripLabel breadcrumb,ToolStripLabel identity,Panel content){
  menu.Renderer=new MenuRenderer();
  menu.BackColor=Theme.Ink;menu.ForeColor=Color.FromArgb(240,236,226);
  menu.Padding=new Padding(16,6,12,0);
  var brand=new ToolStripLabel("TUTACAD  SUPPORT");
  brand.Image=Logo.Plate(110,32,0);brand.ImageScaling=ToolStripItemImageScaling.None;brand.ImageAlign=ContentAlignment.MiddleLeft;brand.TextImageRelation=TextImageRelation.ImageBeforeText;brand.Font=new Font(Theme.Serif,12.5F,FontStyle.Bold);brand.ForeColor=Theme.Gold;brand.Margin=new Padding(0,0,28,0);
  menu.Items.Insert(0,brand);
  foreach(ToolStripItem item in menu.Items){
   if(item is ToolStripMenuItem){item.ForeColor=Color.FromArgb(240,236,226);item.Padding=new Padding(10,10,10,10);foreach(ToolStripItem d in ((ToolStripMenuItem)item).DropDownItems){d.ForeColor=Color.FromArgb(240,236,226);d.BackColor=Color.FromArgb(19,33,58);}}
  }
  trail.Renderer=new ToolbarRenderer();
  trail.BackColor=Theme.Card;trail.Padding=new Padding(14,8,14,8);
  foreach(ToolStripItem item in trail.Items){item.ForeColor=Theme.Navy;}
  breadcrumb.ForeColor=Theme.GoldDeep;breadcrumb.Font=Theme.Strong(10F);
  identity.ForeColor=Theme.Navy;identity.Font=Theme.Strong(10F);
  status.Renderer=new MenuRenderer();
  status.BackColor=Theme.Ink;status.ForeColor=Color.FromArgb(190,200,218);
  foreach(ToolStripItem item in status.Items){item.ForeColor=Color.FromArgb(190,200,218);}
  content.BackColor=Theme.Ivory;
 }

 public static void EnableSelected(DataGridView grid,params Button[] buttons){Action update=()=>{bool selected=grid.CurrentRow!=null&&grid.CurrentRow.Selected;foreach(var b in buttons)b.Enabled=selected;};grid.SelectionChanged+=(s,e)=>update();update();}
 public static void ReturnHome(Form form){if(ShellForm.Current!=null)ShellForm.Current.OpenPage("Home",()=>new DashboardForm());else form.Close();}
}
}
