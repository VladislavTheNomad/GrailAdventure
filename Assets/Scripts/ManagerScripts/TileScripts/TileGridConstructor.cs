using UnityEngine;
using UnityEngine.Tilemaps;

namespace Grail
{
    public class TileGridConstructor : MonoBehaviour, IInitializable
    {
        [SerializeField] private Tilemap tilemap;         
        public TileData[,] tileGrid { get; private set; }  

        public int sortingIndex => 1;

        public void Initialise()
        {
            tileGrid = new TileData[32, 32];

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    tileGrid[x, y] = new TileData();
                }
            }

            InteractableObjectsFilling<GoldPile>();
            InteractableObjectsFilling<Smith>();
        }

        private void InteractableObjectsFilling<T>() where T : MonoBehaviour, IInteractable
        {
            T[] interactableObjectsOnWorldMap = Object.FindObjectsByType<T>(FindObjectsSortMode.None);
            foreach (var interactableObject in interactableObjectsOnWorldMap)
            {
                Vector3Int tilePosition = tilemap.WorldToCell(interactableObject.transform.position);
                if(tilePosition.x >= 0 && tilePosition.x < 32 && tilePosition.y >= 0 && tilePosition.y < 32)
                {
                    tileGrid[tilePosition.x, tilePosition.y].AddObject(interactableObject);
                }
            }
        }

        //public TileData GetTileData(Vector3Int position)
        //{
        //    if (position.x >= 0 && position.x < tilemap.size.x && position.y >= 0 && position.y < tilemap.size.y)
        //    {
        //        return tileGrid[position.x, position.y];
        //    }
        //    return null;
        //}
    }
}
