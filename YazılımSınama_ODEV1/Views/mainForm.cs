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

namespace YazılımSınama_ODEV1
{
    public partial class mainForm : Form
    {
        private MapManager MapManager;
        private LevelManager LevelManager;
        public mainForm()
        {
            InitializeComponent();
            LevelManager = new LevelManager();
            MapManager = new MapManager(LevelManager.GenerateRandomLevel(3,8,8));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDoubleBuffered(Board);
            MapManager.DrawMap(Board);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MapManager = new MapManager(LevelManager.GenerateRandomLevel(3, 8, 8));
            MapManager.DrawMap(Board);
        }

    

        private void Board_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Cell chosen: (" +
                     Board.GetRow((Control)sender) + ", " +
                     Board.GetColumn((Control)sender) + ")");
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
    }
}
