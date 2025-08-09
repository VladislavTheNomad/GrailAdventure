using UnityEngine;
using UnityEngine.Tilemaps;

namespace Grail
{
    public class TileGridConstructor : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;         // Ссылка на Tilemap (присваивается в инспекторе)
        public TileData[,] tileGrid { get; private set; }   // Двумерный массив TileData

        public void Initialize()
        {
            tileGrid = new TileData[32, 32];

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    tileGrid[x, y] = new TileData();
                }
            }

            GoldPileFilling();
        }

        private void GoldPileFilling()
        {
            GoldPile[] goldPiles = Object.FindObjectsByType<GoldPile>(FindObjectsSortMode.None);
            foreach (GoldPile goldPile in goldPiles)
            {
                Vector3Int tilePosition = tilemap.WorldToCell(goldPile.transform.position);
                if (tilePosition.x >= 0 && tilePosition.x < 32 && tilePosition.y >= 0 && tilePosition.y < 32)
                {
                    tileGrid[tilePosition.x, tilePosition.y].AddGoldPile(goldPile);
                }
            }
        }

        // Метод для получения TileData по позиции
        public TileData GetTileData(Vector3Int position)
        {
            if (position.x >= 0 && position.x < tilemap.size.x && position.y >= 0 && position.y < tilemap.size.y)
            {
                return tileGrid[position.x, position.y];
            }
            return null;
        }
    }
}
