using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class BookingsForm : Form
    {
        public BookingsForm()
        {
            InitializeComponent();

            Ui.Behave(this);

            book.Enabled = false;
            update.Enabled = false;
            cancel.Enabled = false;
            rate.Enabled = false;

            course.SelectedValueChanged += (s, e) => InvalidateSearch();
            start.ValueChanged += (s, e) => InvalidateSearch();
            end.ValueChanged += (s, e) => InvalidateSearch();

            sessions.SelectionChanged += (s, e) => SelectBooking();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (View.Design)
                return;

            try
            {
                Auth.Need("Student");

                DataTable courses = School.Courses();

                course.DataSource = courses;
                course.DisplayMember = "CourseName";
                course.ValueMember = "CourseCode";
                course.SelectedIndex = -1;

                support.Items.AddRange(new object[]
                {
                    "Content clarification",
                    "Exam preparation",
                    "Assignment assistance",
                    "Study skills"
                });

                support.SelectedIndex = 0;

                start.Value = DateTime.Today.AddDays(3).AddHours(10);
                end.Value = start.Value.AddHours(1);

                Reload();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while loading bookings: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to load the booking form in its current state: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while loading bookings: " + ex.Message
                );
            }
        }

        private void InvalidateSearch()
        {
            tutor.DataSource = null;
            book.Enabled = false;

            availabilityNote.Text =
                "Choose a course and time, then find available tutors.";
        }

        private void SelectBooking()
        {
            update.Enabled = false;
            cancel.Enabled = false;
            rate.Enabled = false;

            selectionNote.Text =
                "Select a booking to view its dates and available actions.";

            if (sessions.CurrentRow == null ||
                !sessions.CurrentRow.Selected ||
                !(sessions.CurrentRow.DataBoundItem is DataRowView))
            {
                return;
            }

            DataRow row = ((DataRowView)sessions.CurrentRow.DataBoundItem).Row;

            editStart.Value = Convert.ToDateTime(row["StartTime"]);
            editEnd.Value = Convert.ToDateTime(row["EndTime"]);

            if (row["Feedback"] == DBNull.Value)
                rating.Value = 0;
            else
                rating.Value = Convert.ToDecimal(row["Feedback"]);

            bool change =
                row["AttendanceStatus"].ToString() == "Scheduled" &&
                editStart.Value >= DateTime.Now.AddHours(48);

            update.Enabled = change;
            cancel.Enabled = change;

            rate.Enabled =
                row["AttendanceStatus"].ToString() == "Completed";

            selectionNote.Text =
                "Booking " + row["SessionID"] + " • " +
                row["AttendanceStatus"] + ". " +
                (change
                    ? "You can change the dates or cancel this booking."
                    : rate.Enabled
                        ? "You can save a feedback rating for this completed session."
                        : "Changes are unavailable for this status or within 48 hours of the start.");
        }

        private void Reload()
        {
            sessions.DataSource = School.Sessions();
            requestsGrid.DataSource = School.Requests();
        }

        private void find_Click(object sender, EventArgs e)
        {
            InvalidateSearch();

            if (course.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            if (end.Value <= start.Value)
            {
                MessageBox.Show("The end time must be after the start time.");
                return;
            }

            try
            {
                DataTable availableTutors = School.FindTutors(
                    course.SelectedValue.ToString(),
                    start.Value,
                    end.Value
                );

                tutor.DataSource = availableTutors;
                tutor.DisplayMember = "TutorName";
                tutor.ValueMember = "TutorID";

                if (availableTutors.Rows.Count > 0)
                    tutor.SelectedIndex = 0;

                book.Enabled = availableTutors.Rows.Count > 0;

                if (availableTutors.Rows.Count == 0)
                {
                    availabilityNote.Text =
                        "No suitable tutor is available. Try another time or submit a support request below.";
                }
                else
                {
                    availabilityNote.Text =
                        availableTutors.Rows.Count +
                        " tutor(s) available. Availability will be rechecked when saving.";
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while finding tutors: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to search for tutors in the current state: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while finding tutors: " + ex.Message
                );
            }
        }

        private void book_Click(object sender, EventArgs e)
        {
            if (course.SelectedIndex < 0 || tutor.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a course and an available tutor.");
                return;
            }

            if (end.Value <= start.Value)
            {
                MessageBox.Show("The end time must be after the start time.");
                return;
            }

            try
            {
                string sessionID = School.Book(
                    course.SelectedValue.ToString(),
                    tutor.SelectedValue.ToString(),
                    support.Text,
                    start.Value,
                    end.Value
                );

                InvalidateSearch();
                Reload();

                MessageBox.Show("Session booked: " + sessionID);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while booking the session: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to book this session. The availability or booking status may have changed: "
                    + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while booking the session: " + ex.Message
                );
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (sessions.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking to update.");
                return;
            }

            if (editEnd.Value <= editStart.Value)
            {
                MessageBox.Show("The end time must be after the start time.");
                return;
            }

            try
            {
                string sessionID =
                    sessions.CurrentRow.Cells["SessionID"].Value.ToString();

                School.Change(
                    sessionID,
                    editStart.Value,
                    editEnd.Value,
                    false
                );

                Reload();

                MessageBox.Show("Booking dates updated.");
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while updating the booking: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to update the booking in its current state: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while updating the booking: " + ex.Message
                );
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (sessions.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking to cancel.");
                return;
            }

            string sessionID =
                sessions.CurrentRow.Cells["SessionID"].Value.ToString();

            DialogResult answer = MessageBox.Show(
                "Cancel booking " + sessionID + "?",
                "Confirm cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (answer == DialogResult.Yes)
            {
                try
                {
                    School.Change(
                        sessionID,
                        editStart.Value,
                        editEnd.Value,
                        true
                    );

                    Reload();

                    MessageBox.Show(
                        "Booking cancelled. The time slot is available again."
                    );
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(
                        "A database error occurred while cancelling the booking: "
                        + ex.Message
                    );
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(
                        "Unable to cancel the booking in its current state: " + ex.Message
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "An unexpected error occurred while cancelling the booking: "
                        + ex.Message
                    );
                }
            }
        }

        private void rate_Click(object sender, EventArgs e)
        {
            if (sessions.CurrentRow == null)
            {
                MessageBox.Show("Please select a completed session to rate.");
                return;
            }

            try
            {
                string sessionID =
                    sessions.CurrentRow.Cells["SessionID"].Value.ToString();

                School.Feedback(sessionID, (double)rating.Value);

                Reload();

                MessageBox.Show("Your feedback rating was saved.");
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while saving feedback: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to save feedback in the current state: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while saving feedback: " + ex.Message
                );
            }
        }

        private void request_Click(object sender, EventArgs e)
        {
            if (course.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            try
            {
                School.SubmitRequest(
                    course.SelectedValue.ToString(),
                    support.Text,
                    preferred.Text.Trim()
                );

                preferred.Clear();

                Reload();

                MessageBox.Show(
                    "Request submitted. An administrator can match you with a tutor."
                );
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while submitting the request: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to submit the request in the current state: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while submitting the request: "
                    + ex.Message
                );
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
                MessageBox.Show(
                    "A database error occurred while refreshing the lists: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to refresh the lists in the current state: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while refreshing the lists: " + ex.Message
                );
            }
        }

        private void sessions_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                SelectBooking();
        }
    }
}

