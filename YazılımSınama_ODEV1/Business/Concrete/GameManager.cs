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
        private MapManager mapManager;
        private LevelManager levelManager;
        private TableLayoutPanel tableLayout;
        private mainForm mainForm;
        private int levelSize;
        private int stoneCount;
        public int Level { get; set; }
        public bool IsObjectSelected { get; set; }
        public Point SelectedPosition { get; set; }
        public Point MainStonePosition { get; private set; }


        private GameStates _gameState;
        public GameStates GameState { get => _gameState; set { _gameState = value; OnGameStateChanged(_gameState); } }


        /// <summary>
        /// Initiliazes the game, generates level, and draws map.
        /// </summary>
        public GameManager(int stoneCount, int levelSize, TableLayoutPanel tableLayout, mainForm mainForm)
        {
            this.stoneCount = stoneCount;
            this.mainForm = mainForm;
            this.levelSize = levelSize;
            this.tableLayout = tableLayout;
            this.Level = 1;
            Init();
        }

        private void Init()
        {
            this.SetGameState(GameStates.Started);
            levelManager = new LevelManager();
            MapArray = levelManager.GenerateRandomLevel(stoneCount, levelSize, levelSize);
            mapManager = new MapManager(MapArray, tableLayout);
            MainStonePosition = mapManager.GetMainStonePos();
            this.SetShortestDistances();
            mapManager.DrawMap();
            IsObjectSelected = false;
        }


        public void MoveStone(Point oldPosition, Point newPosition)
        {
            if (_gameState != GameStates.Started)
                return;

            if (!IsStone(oldPosition))
                return;

            if (MapArray.GetLength(0) <= newPosition.Y || MapArray.GetLength(1) <= newPosition.X)
                return;

            if (MapArray[newPosition.Y, newPosition.X].MapObjectType != MapObjectType.Empty && MapArray[newPosition.Y, newPosition.X].MapObjectType != MapObjectType.MainStone)
                return;

            if (!MoveIsDirectional(oldPosition, newPosition))
                return;

            if (MathManager.FindDistanceBetweenTwoPoint(oldPosition, newPosition) != 1)
                return;



            var tempObj = MapArray[oldPosition.Y, oldPosition.X];

            if (tempObj.ShortestDistanceToMainStone <= 0)
            {
                return;
            }

            if (MapArray[newPosition.Y, newPosition.X].MapObjectType == MapObjectType.MainStone)
            {
                CollectStone(tempObj);
            }
            else
            {
                tempObj.ShortestDistanceToMainStone--;
                MapArray[oldPosition.Y, oldPosition.X] = MapArray[newPosition.Y, newPosition.X];
                MapArray[newPosition.Y, newPosition.X] = tempObj;
                if (tempObj.ShortestDistanceToMainStone == 0)
                {
                    SetGameState(GameStates.GameOver);
                }
            }

            mapManager.DrawMap();
        }

        private void SetShortestDistances()
        {
            for (int i = 0; i < MapArray.GetLength(0); i++)
            {
                for (int j = 0; j < MapArray.GetLength(1); j++)
                {
                    if (MapArray[i, j].MapObjectType == MapObjectType.Stone)
                    {
                        PathFinding pathFinding = new PathFinding(MapArray);
                        var shortestDistance = pathFinding.FindShortestDistance(new Point(j, i), MainStonePosition);
                        MapArray[i, j].ShortestDistanceToMainStone = shortestDistance;
                    }
                }
            }
        }

        public bool IsStone(Point pos)
        {
            return MapArray[pos.Y, pos.X].MapObjectType == MapObjectType.Stone;
        }

        private void CollectStone(MapObject stoneToBeCollected)
        {
            stoneToBeCollected.MapObjectType = MapObjectType.Empty;
            stoneToBeCollected.ShortestDistanceToMainStone = null;
            if (mapManager.GetUncollectedStoneCount() == 0)
            {
                this.SetGameState(GameStates.Won);
            }

        }

        private bool MoveIsDirectional(Point oldPosition, Point newPosition)
        {
            return ((oldPosition.X == newPosition.X && oldPosition.Y != newPosition.Y) || (oldPosition.X != newPosition.X && oldPosition.Y == newPosition.Y));
        }

        private void SetGameState(GameStates gameState)
        {
            GameState = gameState;

        }

        private void OnGameStateChanged(GameStates newGameState)
        {

            switch (newGameState)
            {
                case (GameStates.GameOver):
                    var result = MessageBox.Show("Game over, click OK for start new game!", "Game Over", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    this.Level = 1;
                    this.stoneCount +=(this.Level+6 - this.stoneCount);
                    this.mainForm.lblLevel.Text = "LEVEL: " + this.Level.ToString();
                    if (result == DialogResult.OK)
                        Init();
                    break;
                case (GameStates.Won):
                    var wonResult = MessageBox.Show("You won, click OK for start next level!", "Game Over", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (wonResult == DialogResult.OK)
                    {
                        this.stoneCount++;
                        this.Level++;
                        this.mainForm.lblLevel.Text = "LEVEL: " + this.Level.ToString();
                        Init();
                    }
                    break;
                case (GameStates.Started):
                    this.mainForm.lblLevel.Text = "LEVEL: " + this.Level.ToString();
                    break;
            }

        }


    }
}
