using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using YazılımSınama_ODEV1.Business.Static;
using YazılımSınama_ODEV1.Entities;

namespace YazılımSınama_ODEV1.Business.Concrete
{
    public class PathFinding
    {
        private const int MOVE_COST = 10;

        private readonly MapObject[,] mapArray;
        private List<PathNode> openList;
        private List<PathNode> closedList;

        public PathFinding(MapObject[,] mapArray)
        {
            this.mapArray = mapArray;
        }


        public int FindShortestDistance(Point startPos, Point endPos)
        {
            var distanceCounter = 0;

            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    PathNode pathNode = new PathNode(j, i);
                    pathNode.GCost = int.MaxValue;
                    pathNode.CalculateFCost();
                    pathNode.CameFrom = null;
                    if (mapArray[i, j].MapObjectType == MapObjectType.Block)
                        pathNode.IsBlock = true;
                    mapArray[i, j].Node = pathNode;
                }
            }


            PathNode startNode = GetNode(startPos.X, startPos.Y);
            PathNode endNode = GetNode(endPos.X, endPos.Y);

            openList = new List<PathNode> { startNode };
            closedList = new List<PathNode>();

            startNode.GCost = 0;
            startNode.HCost = CalculateDistance(startNode, endNode);
            startNode.CalculateFCost();

            while (openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(openList);
                if (currentNode == endNode)
                    return CalculatePath(currentNode);

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                foreach (var neighbour in GetNeighbours(currentNode))
                {
                    if (closedList.Contains(neighbour)) continue;
                    if (neighbour.IsBlock)
                    {
                        closedList.Add(neighbour);
                        continue;
                    }

                    int tempGCost = currentNode.GCost + CalculateDistance(currentNode, neighbour);
                    if (tempGCost < neighbour.GCost)
                    {
                        neighbour.CameFrom = currentNode;
                        neighbour.GCost = tempGCost;
                        neighbour.HCost = CalculateDistance(neighbour, endNode);
                        neighbour.CalculateFCost();

                        if (!openList.Contains(neighbour))
                            openList.Add(neighbour);
                    }

                }
                distanceCounter++;
            }

            return 0;
        }

        private int CalculatePath(PathNode endNode)
        {
            var distanceCounter = 0;
            List<PathNode> pathList = new List<PathNode>();
            
            pathList.Add(endNode);
            PathNode currentNode = endNode;
            while(currentNode.CameFrom != null)
            {
                currentNode = currentNode.CameFrom;
                distanceCounter++;
            }
            return distanceCounter;
        }

        private List<PathNode> GetNeighbours(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();
            if (currentNode.X - 1 >= 0) // Left
                neighbourList.Add(GetNode(currentNode.X - 1, currentNode.Y));

            if (currentNode.X + 1 < mapArray.GetLength(1))
                neighbourList.Add(GetNode(currentNode.X + 1, currentNode.Y));

            if (currentNode.Y - 1 >= 0) //UP
                neighbourList.Add(GetNode(currentNode.X, currentNode.Y - 1));

            if (currentNode.Y + 1 < mapArray.GetLength(0)) // Left
                neighbourList.Add(GetNode(currentNode.X, currentNode.Y + 1));

            return neighbourList;
        }

        private PathNode GetNode(int x, int y)
        {
            return mapArray[y, x].Node;
        }



        private PathNode GetLowestFCostNode(List<PathNode> pathNodes)
        {
            PathNode lowestFCostNode = pathNodes[0];
            for (int i = 0; i < pathNodes.Count; i++)
            {
                if (pathNodes[i].FCost < lowestFCostNode.FCost)
                {
                    lowestFCostNode = pathNodes[i];
                }

            }

            return lowestFCostNode;
        }


        private int CalculateDistance(PathNode a, PathNode b)
        {
            int xDistance = Math.Abs(a.X - b.X);
            int yDistance = Math.Abs(a.Y - b.Y);
            return MOVE_COST * (xDistance + yDistance);

        }

    }
}
