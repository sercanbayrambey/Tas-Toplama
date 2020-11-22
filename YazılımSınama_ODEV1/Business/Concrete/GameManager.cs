using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YazılımSınama_ODEV1.Business.Static;
using YazılımSınama_ODEV1.Entities;

namespace YazılımSınama_ODEV1.Business.Concrete
{
    public class GameManager
    {
        public MapObject[,] MapArray { get; set; }
        private readonly MapManager mapManager;
        private readonly LevelManager levelManager;
        private readonly TableLayoutPanel tableLayout;
        public bool IsObjectSelected { get; set; }
        public Point SelectedPosition { get; set; }


        /// <summary>
        /// Initiliazes the game, generates level, and draws map.
        /// </summary>
        public GameManager(int stoneCount, int levelSize, TableLayoutPanel tableLayout)
        {
            levelManager = new LevelManager();
            MapArray = levelManager.GenerateRandomLevel(stoneCount, levelSize, levelSize);
            mapManager = new MapManager(MapArray);
            this.tableLayout = tableLayout;
            mapManager.DrawMap(tableLayout);
            IsObjectSelected = false;
        }


        public void MoveStone(Point oldPosition, Point newPosition)
        {
            if (!IsStone(oldPosition))
                return;
            if (MapArray.GetLength(0) <= newPosition.Y || MapArray.GetLength(1) <= newPosition.X)
                return;

            if (MapArray[newPosition.Y, newPosition.X].MapObjectType != MapObjectType.Empty && MapArray[newPosition.Y, newPosition.X].MapObjectType != MapObjectType.MainStone)
                return;

            if (MathManager.FindDistanceBetweenTwoPoint(oldPosition, newPosition) != 1)
                return;


            var tempObj = MapArray[oldPosition.Y, oldPosition.X];

            if (tempObj.ShortestDistanceToMainStone <= 0)
                return;

            if (MapArray[newPosition.Y, newPosition.X].MapObjectType == MapObjectType.MainStone)
            {
                tempObj.MapObjectType = MapObjectType.Empty;
                tempObj.ShortestDistanceToMainStone = null;
            }
            else
            {
                tempObj.ShortestDistanceToMainStone--;
                MapArray[oldPosition.Y, oldPosition.X] = MapArray[newPosition.Y, newPosition.X];
                MapArray[newPosition.Y, newPosition.X] = tempObj;
            }

            mapManager.DrawMap(tableLayout);
        }

        public bool IsStone(Point pos)
        {
            return MapArray[pos.Y, pos.X].MapObjectType == MapObjectType.Stone;
        }
    }
}
