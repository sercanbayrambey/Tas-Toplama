using System;
using System.Collections.Generic;
using System.Text;
using YazılımSınama_ODEV1.Business.Static;

namespace YazılımSınama_ODEV1.Business.Concrete
{
    public class LevelManager
    {
        public int Height { get;}
        public int Width { get;}
        public int[,] MapArray { get; set; }

        public int[,] GenerateRandomLevel(int stoneCount, int height, int width)
        {


            int[,] mapArray = new int[height,width];


            Random rnd = new Random();
            for(int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    mapArray[i, j] = MapObjectType.Empty;
                }
            }
           
            mapArray[rnd.Next(0, mapArray.GetLength(0)), rnd.Next(0, mapArray.GetLength(1))] = MapObjectType.MainStone;

            for (int i = 0; i < stoneCount; i++)
            {
                int rndX = rnd.Next(0, mapArray.GetLength(0));
                int rndY = rnd.Next(0, mapArray.GetLength(1));
                if (mapArray[rndY, rndX] == MapObjectType.Empty)
                    mapArray[rndY, rndX] = MapObjectType.Stone;
                else
                    i--;
            }

            int rndBlockCount = rnd.Next(5, 12);

            for (int i = 0; i < rndBlockCount; i++)
            {
                int rndX = rnd.Next(0, mapArray.GetLength(0));
                int rndY = rnd.Next(0, mapArray.GetLength(1));
                if (mapArray[rndY, rndX] == MapObjectType.Empty)
                    mapArray[rndY, rndX] = MapObjectType.Block;
                else
                    i--;
            }


            MapArray = mapArray;

            return MapArray;
        }
    }
}
