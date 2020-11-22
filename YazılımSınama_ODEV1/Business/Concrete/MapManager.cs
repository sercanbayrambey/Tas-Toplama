using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YazılımSınama_ODEV1.Business.Static;
using YazılımSınama_ODEV1.Entities;

namespace YazılımSınama_ODEV1.Business.Concrete
{
    public class MapManager
    {
        public int Height { get; }
        public int Width { get; }
        public int CellSize { get; }
        public MapObject[,] MapArray { get; set; }
        private TableLayoutPanel _tableLayoutPanel;

        public MapManager(MapObject[,] mapArray)
        {
            Height = mapArray.GetLength(0);
            Width = mapArray.GetLength(1);
            MapArray = mapArray;
        }




        public void DrawMap(TableLayoutPanel tableLayoutPanel)
        {
            _tableLayoutPanel = tableLayoutPanel;
            tableLayoutPanel.CellPaint += new TableLayoutCellPaintEventHandler(this.Board_CellPaint);
            tableLayoutPanel.ColumnCount = Width;
            tableLayoutPanel.RowCount = Height;
            tableLayoutPanel.Controls.Clear();


        }

        private void Board_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

            for (int i = 0; i < MapArray.GetLength(0); i++)
            {
                for (int j = 0; j < MapArray.GetLength(1); j++)
                {
                    int mapObjectValue = MapArray[i, j].MapObjectType;
                    if (e.Column == j && e.Row == i)
                    {
                        switch (mapObjectValue)
                        {
                            case (MapObjectType.Empty):
                                break;
                            case (MapObjectType.Block):
                                e.Graphics.DrawImage(Properties.Resources.block, e.CellBounds);
                             
                                break;
                            case (MapObjectType.MainStone):
                                e.Graphics.DrawImage(Properties.Resources.bilye_red, e.CellBounds);
                                break;
                            case (MapObjectType.Stone):
                                e.Graphics.DrawImage(Properties.Resources.bilye_blue, e.CellBounds);
                                StringFormat sf = new StringFormat();
                                sf.LineAlignment = StringAlignment.Center;
                                sf.Alignment = StringAlignment.Center;
                                e.Graphics.DrawString(MapArray[i,j].ShortestDistanceToMainStone.ToString(), new Font("Times New Roman", 35, FontStyle.Bold), Brushes.White, e.CellBounds.X + 65, e.CellBounds.Y + 40, sf);
                                break;
                        }
                    }


                }
            }

        }

    }
}
