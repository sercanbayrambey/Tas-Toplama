using System;
using System.Collections.Generic;
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
           
            mapArray[rnd.Next(0, mapArray.GetLength(0)), rnd.Next(0, mapArray.GetLength(1))].MapObjectType = MapObjectType.MainStone;

            for (int i = 0; i < stoneCount; i++)
            {
                int rndX = rnd.Next(0, mapArray.GetLength(0));
                int rndY = rnd.Next(0, mapArray.GetLength(1));
                if (mapArray[rndY, rndX].MapObjectType == MapObjectType.Empty)
                {
                    mapArray[rndY, rndX].MapObjectType = MapObjectType.Stone;
                    mapArray[rndY, rndX].ShortestDistanceToMainStone = rnd.Next(5, 10);
                }
                else
                    i--;
            }

            int rndBlockCount = rnd.Next(3, 8);

            for (int i = 0; i < rndBlockCount; i++)
            {
                int rndX = rnd.Next(0, mapArray.GetLength(0));
                int rndY = rnd.Next(0, mapArray.GetLength(1));
                if (mapArray[rndY, rndX].MapObjectType == MapObjectType.Empty)
                    mapArray[rndY, rndX].MapObjectType = MapObjectType.Block;
                else
                    i--;
            }

            return  mapArray;
        }




    }
}
