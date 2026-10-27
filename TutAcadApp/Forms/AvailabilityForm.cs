using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class AvailabilityForm : Form
    {
        public string TutorID { get; set; }

        public AvailabilityForm()
        {
            InitializeComponent();

            Ui.Behave(this);

            periods.KeyUp += periods_KeyUp;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (View.Design)
                return;

            try
            {
                School.AvailabilityAccess(TutorID);

                DataTable tutor = Db.Query(
                    "SELECT FirstName, LastName FROM Tutor WHERE TutorID = ?",
                    TutorID
                );

                if (tutor.Rows.Count != 1)
                {
                    MessageBox.Show("Tutor not found.");
                    Close();
                    return;
                }

                tutorName.Text = tutor.Rows[0]["FirstName"] + " " +
                                 tutor.Rows[0]["LastName"] + " | " + TutorID;

                start.Value = DateTime.Today.AddDays(3).AddHours(8);
                end.Value = start.Value.AddHours(9);

                Reload();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("A database error occurred while loading availability: "
                    + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("The availability form could not complete the operation: "
                    + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading availability: "
                    + ex.Message);
            }
        }

        private void Reload()
        {
            periods.DataSource = School.Availability(TutorID);
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                School.SaveAvailability(
                    TutorID,
                    0,
                    start.Value,
                    end.Value,
                    false
                );

                Reload();

                MessageBox.Show("Availability saved.");
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("A database error occurred while saving availability: "
                    + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to save availability in its current state: "
                    + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while saving availability: "
                    + ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (periods.CurrentRow == null)
            {
                MessageBox.Show("Please select an availability period to update.");
                return;
            }

            try
            {
                int availabilityID = Convert.ToInt32(
                    periods.CurrentRow.Cells["AvailabilityID"].Value
                );

                School.SaveAvailability(
                    TutorID,
                    availabilityID,
                    start.Value,
                    end.Value,
                    false
                );

                Reload();

                MessageBox.Show("Availability saved.");
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("A database error occurred while updating availability: "
                    + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to update availability in its current state: "
                    + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("The selected availability ID is not in a valid format: "
                    + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating availability: "
                    + ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (periods.CurrentRow == null)
            {
                MessageBox.Show("Please select an availability period to remove.");
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Remove this availability period?",
                "Confirm removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (answer == DialogResult.Yes)
            {
                try
                {
                    int availabilityID = Convert.ToInt32(
                        periods.CurrentRow.Cells["AvailabilityID"].Value
                    );

                    School.SaveAvailability(
                        TutorID,
                        availabilityID,
                        start.Value,
                        end.Value,
                        true
                    );

                    Reload();

                    MessageBox.Show("Availability period removed.");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("A database error occurred while removing availability: "
                        + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Unable to remove availability in its current state: "
                        + ex.Message);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("The selected availability ID is not in a valid format: "
                        + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred while removing availability: "
                        + ex.Message);
                }
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                Reload();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("A database error occurred while refreshing availability: "
                    + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to refresh availability in its current state: "
                    + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while refreshing availability: "
                    + ex.Message);
            }
        }

        private void periods_KeyUp(object sender, KeyEventArgs e)
        {
            if (periods.CurrentRow != null)
            {
                LoadSelectedPeriod();
            }
        }

        private void periods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            LoadSelectedPeriod();
        }

        private void LoadSelectedPeriod()
        {
            if (periods.CurrentRow == null)
                return;

            try
            {
                start.Value = Convert.ToDateTime(
                    periods.CurrentRow.Cells["StartAt"].Value
                );

                end.Value = Convert.ToDateTime(
                    periods.CurrentRow.Cells["EndAt"].Value
                );
            }
            catch (FormatException ex)
            {
                MessageBox.Show("The selected availability dates are not in a valid format: "
                    + ex.Message);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("The selected availability dates have an unexpected data type: "
                    + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("The selected dates are outside the allowed date range: "
                    + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the selected availability period: "
                    + ex.Message);
            }
        }
    }
}

