using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YazılımSınama_ODEV1.CustomComponents
{
    public class SelectedItemShower : Button
    {
        public SelectedItemShower()
        {
            BackColor = Color.FromArgb(170,255, 0, 0);
            FlatStyle = FlatStyle.Flat;
            Text = "SELECTED";
            Enabled = false;
            Dock = DockStyle.Top;
            Font = new Font("Arial", 10, FontStyle.Bold);
        }
    }
}
