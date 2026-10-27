using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TutAcadSupport
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Ui.Behave(this);
            AcceptButton = login;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (View.Design)
                return;

            connection.Text =
                "Sign in to manage your tutorial sessions. " +
                "New students can create an account.";
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                MessageBox.Show("Please enter your username or student number.");
                username.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Please enter your password.");
                password.Focus();
                return;
            }

            try
            {
                Auth.Login(username.Text.Trim(), password.Text);

                password.Clear();
                Hide();

                try
                {
                    using (ShellForm form = new ShellForm())
                    {
                        form.ShowDialog();
                    }
                }
                finally
                {
                    Auth.Logout();
                    Show();
                    username.Focus();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "A database error occurred while signing in: " + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Unable to complete the sign-in operation: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to sign in. Please check your details and try again.\n\n"
                    + ex.Message
                );
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            using (RegisterForm form = new RegisterForm())
            {
                form.ShowDialog(this);
            }
        }

        private void brandPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

