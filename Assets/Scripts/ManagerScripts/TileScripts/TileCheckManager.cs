using UnityEngine;
using UnityEngine.Tilemaps;

namespace Grail
{
    public class TileCheckManager : MonoBehaviour
    {
        public static bool CheckTileIsWalkable(TileBase tile)
        {
            if (tile is not CustomTile custom)
            {
                Debug.LogError($"Tile isn't a Custom!");
                return false;
            }

            if (custom.isWalkable)
            {
                return true;
            }
            else return false;
        }

        public static int CheckMoveCost(TileBase tile)
        {
            if (tile is not CustomTile custom)
            {
                Debug.LogError($"Tile isn't a Custom!");
                return 999;
            }

            return custom.moveCost;
        }
    }
}
