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
        private  PathFinding pathFinding;
        private MapObject[,] mapArray = null;
        public MapObject[,] GenerateRandomLevel(int stoneCount, int height, int width, int blockCount)
        {
            mapArray = new MapObject[height,width];

            Random rnd = new Random();
            for(int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    var mapObject = new MapObject();
                    mapArray[i, j] = mapObject;
                }
            }

            var mainStonePos = new Point(rnd.Next(0, mapArray.GetLength(1)), rnd.Next(0, mapArray.GetLength(0)));
            mapArray[mainStonePos.Y,mainStonePos.X].MapObjectType = MapObjectType.MainStone;


            int rndBlockCount = blockCount;


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
                    pathFinding = new PathFinding(mapArray);
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


     
/*
        bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    pathFinding.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/


    }


}
