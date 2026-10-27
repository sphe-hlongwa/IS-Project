namespace TutAcadSupport {
partial class LoginForm {
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
            this.usernameGroup = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordGroup = new System.Windows.Forms.Panel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.buttonBar1 = new System.Windows.Forms.FlowLayoutPanel();
            this.login = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.connection = new System.Windows.Forms.Label();
            this.softBox1 = new TutAcadSupport.SoftBorderPanel();
            this.username = new System.Windows.Forms.TextBox();
            this.softBox2 = new TutAcadSupport.SoftBorderPanel();
            this.password = new System.Windows.Forms.TextBox();
            this.brandPanel1 = new TutAcadSupport.BrandPanel();
            this.scrollHost.SuspendLayout();
            this.pageLayout.SuspendLayout();
            this.row0.SuspendLayout();
            this.row1.SuspendLayout();
            this.card1.SuspendLayout();
            this.usernameGroup.SuspendLayout();
            this.passwordGroup.SuspendLayout();
            this.buttonBar1.SuspendLayout();
            this.softBox1.SuspendLayout();
            this.softBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrollHost
            // 
            this.scrollHost.AutoScroll = true;
            this.scrollHost.Controls.Add(this.pageLayout);
            this.scrollHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollHost.Location = new System.Drawing.Point(511, 0);
            this.scrollHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrollHost.Name = "scrollHost";
            this.scrollHost.Padding = new System.Windows.Forms.Padding(25, 25, 25, 25);
            this.scrollHost.Size = new System.Drawing.Size(714, 875);
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
            this.pageLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageLayout.Location = new System.Drawing.Point(25, 25);
            this.pageLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageLayout.Name = "pageLayout";
            this.pageLayout.RowCount = 6;
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pageLayout.Size = new System.Drawing.Size(664, 493);
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
            this.row0.Size = new System.Drawing.Size(664, 58);
            this.row0.TabIndex = 0;
            // 
            // heading
            // 
            this.heading.AccessibleName = "Welcome to TutAcadSupport";
            this.heading.AutoSize = true;
            this.heading.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold);
            this.heading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.heading.Location = new System.Drawing.Point(0, 0);
            this.heading.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.heading.MaximumSize = new System.Drawing.Size(1062, 0);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(612, 46);
            this.heading.TabIndex = 0;
            this.heading.Text = "Welcome to TutAcadSupport";
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
            this.row1.Size = new System.Drawing.Size(664, 30);
            this.row1.TabIndex = 1;
            // 
            // intro
            // 
            this.intro.AccessibleName = "Sign in to book support, manage tutoring or view programme reports.";
            this.intro.AutoSize = true;
            this.intro.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.intro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(116)))), ((int)(((byte)(128)))));
            this.intro.Location = new System.Drawing.Point(0, 0);
            this.intro.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.intro.MaximumSize = new System.Drawing.Size(1062, 0);
            this.intro.Name = "intro";
            this.intro.Size = new System.Drawing.Size(573, 25);
            this.intro.TabIndex = 1;
            this.intro.Text = "Sign in to book support, manage tutoring or view programme reports.";
            // 
            // card1
            // 
            this.card1.AutoSize = true;
            this.card1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.card1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.card1.ColumnCount = 1;
            this.card1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.card1.Controls.Add(this.usernameGroup, 0, 0);
            this.card1.Controls.Add(this.passwordGroup, 0, 1);
            this.card1.Controls.Add(this.buttonBar1, 0, 2);
            this.card1.Controls.Add(this.connection, 0, 3);
            this.card1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card1.Location = new System.Drawing.Point(0, 118);
            this.card1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.card1.Name = "card1";
            this.card1.Padding = new System.Windows.Forms.Padding(32, 28, 32, 18);
            this.card1.RowCount = 4;
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.card1.Size = new System.Drawing.Size(664, 345);
            this.card1.TabIndex = 2;
            // 
            // usernameGroup
            // 
            this.usernameGroup.Controls.Add(this.softBox1);
            this.usernameGroup.Controls.Add(this.usernameLabel);
            this.usernameGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameGroup.Location = new System.Drawing.Point(32, 28);
            this.usernameGroup.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.usernameGroup.Name = "usernameGroup";
            this.usernameGroup.Size = new System.Drawing.Size(600, 78);
            this.usernameGroup.TabIndex = 0;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.usernameLabel.Location = new System.Drawing.Point(0, 0);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.usernameLabel.Size = new System.Drawing.Size(600, 32);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username *";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // passwordGroup
            // 
            this.passwordGroup.Controls.Add(this.softBox2);
            this.passwordGroup.Controls.Add(this.passwordLabel);
            this.passwordGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordGroup.Location = new System.Drawing.Point(32, 118);
            this.passwordGroup.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.passwordGroup.Name = "passwordGroup";
            this.passwordGroup.Size = new System.Drawing.Size(600, 78);
            this.passwordGroup.TabIndex = 0;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordLabel.Location = new System.Drawing.Point(0, 0);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.passwordLabel.Size = new System.Drawing.Size(600, 32);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Password *";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonBar1
            // 
            this.buttonBar1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonBar1.AutoSize = true;
            this.buttonBar1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBar1.Controls.Add(this.login);
            this.buttonBar1.Controls.Add(this.register);
            this.buttonBar1.Location = new System.Drawing.Point(32, 218);
            this.buttonBar1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 12);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(467, 60);
            this.buttonBar1.TabIndex = 1;
            // 
            // login
            // 
            this.login.AccessibleName = "Sign in";
            this.login.AutoSize = true;
            this.login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(50)))), ((int)(((byte)(84)))));
            this.login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login.FlatAppearance.BorderSize = 0;
            this.login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(72)))), ((int)(((byte)(114)))));
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.login.Location = new System.Drawing.Point(0, 0);
            this.login.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.login.MinimumSize = new System.Drawing.Size(188, 52);
            this.login.Name = "login";
            this.login.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.login.Size = new System.Drawing.Size(188, 52);
            this.login.TabIndex = 4;
            this.login.Text = "Sign in";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // register
            // 
            this.register.AccessibleName = "Create a student account";
            this.register.AutoSize = true;
            this.register.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register.FlatAppearance.BorderSize = 0;
            this.register.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(229)))), ((int)(((byte)(200)))));
            this.register.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.register.Location = new System.Drawing.Point(203, 0);
            this.register.Margin = new System.Windows.Forms.Padding(0, 0, 15, 8);
            this.register.MinimumSize = new System.Drawing.Size(188, 52);
            this.register.Name = "register";
            this.register.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.register.Size = new System.Drawing.Size(249, 52);
            this.register.TabIndex = 5;
            this.register.Text = "Create a student account";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // connection
            // 
            this.connection.AccessibleName = "";
            this.connection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.connection.AutoSize = true;
            this.connection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(116)))), ((int)(((byte)(128)))));
            this.connection.Location = new System.Drawing.Point(32, 292);
            this.connection.Margin = new System.Windows.Forms.Padding(0, 2, 0, 12);
            this.connection.MaximumSize = new System.Drawing.Size(1062, 0);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(0, 23);
            this.connection.TabIndex = 6;
            // 
            // softBox1
            // 
            this.softBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.softBox1.Controls.Add(this.username);
            this.softBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.softBox1.Location = new System.Drawing.Point(0, 32);
            this.softBox1.Margin = new System.Windows.Forms.Padding(0);
            this.softBox1.Name = "softBox1";
            this.softBox1.Padding = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.softBox1.Size = new System.Drawing.Size(600, 40);
            this.softBox1.TabIndex = 1;
            // 
            // username
            // 
            this.username.AccessibleName = "Username *";
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.username.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.username.Location = new System.Drawing.Point(12, 10);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.MaxLength = 50;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(576, 25);
            this.username.TabIndex = 2;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // softBox2
            // 
            this.softBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.softBox2.Controls.Add(this.password);
            this.softBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.softBox2.Location = new System.Drawing.Point(0, 32);
            this.softBox2.Margin = new System.Windows.Forms.Padding(0);
            this.softBox2.Name = "softBox2";
            this.softBox2.Padding = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.softBox2.Size = new System.Drawing.Size(600, 40);
            this.softBox2.TabIndex = 1;
            // 
            // password
            // 
            this.password.AccessibleName = "Password *";
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.password.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.password.Location = new System.Drawing.Point(12, 10);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.MaxLength = 128;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(576, 25);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // brandPanel1
            // 
            this.brandPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.brandPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.brandPanel1.Location = new System.Drawing.Point(0, 0);
            this.brandPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.brandPanel1.Name = "brandPanel1";
            this.brandPanel1.Size = new System.Drawing.Size(511, 875);
            this.brandPanel1.TabIndex = 1;
            this.brandPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.brandPanel1_Paint);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1225, 875);
            this.Controls.Add(this.scrollHost);
            this.Controls.Add(this.brandPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(746, 551);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Welcome to TutAcadSupport | TutAcadSupport";
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
            this.usernameGroup.ResumeLayout(false);
            this.passwordGroup.ResumeLayout(false);
            this.buttonBar1.ResumeLayout(false);
            this.buttonBar1.PerformLayout();
            this.softBox1.ResumeLayout(false);
            this.softBox1.PerformLayout();
            this.softBox2.ResumeLayout(false);
            this.softBox2.PerformLayout();
            this.ResumeLayout(false);

}
private System.Windows.Forms.Panel scrollHost;
private System.Windows.Forms.TableLayoutPanel pageLayout;
private System.Windows.Forms.FlowLayoutPanel row0;
private System.Windows.Forms.Label heading;
private System.Windows.Forms.FlowLayoutPanel row1;
private System.Windows.Forms.Label intro;
private System.Windows.Forms.TableLayoutPanel card1;
private System.Windows.Forms.Panel usernameGroup;
private TutAcadSupport.SoftBorderPanel softBox1;
private System.Windows.Forms.TextBox username;
private System.Windows.Forms.Label usernameLabel;
private System.Windows.Forms.Panel passwordGroup;
private TutAcadSupport.SoftBorderPanel softBox2;
private System.Windows.Forms.TextBox password;
private System.Windows.Forms.Label passwordLabel;
private System.Windows.Forms.FlowLayoutPanel buttonBar1;
private System.Windows.Forms.Button login;
private System.Windows.Forms.Button register;
private System.Windows.Forms.Label connection;
private TutAcadSupport.BrandPanel brandPanel1;
}
}
