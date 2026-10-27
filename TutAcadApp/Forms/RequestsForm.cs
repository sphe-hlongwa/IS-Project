using System;
using System.Data;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class RequestsForm : Form
    {
        private string searchedRequest = "";

        public RequestsForm()
        {
            InitializeComponent();
            Ui.Behave(this);
            find.Enabled = false;
            match.Enabled = false;

            start.ValueChanged += (s, e) => InvalidateSearch();
            end.ValueChanged += (s, e) => InvalidateSearch();
            requests.SelectionChanged += (s, e) => InvalidateSearch();
        }

        private void Form_Load(object s, EventArgs e)
        {
            if (View.Design)
                return;

            try
            {
                Auth.Need("Administrator");

                start.Value = DateTime.Today.AddDays(3).AddHours(10);
                end.Value = start.Value.AddHours(1);

                Reload();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Access denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while opening support requests.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InvalidateSearch()
        {
            find.Enabled =
                requests.CurrentRow != null &&
                requests.CurrentRow.Selected &&
                requests.CurrentRow.DataBoundItem is DataRowView &&
                ((DataRowView)requests.CurrentRow.DataBoundItem)
                    .Row["Status"].ToString() == "Submitted";

            searchedRequest = "";
            tutor.DataSource = null;
            match.Enabled = false;

            note.Text = "Select a submitted request and choose dates, then find available tutors.";
        }

        private void Reload()
        {
            requests.DataSource = School.Requests();
        }

        private void find_Click(object s, EventArgs e)
        {
            try
            {
                if (requests.CurrentRow == null ||
                    !requests.CurrentRow.Selected ||
                    !(requests.CurrentRow.DataBoundItem is DataRowView))
                {
                    MessageBox.Show("Select a request first.");
                    return;
                }

                DataRow row =
                    ((DataRowView)requests.CurrentRow.DataBoundItem).Row;

                if (row["Status"].ToString() != "Submitted")
                {
                    MessageBox.Show("Select a Submitted request.");
                    return;
                }

                searchedRequest = row["RequestID"].ToString();

                DataTable availableTutors = School.FindTutors(
                    row["CourseCode"].ToString(),
                    start.Value,
                    end.Value);

                tutor.DataSource = availableTutors;
                tutor.DisplayMember = "TutorName";
                tutor.ValueMember = "TutorID";

                match.Enabled = availableTutors.Rows.Count > 0;

                if (availableTutors.Rows.Count == 0)
                {
                    note.Text = "No suitable tutor is available. Try another time; the request remains Submitted.";
                }
                else
                {
                    note.Text = availableTutors.Rows.Count +
                        " tutor(s) available for " + searchedRequest;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to find tutors",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while searching for available tutors.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void match_Click(object s, EventArgs e)
        {
            try
            {
                if (requests.CurrentRow == null ||
                    !(requests.CurrentRow.DataBoundItem is DataRowView))
                {
                    MessageBox.Show("Select a request first.");
                    return;
                }

                string id = ((DataRowView)requests.CurrentRow.DataBoundItem)
                    .Row["RequestID"].ToString();

                if (id != searchedRequest)
                {
                    MessageBox.Show("Find suitable tutors for the selected request first.");
                    return;
                }

                if (tutor.SelectedValue == null)
                {
                    MessageBox.Show("Select an available tutor.");
                    return;
                }

                School.Match(
                    id,
                    tutor.SelectedValue.ToString(),
                    start.Value,
                    end.Value);

                searchedRequest = "";
                tutor.DataSource = null;

                Reload();

                MessageBox.Show("Request verified and session booked.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to match request",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while matching the request.",
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
                MessageBox.Show("An error occurred while refreshing support requests.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

