using System;
using System.Windows.Forms;

namespace TManagerNew6
{
    public partial class TournamentForm : Form
    {
        TextBox txtName = new TextBox();
        ListBox list = new ListBox();
        Button btnAdd = new Button();
        Button btnOpen = new Button();

        public static int TournamentId;

        public TournamentForm()
        {
            this.Text = "Tournament";
            this.Size = new System.Drawing.Size(400, 300);

            txtName.Top = 20; txtName.Left = 20; txtName.Width = 200;
            btnAdd.Text = "Add";
            btnAdd.Top = 20; btnAdd.Left = 240;
            btnAdd.Click += BtnAdd_Click;

            list.Top = 60; list.Left = 20; list.Width = 200;
            btnOpen.Text = "Open";
            btnOpen.Top = 60; btnOpen.Left = 240;
            btnOpen.Click += BtnOpen_Click;

            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(list);
            Controls.Add(btnOpen);

            LoadData();
        }

        void LoadData()
        {
            list.Items.Clear();
            var dt = DB.GetData("SELECT * FROM Tournament");
            foreach (System.Data.DataRow r in dt.Rows)
                list.Items.Add(r["Id"] + "-" + r["Name"]);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DB.Execute($"INSERT INTO Tournament VALUES('{txtName.Text}')");
            LoadData();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            TournamentId = int.Parse(list.SelectedItem.ToString().Split('-')[0]);
            new TeamForm().Show();
        }
    }
}
