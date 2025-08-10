using UnityEngine;

namespace Grail
{
    public class TileDataManager : MonoBehaviour
    {
        [SerializeField] private TileGridConstructor tileGridConstructor;
        [SerializeField] private ObjectProperties objectProperties;

        [SerializeField] private PlayerStats playerStats;

        public void CheckObjectsOnTile(Vector3Int tilePosition)
        {
            TileData tileData = tileGridConstructor.tileGrid[tilePosition.x, tilePosition.y];

            HasPickableObjects(tileData);
            HasObjects(tileData);
        }

        private void HasPickableObjects(TileData tileData)
        {
            // gold pile
            if (tileData.GetGoldPile())
            {
                PlayerInventory.instance.GetGold(Random.Range(objectProperties.minGoldFromPile, objectProperties.maxGoldFromPile));
                tileData.RemoveGoldPile();
                Destroy(tileData.destroyableObjectOnTile);
            }
        }

        private void HasObjects(TileData tileData)
        {
            // smith
            if (tileData.GetSmith())
            {
                playerStats.ModifyMight(objectProperties.mightBonus);
                tileData.RemoveSmith();
            }
        }
    }
}
