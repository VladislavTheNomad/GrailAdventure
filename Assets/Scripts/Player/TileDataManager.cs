using UnityEngine;

namespace Grail
{
    public class TileDataManager : MonoBehaviour
    {
        [SerializeField] private TileGridConstructor fromTileGridConstructor;
        public void CheckObjectsOnTile(Vector3Int tilePosition)
        {
            TileData tileData = fromTileGridConstructor.tileGrid[tilePosition.x, tilePosition.y];

            HasPickableObjects(tileData);

        }

        private void HasPickableObjects(TileData tileData)
        {
            if (tileData.GetGoldPile())
            {
                PlayerInventory.instance.GetGold(Random.Range(25, 51));
                tileData.DestroyDestoyable();
            }
        }
    }
}
