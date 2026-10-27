using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            Ui.Behave(this);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (View.Design)
                return;

            try
            {
                Auth.Need("Student", "Tutor", "Administrator");

                welcome.Text = "Hello, " + Auth.Name + "  |  " + Auth.Role;

                bookings.Visible = Auth.Role == "Student";

                tutors.Visible = Auth.Role == "Administrator";
                requests.Visible = Auth.Role == "Administrator";
                reports.Visible = Auth.Role == "Administrator";

                availability.Visible = Auth.Role == "Tutor";

                sessions.Visible = Auth.Role != "Student";

                connection.Text =
                    "Use the navigation bar to switch pages. " +
                    "Alt+Left: Back. Ctrl+Home: Home. F5: Refresh.";
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while loading the dashboard: "
                    + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to load the dashboard in its current state: "
                    + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while loading the dashboard: "
                    + ex.Message
                );
            }
        }

        private void bookings_Click(object sender, EventArgs e)
        {
            try
            {
                Auth.Need("Student");

                ShellForm.Current.OpenPage(
                    "My bookings",
                    () => new BookingsForm()
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to open My Bookings: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while opening My Bookings: "
                    + ex.Message
                );
            }
        }

        private void tutors_Click(object sender, EventArgs e)
        {
            try
            {
                Auth.Need("Administrator");

                ShellForm.Current.OpenPage(
                    "Tutor management",
                    () => new TutorsForm()
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to open Tutor Management: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while opening Tutor Management: "
                    + ex.Message
                );
            }
        }

        private void requests_Click(object sender, EventArgs e)
        {
            try
            {
                Auth.Need("Administrator");

                ShellForm.Current.OpenPage(
                    "Support requests",
                    () => new RequestsForm()
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to open Support Requests: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while opening Support Requests: "
                    + ex.Message
                );
            }
        }

        private void availability_Click(object sender, EventArgs e)
        {
            try
            {
                Auth.Need("Tutor");

                ShellForm.Current.OpenPage(
                    "My availability",
                    () => new AvailabilityForm
                    {
                        TutorID = Auth.PersonID
                    }
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to open My Availability: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while opening My Availability: "
                    + ex.Message
                );
            }
        }

        private void sessions_Click(object sender, EventArgs e)
        {
            try
            {
                Auth.Need("Administrator", "Tutor");

                ShellForm.Current.OpenPage(
                    "Attendance",
                    () => new SessionsForm()
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to open Attendance: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while opening Attendance: "
                    + ex.Message
                );
            }
        }

        private void reports_Click(object sender, EventArgs e)
        {
            try
            {
                Auth.Need("Administrator");

                ShellForm.Current.OpenPage(
                    "Reports",
                    () => new ReportsForm()
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to open Reports: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while opening Reports: "
                    + ex.Message
                );
            }
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            try
            {
                ShellForm.Current.OpenPage(
                    "Change password",
                    () => new PasswordForm()
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to open Change Password: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while opening Change Password: "
                    + ex.Message
                );
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

