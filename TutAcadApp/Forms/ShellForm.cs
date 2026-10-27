using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class ShellForm : Form
    {
        public static ShellForm Current;

        private readonly Dictionary<string, Form> pages =
            new Dictionary<string, Form>();

        private readonly Stack<string> history = new Stack<string>();

        private string current = "";
        private bool leaving = false;

        public ShellForm()
        {
            InitializeComponent();
            Ui.Behave(this);
        }

        private void Form_Load(object s, EventArgs e)
        {
            if (View.Design)
                return;

            Current = this;

            bookings.Visible = Auth.Role == "Student";

            tutors.Visible =
                requests.Visible =
                reports.Visible = Auth.Role == "Administrator";

            availability.Visible = Auth.Role == "Tutor";
            sessions.Visible = Auth.Role != "Student";

            identity.Text = Auth.Name + " | " + Auth.Role;

            Home_Click(s, e);
        }

        public void OpenPage(string key, Func<Form> factory)
        {
            try
            {
                if (!pages.ContainsKey(key) || pages[key].IsDisposed)
                {
                    Form f = factory();

                    f.TopLevel = false;
                    f.FormBorderStyle = FormBorderStyle.None;
                    f.MinimumSize = Size.Empty;
                    f.Dock = DockStyle.Fill;

                    pages[key] = f;
                    contentHost.Controls.Add(f);

                    f.FormClosed += (s, e) =>
                    {
                        if (!leaving)
                            Home_Click(s, e);
                    };
                }

                ShowPage(key, true);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Navigation error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while opening the page.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPage(string key, bool remember)
        {
            if (current == key)
                return;

            if (remember && current.Length > 0)
                history.Push(current);

            foreach (Form page in pages.Values)
            {
                if (!page.IsDisposed)
                    page.Hide();
            }

            current = key;

            Form f = pages[key];

            f.Show();
            f.BringToFront();

            Ui.Fit(f);

            breadcrumb.Text = "  /  " + key;

            MarkActive(key);

            back.Enabled = history.Count > 0;

            SetStatus(
                "Ready. Use Back or Home to navigate; your entries are kept until you sign out.");
        }

        private void MarkActive(string key)
        {
            ToolStripMenuItem target =
                key == "Home" ? home :
                key == "My bookings" ? bookings :
                key == "Tutor management" ? tutors :
                key == "Support requests" ? requests :
                key == "My availability" ? availability :
                key == "Attendance" ? sessions :
                key == "Reports" ? reports :
                key == "Change password" ? account : null;

            foreach (ToolStripItem item in navigation.Items)
            {
                item.Tag = item == target ? "active" : null;
            }

            navigation.Invalidate();
        }

        public void SetStatus(string message)
        {
            status.Text = message;
        }

        private void Home_Click(object s, EventArgs e)
        {
            OpenPage("Home", () => new DashboardForm());
        }

        private void Bookings_Click(object s, EventArgs e)
        {
            OpenPage("My bookings", () => new BookingsForm());
        }

        private void Tutors_Click(object s, EventArgs e)
        {
            OpenPage("Tutor management", () => new TutorsForm());
        }

        private void Requests_Click(object s, EventArgs e)
        {
            OpenPage("Support requests", () => new RequestsForm());
        }

        private void Availability_Click(object s, EventArgs e)
        {
            OpenPage("My availability",
                () => new AvailabilityForm { TutorID = Auth.PersonID });
        }

        private void Sessions_Click(object s, EventArgs e)
        {
            OpenPage("Attendance", () => new SessionsForm());
        }

        private void Reports_Click(object s, EventArgs e)
        {
            OpenPage("Reports", () => new ReportsForm());
        }

        private void Password_Click(object s, EventArgs e)
        {
            OpenPage("Change password", () => new PasswordForm());
        }

        private void Logout_Click(object s, EventArgs e)
        {
            Close();
        }

        private void Back_Click(object s, EventArgs e)
        {
            while (history.Count > 0)
            {
                string key = history.Pop();

                if (pages.ContainsKey(key) && !pages[key].IsDisposed)
                {
                    ShowPage(key, false);
                    return;
                }
            }

            back.Enabled = false;
        }

        private void Shell_Closing(object s, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Sign out and return to the sign-in screen? Unsaved entries will be discarded.",
                "Confirm sign out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            leaving = true;
            Current = null;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.Left))
            {
                Back_Click(this, EventArgs.Empty);
                return true;
            }

            if (keyData == (Keys.Control | Keys.Home))
            {
                Home_Click(this, EventArgs.Empty);
                return true;
            }

            if (keyData == Keys.F5 && pages.ContainsKey(current))
            {
                Control[] controls = pages[current].Controls.Find("refresh", true);

                if (controls.Length > 0 && controls[0] is Button)
                    ((Button)controls[0]).PerformClick();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void contentHost_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

