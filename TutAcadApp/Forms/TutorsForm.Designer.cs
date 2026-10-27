namespace TutAcadSupport {
partial class TutorsForm {
private System.ComponentModel.IContainer components = null;
protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
private void InitializeComponent() {
            this.scrollHost = new System.Windows.Forms.Panel();
            this.pageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.row0 = new System.Windows.Forms.FlowLayoutPanel();
            this.heading = new System.Windows.Forms.Label();
            this.row1 = new System.Windows.Forms.FlowLayoutPanel();
            this.intro = new System.Windows.Forms.Label();
            this.card1 = new System.Windows.Forms.TableLayoutPanel();
            this.sectionTutor = new System.Windows.Forms.Label();
            this.firstGroup = new System.Windows.Forms.Panel();
            this.softBox1 = new TutAcadSupport.SoftBorderPanel();
            this.first = new System.Windows.Forms.TextBox();
            this.firstLabel = new System.Windows.Forms.Label();
            this.lastGroup = new System.Windows.Forms.Panel();
            this.softBox2 = new TutAcadSupport.SoftBorderPanel();
            this.last = new System.Windows.Forms.TextBox();
            this.lastLabel = new System.Windows.Forms.Label();
            this.contactGroup = new System.Windows.Forms.Panel();
            this.softBox3 = new TutAcadSupport.SoftBorderPanel();
            this.contact = new System.Windows.Forms.TextBox();
            this.contactLabel = new System.Windows.Forms.Label();
            this.averageGroup = new System.Windows.Forms.Panel();
            this.average = new System.Windows.Forms.NumericUpDown();
            this.averageLabel = new System.Windows.Forms.Label();
            this.modeGroup = new System.Windows.Forms.Panel();
            this.mode = new System.Windows.Forms.ComboBox();
            this.modeLabel = new System.Windows.Forms.Label();
            this.usernameGroup = new System.Windows.Forms.Panel();
            this.softBox4 = new TutAcadSupport.SoftBorderPanel();
            this.username = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordGroup = new System.Windows.Forms.Panel();
            this.softBox5 = new TutAcadSupport.SoftBorderPanel();
            this.password = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.buttonBar1 = new System.Windows.Forms.FlowLayoutPanel();
            this.save = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.revert = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.tutorsGrid = new System.Windows.Forms.DataGridView();
            this.card2 = new System.Windows.Forms.TableLayoutPanel();
            this.sectionQualifications = new System.Windows.Forms.Label();
            this.courseGroup = new System.Windows.Forms.Panel();
            this.course = new System.Windows.Forms.ComboBox();
            this.courseLabel = new System.Windows.Forms.Label();
            this.buttonBar2 = new System.Windows.Forms.FlowLayoutPanel();
            this.qualify = new System.Windows.Forms.Button();
            this.availability = new System.Windows.Forms.Button();
            this.qualifications = new System.Windows.Forms.DataGridView();
            this.scrollHost.SuspendLayout();
            this.pageLayout.SuspendLayout();
            this.row0.SuspendLayout();
            this.row1.SuspendLayout();
            this.card1.SuspendLayout();
            this.firstGroup.SuspendLayout();
            this.softBox1.SuspendLayout();
            this.lastGroup.SuspendLayout();
            this.softBox2.SuspendLayout();
            this.contactGroup.SuspendLayout();
            this.softBox3.SuspendLayout();
            this.averageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.average)).BeginInit();
            this.modeGroup.SuspendLayout();
            this.usernameGroup.SuspendLayout();
            this.softBox4.SuspendLayout();
            this.passwordGroup.SuspendLayout();
            this.softBox5.SuspendLayout();
            this.buttonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorsGrid)).BeginInit();
            this.card2.SuspendLayout();
            this.courseGroup.SuspendLayout();
            this.buttonBar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualifications)).BeginInit();
            this.SuspendLayout();
            // 
            // scrollHost
            // 
            this.scrollHost.AutoScroll = true;
            this.scrollHost.Controls.Add(this.pageLayout);
            this.scrollHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollHost.Location = new System.Drawing.Point(0, 0);
            this.scrollHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrollHost.Name = "scrollHost";
            this.scrollHost.Padding = new System.Windows.Forms.Padding(25, 25, 25, 25);
            this.scrollHost.Size = new System.Drawing.Size(1225, 875);
            this.scrollHost.TabIndex = 0;
            // 
            // pageLayout
            // 
            this.pageLayout.AutoSize = true;
            this.pageLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pageLayout.ColumnCount = 1;
            this.pageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pageLayout.Controls.Add(this.row0, 0, 0);
            this.pageLayout.Controls.Add(this.row1, 0, 1);
            this.pageLayout.Controls.Add(this.card1, 0, 2);
            this.pageLayout.Controls.Add(this.card2, 0, 8);
            this.pageLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageLayout.Location = new System.Drawing.Point(25, 25);
            this.pageLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageLayout.Name = "pageLayout";
            this.pageLayout.RowCount = 12;
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.Size = new System.Drawing.Size(1154, 1848);
            this.pageLayout.TabIndex = 0;
            // 
            // row0
            // 
            this.row0.AutoSize = true;
            this.row0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.row0.Controls.Add(this.heading);
            this.row0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.row0.Location = new System.Drawing.Point(0, 0);
            this.row0.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.row0.Name = "row0";
            this.row0.Size = new System.Drawing.Size(1154, 58);
            this.row0.TabIndex = 0;
            // 
            // heading
            // 
            this.heading.AccessibleName = "Tutor management";
            this.heading.AutoSize = true;
            this.heading.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold);
            this.heading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.heading.Location = new System.Drawing.Point(0, 0);
            this.heading.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.heading.MaximumSize = new System.Drawing.Size(1062, 0);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(417, 46);
            this.heading.TabIndex = 0;
            this.heading.Text = "Tutor management";
            // 
            // row1
            // 
            this.row1.AutoSize = true;
            this.row1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.row1.Controls.Add(this.intro);
            this.row1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.row1.Location = new System.Drawing.Point(0, 73);
            this.row1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.row1.Name = "row1";
            this.row1.Size = new System.Drawing.Size(1154, 30);
            this.row1.TabIndex = 1;
            // 
            // intro
            // 
            this.intro.AccessibleName = "Add a tutor account, maintain contact details, assign courses and manage availabi" +
    "lity.";
            this.intro.AutoSize = true;
            this.intro.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.intro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(116)))), ((int)(((byte)(128)))));
            this.intro.Location = new System.Drawing.Point(0, 0);
            this.intro.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.intro.MaximumSize = new System.Drawing.Size(1062, 0);
            this.intro.Name = "intro";
            this.intro.Size = new System.Drawing.Size(686, 25);
            this.intro.TabIndex = 1;
            this.intro.Text = "Add a tutor account, maintain contact details, assign courses and manage availabi" +
    "lity.";
            // 
            // card1
            // 
            this.card1.AutoSize = true;
            this.card1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.card1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.card1.ColumnCount = 2;
            this.card1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.card1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.card1.Controls.Add(this.sectionTutor, 0, 0);
            this.card1.Controls.Add(this.firstGroup, 0, 1);
            this.card1.Controls.Add(this.lastGroup, 1, 1);
            this.card1.Controls.Add(this.contactGroup, 0, 2);
            this.card1.Controls.Add(this.averageGroup, 1, 2);
            this.card1.Controls.Add(this.modeGroup, 0, 3);
            this.card1.Controls.Add(this.usernameGroup, 1, 3);
            this.card1.Controls.Add(this.passwordGroup, 0, 4);
            this.card1.Controls.Add(this.buttonBar1, 0, 5);
            this.card1.Controls.Add(this.tutorsGrid, 0, 6);
            this.card1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card1.Location = new System.Drawing.Point(0, 118);
            this.card1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.card1.Name = "card1";
            this.card1.Padding = new System.Windows.Forms.Padding(32, 28, 32, 18);
            this.card1.RowCount = 7;
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.Size = new System.Drawing.Size(1154, 1064);
            this.card1.TabIndex = 12;
            // 
            // sectionTutor
            // 
            this.sectionTutor.AccessibleName = "Tutor profile";
            this.sectionTutor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sectionTutor.AutoSize = true;
            this.card1.SetColumnSpan(this.sectionTutor, 2);
            this.sectionTutor.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.sectionTutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.sectionTutor.Location = new System.Drawing.Point(32, 28);
            this.sectionTutor.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.sectionTutor.MaximumSize = new System.Drawing.Size(1062, 0);
            this.sectionTutor.Name = "sectionTutor";
            this.sectionTutor.Padding = new System.Windows.Forms.Padding(0, 15, 0, 5);
            this.sectionTutor.Size = new System.Drawing.Size(171, 49);
            this.sectionTutor.TabIndex = 2;
            this.sectionTutor.Text = "Tutor profile";
            // 
            // firstGroup
            // 
            this.firstGroup.Controls.Add(this.softBox1);
            this.firstGroup.Controls.Add(this.firstLabel);
            this.firstGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstGroup.Location = new System.Drawing.Point(32, 92);
            this.firstGroup.Margin = new System.Windows.Forms.Padding(0, 0, 22, 12);
            this.firstGroup.Name = "firstGroup";
            this.firstGroup.Size = new System.Drawing.Size(523, 78);
            this.firstGroup.TabIndex = 0;
            // 
            // softBox1
            // 
            this.softBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.softBox1.Controls.Add(this.first);
            this.softBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.softBox1.Location = new System.Drawing.Point(0, 32);
            this.softBox1.Margin = new System.Windows.Forms.Padding(0);
            this.softBox1.Name = "softBox1";
            this.softBox1.Padding = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.softBox1.Size = new System.Drawing.Size(523, 40);
            this.softBox1.TabIndex = 1;
            // 
            // first
            // 
            this.first.AccessibleName = "First name *";
            this.first.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.first.Dock = System.Windows.Forms.DockStyle.Fill;
            this.first.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.first.Location = new System.Drawing.Point(12, 10);
            this.first.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.first.MaxLength = 50;
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(499, 25);
            this.first.TabIndex = 3;
            this.first.TextChanged += new System.EventHandler(this.first_TextChanged);
            // 
            // firstLabel
            // 
            this.firstLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.firstLabel.Location = new System.Drawing.Point(0, 0);
            this.firstLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.firstLabel.Size = new System.Drawing.Size(523, 32);
            this.firstLabel.TabIndex = 0;
            this.firstLabel.Text = "First name *";
            this.firstLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lastGroup
            // 
            this.lastGroup.Controls.Add(this.softBox2);
            this.lastGroup.Controls.Add(this.lastLabel);
            this.lastGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastGroup.Location = new System.Drawing.Point(577, 92);
            this.lastGroup.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lastGroup.Name = "lastGroup";
            this.lastGroup.Size = new System.Drawing.Size(545, 78);
            this.lastGroup.TabIndex = 1;
            // 
            // softBox2
            // 
            this.softBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.softBox2.Controls.Add(this.last);
            this.softBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.softBox2.Location = new System.Drawing.Point(0, 32);
            this.softBox2.Margin = new System.Windows.Forms.Padding(0);
            this.softBox2.Name = "softBox2";
            this.softBox2.Padding = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.softBox2.Size = new System.Drawing.Size(545, 40);
            this.softBox2.TabIndex = 1;
            // 
            // last
            // 
            this.last.AccessibleName = "Last name *";
            this.last.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.last.Dock = System.Windows.Forms.DockStyle.Fill;
            this.last.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.last.Location = new System.Drawing.Point(12, 10);
            this.last.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.last.MaxLength = 50;
            this.last.Name = "last";
            this.last.Size = new System.Drawing.Size(521, 25);
            this.last.TabIndex = 4;
            // 
            // lastLabel
            // 
            this.lastLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lastLabel.Location = new System.Drawing.Point(0, 0);
            this.lastLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastLabel.Name = "lastLabel";
            this.lastLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lastLabel.Size = new System.Drawing.Size(545, 32);
            this.lastLabel.TabIndex = 0;
            this.lastLabel.Text = "Last name *";
            this.lastLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // contactGroup
            // 
            this.contactGroup.Controls.Add(this.softBox3);
            this.contactGroup.Controls.Add(this.contactLabel);
            this.contactGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactGroup.Location = new System.Drawing.Point(32, 182);
            this.contactGroup.Margin = new System.Windows.Forms.Padding(0, 0, 22, 12);
            this.contactGroup.Name = "contactGroup";
            this.contactGroup.Size = new System.Drawing.Size(523, 78);
            this.contactGroup.TabIndex = 2;
            // 
            // softBox3
            // 
            this.softBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.softBox3.Controls.Add(this.contact);
            this.softBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.softBox3.Location = new System.Drawing.Point(0, 32);
            this.softBox3.Margin = new System.Windows.Forms.Padding(0);
            this.softBox3.Name = "softBox3";
            this.softBox3.Padding = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.softBox3.Size = new System.Drawing.Size(523, 40);
            this.softBox3.TabIndex = 1;
            // 
            // contact
            // 
            this.contact.AccessibleName = "Email or phone *";
            this.contact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contact.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.contact.Location = new System.Drawing.Point(12, 10);
            this.contact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contact.MaxLength = 100;
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(499, 25);
            this.contact.TabIndex = 5;
            // 
            // contactLabel
            // 
            this.contactLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactLabel.Location = new System.Drawing.Point(0, 0);
            this.contactLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.contactLabel.Size = new System.Drawing.Size(523, 32);
            this.contactLabel.TabIndex = 0;
            this.contactLabel.Text = "Email or phone *";
            this.contactLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // averageGroup
            // 
            this.averageGroup.Controls.Add(this.average);
            this.averageGroup.Controls.Add(this.averageLabel);
            this.averageGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.averageGroup.Location = new System.Drawing.Point(577, 182);
            this.averageGroup.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.averageGroup.Name = "averageGroup";
            this.averageGroup.Size = new System.Drawing.Size(545, 78);
            this.averageGroup.TabIndex = 0;
            // 
            // average
            // 
            this.average.AccessibleName = "Academic average (%)";
            this.average.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.average.DecimalPlaces = 2;
            this.average.Dock = System.Windows.Forms.DockStyle.Top;
            this.average.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.average.Location = new System.Drawing.Point(0, 32);
            this.average.Margin = new System.Windows.Forms.Padding(0);
            this.average.Name = "average";
            this.average.Size = new System.Drawing.Size(545, 32);
            this.average.TabIndex = 6;
            // 
            // averageLabel
            // 
            this.averageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.averageLabel.Location = new System.Drawing.Point(0, 0);
            this.averageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.averageLabel.Name = "averageLabel";
            this.averageLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.averageLabel.Size = new System.Drawing.Size(545, 32);
            this.averageLabel.TabIndex = 0;
            this.averageLabel.Text = "Academic average (%)";
            this.averageLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // modeGroup
            // 
            this.modeGroup.Controls.Add(this.mode);
            this.modeGroup.Controls.Add(this.modeLabel);
            this.modeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modeGroup.Location = new System.Drawing.Point(32, 272);
            this.modeGroup.Margin = new System.Windows.Forms.Padding(0, 0, 22, 12);
            this.modeGroup.Name = "modeGroup";
            this.modeGroup.Size = new System.Drawing.Size(523, 78);
            this.modeGroup.TabIndex = 1;
            // 
            // mode
            // 
            this.mode.AccessibleName = "Mode";
            this.mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mode.Dock = System.Windows.Forms.DockStyle.Top;
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.DropDownWidth = 420;
            this.mode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.mode.FormattingEnabled = true;
            this.mode.Location = new System.Drawing.Point(0, 32);
            this.mode.Margin = new System.Windows.Forms.Padding(0);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(523, 33);
            this.mode.TabIndex = 7;
            // 
            // modeLabel
            // 
            this.modeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.modeLabel.Location = new System.Drawing.Point(0, 0);
            this.modeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.modeLabel.Size = new System.Drawing.Size(523, 32);
            this.modeLabel.TabIndex = 0;
            this.modeLabel.Text = "Mode";
            this.modeLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // usernameGroup
            // 
            this.usernameGroup.Controls.Add(this.softBox4);
            this.usernameGroup.Controls.Add(this.usernameLabel);
            this.usernameGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameGroup.Location = new System.Drawing.Point(577, 272);
            this.usernameGroup.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.usernameGroup.Name = "usernameGroup";
            this.usernameGroup.Size = new System.Drawing.Size(545, 78);
            this.usernameGroup.TabIndex = 0;
            // 
            // softBox4
            // 
            this.softBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.softBox4.Controls.Add(this.username);
            this.softBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.softBox4.Location = new System.Drawing.Point(0, 32);
            this.softBox4.Margin = new System.Windows.Forms.Padding(0);
            this.softBox4.Name = "softBox4";
            this.softBox4.Padding = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.softBox4.Size = new System.Drawing.Size(545, 40);
            this.softBox4.TabIndex = 1;
            // 
            // username
            // 
            this.username.AccessibleName = "Username (new tutor only) *";
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.username.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.username.Location = new System.Drawing.Point(12, 10);
            this.username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.username.MaxLength = 50;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(521, 25);
            this.username.TabIndex = 8;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.usernameLabel.Location = new System.Drawing.Point(0, 0);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.usernameLabel.Size = new System.Drawing.Size(545, 32);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username (new tutor only) *";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // passwordGroup
            // 
            this.passwordGroup.Controls.Add(this.softBox5);
            this.passwordGroup.Controls.Add(this.passwordLabel);
            this.passwordGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordGroup.Location = new System.Drawing.Point(32, 362);
            this.passwordGroup.Margin = new System.Windows.Forms.Padding(0, 0, 22, 12);
            this.passwordGroup.Name = "passwordGroup";
            this.passwordGroup.Size = new System.Drawing.Size(523, 78);
            this.passwordGroup.TabIndex = 1;
            // 
            // softBox5
            // 
            this.softBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.softBox5.Controls.Add(this.password);
            this.softBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.softBox5.Location = new System.Drawing.Point(0, 32);
            this.softBox5.Margin = new System.Windows.Forms.Padding(0);
            this.softBox5.Name = "softBox5";
            this.softBox5.Padding = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.softBox5.Size = new System.Drawing.Size(523, 40);
            this.softBox5.TabIndex = 1;
            // 
            // password
            // 
            this.password.AccessibleName = "Initial password (new tutor only) *";
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.password.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.password.Location = new System.Drawing.Point(12, 10);
            this.password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password.MaxLength = 128;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(499, 25);
            this.password.TabIndex = 9;
            this.password.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordLabel.Location = new System.Drawing.Point(0, 0);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.passwordLabel.Size = new System.Drawing.Size(523, 32);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Initial password (new tutor only) *";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonBar1
            // 
            this.buttonBar1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonBar1.AutoSize = true;
            this.buttonBar1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.card1.SetColumnSpan(this.buttonBar1, 2);
            this.buttonBar1.Controls.Add(this.save);
            this.buttonBar1.Controls.Add(this.clear);
            this.buttonBar1.Controls.Add(this.revert);
            this.buttonBar1.Controls.Add(this.refresh);
            this.buttonBar1.Location = new System.Drawing.Point(32, 462);
            this.buttonBar1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 12);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(819, 60);
            this.buttonBar1.TabIndex = 3;
            // 
            // save
            // 
            this.save.AccessibleName = "Save tutor";
            this.save.AutoSize = true;
            this.save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(50)))), ((int)(((byte)(84)))));
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(72)))), ((int)(((byte)(114)))));
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.save.Location = new System.Drawing.Point(0, 0);
            this.save.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.save.MinimumSize = new System.Drawing.Size(188, 52);
            this.save.Name = "save";
            this.save.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.save.Size = new System.Drawing.Size(188, 52);
            this.save.TabIndex = 10;
            this.save.Text = "Save tutor";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // clear
            // 
            this.clear.AccessibleName = "Add another tutor";
            this.clear.AutoSize = true;
            this.clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear.FlatAppearance.BorderSize = 0;
            this.clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(229)))), ((int)(((byte)(200)))));
            this.clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.clear.Location = new System.Drawing.Point(203, 0);
            this.clear.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.clear.MinimumSize = new System.Drawing.Size(188, 52);
            this.clear.Name = "clear";
            this.clear.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.clear.Size = new System.Drawing.Size(195, 52);
            this.clear.TabIndex = 11;
            this.clear.Text = "Add another tutor";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // revert
            // 
            this.revert.AccessibleName = "Discard edits";
            this.revert.AutoSize = true;
            this.revert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.revert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.revert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.revert.FlatAppearance.BorderSize = 0;
            this.revert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(229)))), ((int)(((byte)(200)))));
            this.revert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.revert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.revert.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.revert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.revert.Location = new System.Drawing.Point(413, 0);
            this.revert.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.revert.MinimumSize = new System.Drawing.Size(188, 52);
            this.revert.Name = "revert";
            this.revert.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.revert.Size = new System.Drawing.Size(188, 52);
            this.revert.TabIndex = 12;
            this.revert.Text = "Discard edits";
            this.revert.UseVisualStyleBackColor = false;
            this.revert.Click += new System.EventHandler(this.revert_Click);
            // 
            // refresh
            // 
            this.refresh.AccessibleName = "Refresh";
            this.refresh.AutoSize = true;
            this.refresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh.FlatAppearance.BorderSize = 0;
            this.refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(229)))), ((int)(((byte)(200)))));
            this.refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.refresh.Location = new System.Drawing.Point(616, 0);
            this.refresh.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.refresh.MinimumSize = new System.Drawing.Size(188, 52);
            this.refresh.Name = "refresh";
            this.refresh.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.refresh.Size = new System.Drawing.Size(188, 52);
            this.refresh.TabIndex = 13;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // tutorsGrid
            // 
            this.tutorsGrid.AccessibleName = "";
            this.tutorsGrid.AllowUserToAddRows = false;
            this.tutorsGrid.AllowUserToDeleteRows = false;
            this.tutorsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tutorsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.tutorsGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tutorsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tutorsGrid.ColumnHeadersHeight = 29;
            this.card1.SetColumnSpan(this.tutorsGrid, 2);
            this.tutorsGrid.EnableHeadersVisualStyles = false;
            this.tutorsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(231)))), ((int)(((byte)(220)))));
            this.tutorsGrid.Location = new System.Drawing.Point(32, 632);
            this.tutorsGrid.Margin = new System.Windows.Forms.Padding(0, 8, 0, 18);
            this.tutorsGrid.MultiSelect = false;
            this.tutorsGrid.Name = "tutorsGrid";
            this.tutorsGrid.ReadOnly = true;
            this.tutorsGrid.RowHeadersVisible = false;
            this.tutorsGrid.RowHeadersWidth = 51;
            this.tutorsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tutorsGrid.Size = new System.Drawing.Size(1090, 306);
            this.tutorsGrid.TabIndex = 14;
            this.tutorsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorsGrid_CellClick);
            // 
            // card2
            // 
            this.card2.AutoSize = true;
            this.card2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.card2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.card2.ColumnCount = 2;
            this.card2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.card2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.card2.Controls.Add(this.sectionQualifications, 0, 0);
            this.card2.Controls.Add(this.courseGroup, 0, 1);
            this.card2.Controls.Add(this.buttonBar2, 0, 2);
            this.card2.Controls.Add(this.qualifications, 0, 3);
            this.card2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card2.Location = new System.Drawing.Point(0, 1212);
            this.card2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.card2.Name = "card2";
            this.card2.Padding = new System.Windows.Forms.Padding(32, 28, 32, 18);
            this.card2.RowCount = 4;
            this.card2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card2.Size = new System.Drawing.Size(1154, 606);
            this.card2.TabIndex = 13;
            // 
            // sectionQualifications
            // 
            this.sectionQualifications.AccessibleName = "Courses and availability for the selected tutor";
            this.sectionQualifications.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sectionQualifications.AutoSize = true;
            this.card2.SetColumnSpan(this.sectionQualifications, 2);
            this.sectionQualifications.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.sectionQualifications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.sectionQualifications.Location = new System.Drawing.Point(32, 28);
            this.sectionQualifications.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.sectionQualifications.MaximumSize = new System.Drawing.Size(1062, 0);
            this.sectionQualifications.Name = "sectionQualifications";
            this.sectionQualifications.Padding = new System.Windows.Forms.Padding(0, 15, 0, 5);
            this.sectionQualifications.Size = new System.Drawing.Size(571, 49);
            this.sectionQualifications.TabIndex = 15;
            this.sectionQualifications.Text = "Courses and availability for the selected tutor";
            // 
            // courseGroup
            // 
            this.courseGroup.Controls.Add(this.course);
            this.courseGroup.Controls.Add(this.courseLabel);
            this.courseGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseGroup.Location = new System.Drawing.Point(32, 92);
            this.courseGroup.Margin = new System.Windows.Forms.Padding(0, 0, 22, 12);
            this.courseGroup.Name = "courseGroup";
            this.courseGroup.Size = new System.Drawing.Size(523, 70);
            this.courseGroup.TabIndex = 0;
            // 
            // course
            // 
            this.course.AccessibleName = "Course *";
            this.course.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.course.Dock = System.Windows.Forms.DockStyle.Top;
            this.course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.course.DropDownWidth = 420;
            this.course.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.course.FormattingEnabled = true;
            this.course.Location = new System.Drawing.Point(0, 32);
            this.course.Margin = new System.Windows.Forms.Padding(0);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(523, 33);
            this.course.TabIndex = 16;
            // 
            // courseLabel
            // 
            this.courseLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseLabel.Location = new System.Drawing.Point(0, 0);
            this.courseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.courseLabel.Name = "courseLabel";
            this.courseLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.courseLabel.Size = new System.Drawing.Size(523, 32);
            this.courseLabel.TabIndex = 0;
            this.courseLabel.Text = "Course *";
            this.courseLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonBar2
            // 
            this.buttonBar2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonBar2.AutoSize = true;
            this.buttonBar2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.card2.SetColumnSpan(this.buttonBar2, 2);
            this.buttonBar2.Controls.Add(this.qualify);
            this.buttonBar2.Controls.Add(this.availability);
            this.buttonBar2.Location = new System.Drawing.Point(32, 184);
            this.buttonBar2.Margin = new System.Windows.Forms.Padding(0, 10, 0, 12);
            this.buttonBar2.Name = "buttonBar2";
            this.buttonBar2.Size = new System.Drawing.Size(423, 60);
            this.buttonBar2.TabIndex = 16;
            // 
            // qualify
            // 
            this.qualify.AccessibleName = "Assign course";
            this.qualify.AutoSize = true;
            this.qualify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.qualify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(50)))), ((int)(((byte)(84)))));
            this.qualify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.qualify.FlatAppearance.BorderSize = 0;
            this.qualify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.qualify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(72)))), ((int)(((byte)(114)))));
            this.qualify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.qualify.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.qualify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.qualify.Location = new System.Drawing.Point(0, 0);
            this.qualify.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.qualify.MinimumSize = new System.Drawing.Size(188, 52);
            this.qualify.Name = "qualify";
            this.qualify.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.qualify.Size = new System.Drawing.Size(188, 52);
            this.qualify.TabIndex = 17;
            this.qualify.Text = "Assign course";
            this.qualify.UseVisualStyleBackColor = false;
            this.qualify.Click += new System.EventHandler(this.qualify_Click);
            // 
            // availability
            // 
            this.availability.AccessibleName = "Manage availability";
            this.availability.AutoSize = true;
            this.availability.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.availability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.availability.Cursor = System.Windows.Forms.Cursors.Hand;
            this.availability.FlatAppearance.BorderSize = 0;
            this.availability.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(229)))), ((int)(((byte)(200)))));
            this.availability.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.availability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.availability.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.availability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.availability.Location = new System.Drawing.Point(203, 0);
            this.availability.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.availability.MinimumSize = new System.Drawing.Size(188, 52);
            this.availability.Name = "availability";
            this.availability.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.availability.Size = new System.Drawing.Size(205, 52);
            this.availability.TabIndex = 18;
            this.availability.Text = "Manage availability";
            this.availability.UseVisualStyleBackColor = false;
            this.availability.Click += new System.EventHandler(this.availability_Click);
            // 
            // qualifications
            // 
            this.qualifications.AccessibleName = "";
            this.qualifications.AllowUserToAddRows = false;
            this.qualifications.AllowUserToDeleteRows = false;
            this.qualifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.qualifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.qualifications.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.qualifications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.qualifications.ColumnHeadersHeight = 29;
            this.card2.SetColumnSpan(this.qualifications, 2);
            this.qualifications.EnableHeadersVisualStyles = false;
            this.qualifications.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(231)))), ((int)(((byte)(220)))));
            this.qualifications.Location = new System.Drawing.Point(32, 264);
            this.qualifications.Margin = new System.Windows.Forms.Padding(0, 8, 0, 18);
            this.qualifications.MultiSelect = false;
            this.qualifications.Name = "qualifications";
            this.qualifications.ReadOnly = true;
            this.qualifications.RowHeadersVisible = false;
            this.qualifications.RowHeadersWidth = 51;
            this.qualifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qualifications.Size = new System.Drawing.Size(1090, 306);
            this.qualifications.TabIndex = 19;
            // 
            // TutorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1225, 875);
            this.Controls.Add(this.scrollHost);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(746, 551);
            this.Name = "TutorsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tutor management | TutAcadSupport";
            this.Load += new System.EventHandler(this.Form_Load);
            this.scrollHost.ResumeLayout(false);
            this.scrollHost.PerformLayout();
            this.pageLayout.ResumeLayout(false);
            this.pageLayout.PerformLayout();
            this.row0.ResumeLayout(false);
            this.row0.PerformLayout();
            this.row1.ResumeLayout(false);
            this.row1.PerformLayout();
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.firstGroup.ResumeLayout(false);
            this.softBox1.ResumeLayout(false);
            this.softBox1.PerformLayout();
            this.lastGroup.ResumeLayout(false);
            this.softBox2.ResumeLayout(false);
            this.softBox2.PerformLayout();
            this.contactGroup.ResumeLayout(false);
            this.softBox3.ResumeLayout(false);
            this.softBox3.PerformLayout();
            this.averageGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.average)).EndInit();
            this.modeGroup.ResumeLayout(false);
            this.usernameGroup.ResumeLayout(false);
            this.softBox4.ResumeLayout(false);
            this.softBox4.PerformLayout();
            this.passwordGroup.ResumeLayout(false);
            this.softBox5.ResumeLayout(false);
            this.softBox5.PerformLayout();
            this.buttonBar1.ResumeLayout(false);
            this.buttonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorsGrid)).EndInit();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.courseGroup.ResumeLayout(false);
            this.buttonBar2.ResumeLayout(false);
            this.buttonBar2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualifications)).EndInit();
            this.ResumeLayout(false);

}
private System.Windows.Forms.Panel scrollHost;
private System.Windows.Forms.TableLayoutPanel pageLayout;
private System.Windows.Forms.FlowLayoutPanel row0;
private System.Windows.Forms.Label heading;
private System.Windows.Forms.FlowLayoutPanel row1;
private System.Windows.Forms.Label intro;
private System.Windows.Forms.TableLayoutPanel card1;
private System.Windows.Forms.Label sectionTutor;
private System.Windows.Forms.Panel firstGroup;
private TutAcadSupport.SoftBorderPanel softBox1;
private System.Windows.Forms.TextBox first;
private System.Windows.Forms.Label firstLabel;
private System.Windows.Forms.Panel lastGroup;
private TutAcadSupport.SoftBorderPanel softBox2;
private System.Windows.Forms.TextBox last;
private System.Windows.Forms.Label lastLabel;
private System.Windows.Forms.Panel contactGroup;
private TutAcadSupport.SoftBorderPanel softBox3;
private System.Windows.Forms.TextBox contact;
private System.Windows.Forms.Label contactLabel;
private System.Windows.Forms.Panel averageGroup;
private System.Windows.Forms.NumericUpDown average;
private System.Windows.Forms.Label averageLabel;
private System.Windows.Forms.Panel modeGroup;
private System.Windows.Forms.ComboBox mode;
private System.Windows.Forms.Label modeLabel;
private System.Windows.Forms.Panel usernameGroup;
private TutAcadSupport.SoftBorderPanel softBox4;
private System.Windows.Forms.TextBox username;
private System.Windows.Forms.Label usernameLabel;
private System.Windows.Forms.Panel passwordGroup;
private TutAcadSupport.SoftBorderPanel softBox5;
private System.Windows.Forms.TextBox password;
private System.Windows.Forms.Label passwordLabel;
private System.Windows.Forms.FlowLayoutPanel buttonBar1;
private System.Windows.Forms.Button save;
private System.Windows.Forms.Button clear;
private System.Windows.Forms.Button revert;
private System.Windows.Forms.Button refresh;
private System.Windows.Forms.DataGridView tutorsGrid;
private System.Windows.Forms.TableLayoutPanel card2;
private System.Windows.Forms.Label sectionQualifications;
private System.Windows.Forms.Panel courseGroup;
private System.Windows.Forms.ComboBox course;
private System.Windows.Forms.Label courseLabel;
private System.Windows.Forms.FlowLayoutPanel buttonBar2;
private System.Windows.Forms.Button qualify;
private System.Windows.Forms.Button availability;
private System.Windows.Forms.DataGridView qualifications;
}
}
