using System;
using System.Windows.Forms;

namespace TManagerNew6
{
    public partial class LoginForm : Form
    {
        TextBox txtUser = new TextBox();
        TextBox txtPass = new TextBox();
        Button btnLogin = new Button();

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Login";
            this.Size = new System.Drawing.Size(300, 250);

            txtUser.Top = 30; txtUser.Left = 50; txtUser.Width = 200;
            txtPass.Top = 70; txtPass.Left = 50; txtPass.Width = 200;
            txtPass.PasswordChar = '*';

            btnLogin.Text = "Login";
            btnLogin.Top = 120; btnLogin.Left = 90;
            btnLogin.Click += BtnLogin_Click;

            Controls.Add(txtUser);
            Controls.Add(txtPass);
            Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var dt = DB.GetData(
                $"SELECT * FROM Users WHERE Username='{txtUser.Text}' AND Password='{txtPass.Text}'");

            if (dt.Rows.Count > 0)
            {
                new TournamentForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Login");
            }
        }
    }
}
