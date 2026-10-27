using System;
using System.Data;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class TutorsForm : Form
    {
        private string tutorID = "";

        public TutorsForm()
        {
            InitializeComponent();
            Ui.Behave(this);

            tutorsGrid.KeyUp += (s, e) =>
            {
                if (tutorsGrid.CurrentRow != null)
                {
                    tutorsGrid_CellClick(
                        s,
                        new DataGridViewCellEventArgs(0, tutorsGrid.CurrentRow.Index));
                }
            };
        }

        private void Form_Load(object s, EventArgs e)
        {
            if (View.Design)
                return;

            try
            {
                Auth.Need("Administrator");

                mode.Items.AddRange(new object[] { "Online", "In-person" });
                mode.SelectedIndex = 0;

                DataTable courses = School.Courses();
                course.DataSource = courses;
                course.DisplayMember = "CourseName";
                course.ValueMember = "CourseCode";

                Reload();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Access denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while opening tutor management.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reload()
        {
            tutorsGrid.DataSource = School.Tutors();

            if (tutorID.Length > 0)
            {
                qualifications.DataSource = Db.Query(
                    "SELECT CourseCode, VerificationDate FROM TutorQualification WHERE TutorID=?",
                    tutorID);
            }
        }

        private void revert_Click(object s, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Discard your unsaved profile changes?",
                "Confirm changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            if (tutorID.Length == 0)
            {
                clear_Click(s, e);
                return;
            }

            foreach (DataGridViewRow row in tutorsGrid.Rows)
            {
                if (Convert.ToString(row.Cells["TutorID"].Value) == tutorID)
                {
                    tutorsGrid.CurrentCell = row.Cells[0];
                    row.Selected = true;

                    tutorsGrid_CellClick(
                        s,
                        new DataGridViewCellEventArgs(0, row.Index));

                    return;
                }
            }
        }

        private void clear_Click(object s, EventArgs e)
        {
            tutorID = "";

            first.Clear();
            last.Clear();
            contact.Clear();
            username.Clear();
            password.Clear();

            username.Enabled = true;
            password.Enabled = true;

            average.Value = 0;

            qualifications.DataSource = null;

            tutorsGrid.ClearSelection();
            tutorsGrid.CurrentCell = null;
        }

        private void save_Click(object s, EventArgs e)
        {
            try
            {
                tutorID = School.SaveTutor(
                    tutorID,
                    first.Text,
                    last.Text,
                    contact.Text,
                    (double)average.Value,
                    mode.Text,
                    username.Text,
                    password.Text);

                password.Clear();

                username.Enabled = false;
                password.Enabled = false;

                Reload();

                MessageBox.Show(
                    "Tutor saved. Assign qualified courses and availability below.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to save tutor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving the tutor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void availability_Click(object s, EventArgs e)
        {
            if (tutorID.Length == 0)
            {
                MessageBox.Show("Select or save a tutor first.");
                return;
            }

            try
            {
                ShellForm.Current.OpenPage(
                    "Availability: " + tutorID + " - " + first.Text + " " + last.Text,
                    () => new AvailabilityForm { TutorID = tutorID });
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to open availability",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while opening tutor availability.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void qualify_Click(object s, EventArgs e)
        {
            if (tutorID.Length == 0)
            {
                MessageBox.Show("Select or save a tutor first.");
                return;
            }

            if (course.SelectedValue == null)
            {
                MessageBox.Show("Select a course first.");
                return;
            }

            try
            {
                School.Qualify(tutorID, course.SelectedValue.ToString());

                Reload();

                MessageBox.Show("Course assigned to the tutor.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to assign course",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while assigning the course.",
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
                MessageBox.Show("An error occurred while refreshing tutor information.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tutorsGrid_CellClick(object s, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataRowView selectedRow =
                    tutorsGrid.CurrentRow.DataBoundItem as DataRowView;

                if (selectedRow == null)
                    return;

                tutorID = selectedRow["TutorID"].ToString();

                DataTable tutorDetails = Db.Query(
                    "SELECT * FROM Tutor WHERE TutorID=?", tutorID);

                if (tutorDetails.Rows.Count == 0)
                {
                    MessageBox.Show("The selected tutor could not be found.");
                    return;
                }

                DataRow row = tutorDetails.Rows[0];

                first.Text = row["FirstName"].ToString();
                last.Text = row["LastName"].ToString();
                contact.Text = row["ContactInformation"].ToString();
                average.Value = Convert.ToDecimal(row["AcademicAverage"]);
                mode.SelectedItem = row["TutoringMode"].ToString();

                username.Text = "Existing account";
                password.Clear();

                username.Enabled = false;
                password.Enabled = false;

                qualifications.DataSource = Db.Query(
                    "SELECT CourseCode, VerificationDate FROM TutorQualification WHERE TutorID=?",
                    tutorID);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to load tutor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while loading tutor details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void first_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

