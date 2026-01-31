using System.Data;
using System.Windows.Forms;

namespace TManagerNew6
{
    public partial class PointTableForm : Form
    {
        DataGridView grid = new DataGridView();

        public PointTableForm()
        {
            this.Text = "Point Table";
            this.Size = new System.Drawing.Size(400, 300);

            grid.Dock = DockStyle.Fill;
            Controls.Add(grid);

            LoadPoint();
        }
        /// <summary>
        /// //
        /// </summary>
        void LoadPoint()
        {
            DataTable dt = DB.GetData(
                $"SELECT Winner AS Team, COUNT(*) AS Points " +
                $"FROM MatchResult WHERE TournamentId={TournamentForm.TournamentId} " +
                $"GROUP BY Winner");

            grid.DataSource = dt;
        }
    }
}
//test git