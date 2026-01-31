using System;
using System.Data;
using System.Windows.Forms;

namespace TManagerNew6
{
    public partial class MatchForm : Form
    {
        ComboBox cmbA = new ComboBox();
        ComboBox cmbB = new ComboBox();
        ComboBox cmbWin = new ComboBox();
        Button btnSave = new Button();

        public MatchForm()
        {
            this.Text = "Match Result";
            this.Size = new System.Drawing.Size(300, 250);

            cmbA.Top = 20; cmbA.Left = 20; cmbA.Width = 200;
            cmbB.Top = 60; cmbB.Left = 20; cmbB.Width = 200;
            cmbWin.Top = 100; cmbWin.Left = 20; cmbWin.Width = 200;

            btnSave.Text = "Save Result";
            btnSave.Top = 140; btnSave.Left = 20;
            btnSave.Click += BtnSave_Click;

            Controls.Add(cmbA);
            Controls.Add(cmbB);
            Controls.Add(cmbWin);
            Controls.Add(btnSave);

            LoadTeams();
        }

        void LoadTeams()
        {
            DataTable dt = DB.GetData(
                $"SELECT TeamName FROM Team WHERE TournamentId={TournamentForm.TournamentId}");

            foreach (DataRow r in dt.Rows)
            {
                cmbA.Items.Add(r["TeamName"]);
                cmbB.Items.Add(r["TeamName"]);
                cmbWin.Items.Add(r["TeamName"]);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DB.Execute(
                $"INSERT INTO MatchResult VALUES({TournamentForm.TournamentId},'{cmbA.Text}','{cmbB.Text}','{cmbWin.Text}')");

            MessageBox.Show("Match Result Saved");
        }
    }
}
