using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using YazılımSınama_ODEV1.Business.Static;
using YazılımSınama_ODEV1.Entities;

namespace YazılımSınama_ODEV1.Business.Concrete
{
    public class LevelManager
    {
        public int Height { get;}
        public int Width { get;}
        public MapObject[,] GenerateRandomLevel(int stoneCount, int height, int width)
        {

            MapObject[,] mapArray = new MapObject[height,width];

            Random rnd = new Random();
            for(int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    mapArray[i, j] = new MapObject();
                }
            }

            var mainStonePos = new Point(rnd.Next(0, mapArray.GetLength(1)), rnd.Next(0, mapArray.GetLength(0)));
            mapArray[mainStonePos.Y,mainStonePos.X].MapObjectType = MapObjectType.MainStone;


            int rndBlockCount = rnd.Next(7, 11);

            for (int i = 0; i < rndBlockCount; i++)
            {
                int rndX = rnd.Next(0, mapArray.GetLength(0));
                int rndY = rnd.Next(0, mapArray.GetLength(1));
                if (mapArray[rndY, rndX].MapObjectType == MapObjectType.Empty)
                    mapArray[rndY, rndX].MapObjectType = MapObjectType.Block;
                else
                    i--;
            }

            for (int i = 0; i < stoneCount; i++)
            {
                int rndX = rnd.Next(0, mapArray.GetLength(0));
                int rndY = rnd.Next(0, mapArray.GetLength(1));
                if (mapArray[rndY, rndX].MapObjectType == MapObjectType.Empty)
                {
                    PathFinding pathFinding = new PathFinding(mapArray);
                    if(pathFinding.FindShortestDistance(new Point(rndX,rndY),mainStonePos) == 0)
                    {
                        i--;
                        continue;
                    }
                    mapArray[rndY, rndX].MapObjectType = MapObjectType.Stone;
                }
                else
                    i--;
            }
            return  mapArray;
        }


    }
}
