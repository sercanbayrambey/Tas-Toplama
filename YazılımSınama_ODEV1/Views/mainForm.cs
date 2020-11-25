using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımSınama_ODEV1.Business.Concrete;
using YazılımSınama_ODEV1.CustomComponents;

namespace YazılımSınama_ODEV1
{
    public partial class mainForm : Form
    {
        private GameManager gameManager;
        private SelectedItemShower selectedButton = new SelectedItemShower();
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            gameManager = new GameManager(7, 8, Board, this);
            Console.WriteLine("test");
            SetDoubleBuffered(Board);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameManager.Dispose();
            gameManager = new GameManager(7, 8, Board,this);
        }


        Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }

        private void Board_Click(object sender, EventArgs e)
        {
            var cellPos = GetRowColIndex(
                        Board,
                         Board.PointToClient(Cursor.Position));

            if (!gameManager.IsObjectSelected)
            {
                if (!gameManager.IsStone(cellPos.Value))
                    return;
                gameManager.IsObjectSelected = true;
                selectedButton = new SelectedItemShower();
                Board.Controls.Add(selectedButton, cellPos.Value.X, cellPos.Value.Y);
                gameManager.IsObjectSelected = true;
                gameManager.SelectedPosition = cellPos.Value;
                GC.Collect();
            }
            else
            {
                gameManager.IsObjectSelected = false;
                Board.Controls.Clear();
                gameManager.MoveStone(gameManager.SelectedPosition, cellPos.Value);
                gameManager.IsObjectSelected = false;
            }
        }

        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }


        public void UpdateLevelText()
        {
            this.lblLevel.Text = "LEVEL: " + gameManager.Level.ToString();
        }
    }
}
