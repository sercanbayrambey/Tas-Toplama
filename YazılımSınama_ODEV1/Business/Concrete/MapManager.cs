using System;
using System.Drawing;
using System.Linq;
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
        private MapObject[,] _mapArray { get; set; }
        private TableLayoutPanel tableLayoutPanel;

        public MapManager(MapObject[,] mapArray, TableLayoutPanel _tableLayoutPanel)
        {
            Height = mapArray.GetLength(0);
            Width = mapArray.GetLength(1);
            _mapArray = mapArray;
            tableLayoutPanel = _tableLayoutPanel;
            tableLayoutPanel.CellPaint += new TableLayoutCellPaintEventHandler(this.Board_CellPaint);
        }

        public void DrawMap()
        {
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

            var column = e.Column;
            var row = e.Row;
            int mapObjectValue = _mapArray[row, column].MapObjectType;


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
                    e.Graphics.DrawString(_mapArray[row, column].ShortestDistanceToMainStone.ToString(), new Font("Times New Roman", 35, FontStyle.Bold), Brushes.White, e.CellBounds.X + 65, e.CellBounds.Y + 40, sf);
                    break;
            }

        }

        public Point GetMainStonePos()
        {

            for (int i = 0; i < _mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < _mapArray.GetLength(1); j++)
                {
                    if (_mapArray[i, j].MapObjectType == MapObjectType.MainStone)
                    {
                        return new Point(j, i);
                    }
                }
            }

            return new Point(0, 0);
        }

        public int GetUncollectedStoneCount()
        {
            int counter = 0;
            for (int i = 0; i < _mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < _mapArray.GetLength(1); j++)
                {
                    if (_mapArray[i, j].MapObjectType == MapObjectType.Stone)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

    }
}
