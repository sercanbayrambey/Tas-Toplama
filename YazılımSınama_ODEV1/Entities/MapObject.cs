using System;
using System.Collections.Generic;
using System.Text;
using YazılımSınama_ODEV1.Business.Static;

namespace YazılımSınama_ODEV1.Entities
{
    public class MapObject
    {
        public int MapObjectType { get; set; } = 0;
        public int? ShortestDistanceToMainStone { get; set; }

    }
}
