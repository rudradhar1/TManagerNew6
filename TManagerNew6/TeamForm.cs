using System;
using System.Data;
using System.Windows.Forms;

namespace TManagerNew6
{
    public partial class TeamForm : Form
    {
        TextBox txtTeam = new TextBox();
        Button btnAdd = new Button();
        ListBox listTeams = new ListBox();
        Button btnMatch = new Button();
        Button btnPoint = new Button();

        public TeamForm()
        {
            this.Text = "Teams";
            this.Size = new System.Drawing.Size(400, 300);

            txtTeam.Top = 20; txtTeam.Left = 20; txtTeam.Width = 200;

            btnAdd.Text = "Add Team";
            btnAdd.Top = 20; btnAdd.Left = 240;
            btnAdd.Click += BtnAdd_Click;

            listTeams.Top = 60;
            listTeams.Left = 20;
            listTeams.Width = 200;
            listTeams.Height = 150;

            btnMatch.Text = "Match Result";
            btnMatch.Top = 60; btnMatch.Left = 240;
            btnMatch.Click += (s, e) => new MatchForm().Show();

            btnPoint.Text = "Point Table";
            btnPoint.Top = 100; btnPoint.Left = 240;
            btnPoint.Click += (s, e) => new PointTableForm().Show();

            Controls.Add(txtTeam);
            Controls.Add(btnAdd);
            Controls.Add(listTeams);
            Controls.Add(btnMatch);
            Controls.Add(btnPoint);

            LoadTeams();
        }

        void LoadTeams()
        {
            listTeams.Items.Clear();
            DataTable dt = DB.GetData(
                $"SELECT TeamName FROM Team WHERE TournamentId={TournamentForm.TournamentId}");

            foreach (DataRow r in dt.Rows)
                listTeams.Items.Add(r["TeamName"].ToString());
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DB.Execute(
                $"INSERT INTO Team VALUES({TournamentForm.TournamentId},'{txtTeam.Text}')");
            txtTeam.Clear();
            LoadTeams();
        }
    }
}
