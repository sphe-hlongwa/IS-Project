using System;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            Ui.Behave(this);
            AcceptButton = save;
        }

        private void Form_Load(object s, EventArgs e)
        {
        }

        private void save_Click(object s, EventArgs e)
        {
            if (password.Text != confirm.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                Auth.ChangePassword(old.Text, password.Text);

                MessageBox.Show("Password changed.");

                old.Clear();
                password.Clear();
                confirm.Clear();

                Ui.ReturnHome(this);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Unable to change password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while changing your password. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_Click(object s, EventArgs e)
        {
            old.Clear();
            password.Clear();
            confirm.Clear();

            Ui.ReturnHome(this);
        }
    }
}

