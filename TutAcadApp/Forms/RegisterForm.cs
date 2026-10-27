using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            Ui.Behave(this);

            AcceptButton = save;

            faculty.SelectedIndexChanged += faculty_SelectedIndexChanged;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (View.Design)
                return;

            birth.MinDate = new DateTime(1900, 1, 1);
            birth.MaxDate = DateTime.Today.AddYears(-17);
            birth.Value = birth.MaxDate;
            birth.ShowCheckBox = true;
            birth.Checked = false;

            birthLabel.Text = "Date of birth * (17 or older)";

            number.MaxLength = 10;

            faculty.Items.AddRange(Auth.Faculties());
            faculty.SelectedIndex = -1;

            programme.Enabled = false;
        }

        private void faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            programme.Items.Clear();
            programme.SelectedIndex = -1;

            if (faculty.SelectedIndex >= 0)
            {
                programme.Enabled = true;
                programme.Items.AddRange(Auth.Programmes(faculty.Text));
            }
            else
            {
                programme.Enabled = false;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (birth.Checked == false)
            {
                MessageBox.Show("Select your date of birth.");
                return;
            }

            if (faculty.SelectedIndex == -1)
            {
                MessageBox.Show("Select a faculty.");
                return;
            }

            if (programme.SelectedIndex == -1)
            {
                MessageBox.Show("Select a programme of study.");
                return;
            }

            if (string.IsNullOrWhiteSpace(number.Text))
            {
                MessageBox.Show("Enter your student number.");
                number.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(first.Text))
            {
                MessageBox.Show("Enter your first name.");
                first.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(last.Text))
            {
                MessageBox.Show("Enter your last name.");
                last.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contact.Text))
            {
                MessageBox.Show("Enter your contact details.");
                contact.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Enter a password.");
                password.Focus();
                return;
            }

            if (password.Text != confirm.Text)
            {
                MessageBox.Show("Passwords do not match.");
                confirm.Focus();
                return;
            }

            try
            {
                Auth.Register(
                    number.Text.Trim(),
                    first.Text.Trim(),
                    last.Text.Trim(),
                    contact.Text.Trim(),
                    faculty.Text,
                    programme.Text,
                    birth.Value,
                    password.Text
                );

                MessageBox.Show(
                    "Account created. Sign in with your student number and password."
                );

                Close();
            }
            catch (OleDbException)
            {
                MessageBox.Show(
                    "Unable to create the account because of a database error. " +
                    "Please check your details or try again later."
                );
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "An unexpected error occurred while creating the account. " +
                    "Please try again later."
                );
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}