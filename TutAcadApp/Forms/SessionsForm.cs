using System;
using System.Data;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class SessionsForm : Form
    {
        public SessionsForm()
        {
            InitializeComponent();
            Ui.Behave(this);
            sessions.SelectionChanged += (s, e) => SelectSession();
            save.Enabled = false;
        }

        private void Form_Load(object s, EventArgs e)
        {
            if (View.Design)
                return;

            try
            {
                Auth.Need("Tutor", "Administrator");

                status.Items.AddRange(new object[] { "Completed", "Absent" });
                status.SelectedIndex = 0;

                Reload();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Access denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while opening the sessions page.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectSession()
        {
            save.Enabled = false;
            topics.Clear();

            if (sessions.CurrentRow == null ||
                !sessions.CurrentRow.Selected ||
                !(sessions.CurrentRow.DataBoundItem is DataRowView))
            {
                return;
            }

            DataRow row = ((DataRowView)sessions.CurrentRow.DataBoundItem).Row;

            bool allowed =
                row["AttendanceStatus"].ToString() == "Scheduled" &&
                (DateTime)row["EndTime"] <= DateTime.Now;

            save.Enabled = allowed;

            if (allowed)
            {
                sectionSelect.Text = "Booking " + row["SessionID"] +
                    " • " + row["AttendanceStatus"] +
                    " — record attendance below";
            }
            else
            {
                sectionSelect.Text = "Booking " + row["SessionID"] +
                    " • " + row["AttendanceStatus"] +
                    " — attendance can only be recorded for an ended, scheduled session";
            }
        }

        private void Reload()
        {
            sessions.DataSource = School.Sessions();
        }

        private void save_Click(object s, EventArgs e)
        {
            try
            {
                if (sessions.CurrentRow == null ||
                    !(sessions.CurrentRow.DataBoundItem is DataRowView))
                {
                    MessageBox.Show("Select a session first.");
                    return;
                }

                DataRow row = ((DataRowView)sessions.CurrentRow.DataBoundItem).Row;

                bool allowed =
                    row["AttendanceStatus"].ToString() == "Scheduled" &&
                    (DateTime)row["EndTime"] <= DateTime.Now;

                if (!allowed)
                {
                    MessageBox.Show(
                        "Attendance can only be recorded for an ended, scheduled session.");
                    return;
                }

                School.Complete(
                    row["SessionID"].ToString(),
                    status.Text,
                    topics.Text);

                Reload();

                MessageBox.Show("Attendance and notes saved.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to save attendance",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving attendance and notes.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refresh_Click(object s, EventArgs e)
        {
            try
            {
                Reload();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while refreshing the sessions.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
