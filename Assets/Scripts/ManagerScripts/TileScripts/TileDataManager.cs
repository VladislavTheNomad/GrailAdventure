using UnityEngine;

namespace Grail
{
    public class TileDataManager : MonoBehaviour
    {
        [SerializeField] private TileGridConstructor tileGridConstructor;
        [SerializeField] private ObjectProperties objectProperties;

        public void CheckObjectsOnTile(Vector3Int tilePosition)
        {
            TileData tileData = tileGridConstructor.tileGrid[tilePosition.x, tilePosition.y];

            if(tileData.objectOnTile != null && tileData.GetObject())
            {
                IInteractable objectOnTile = tileData.objectOnTile.GetComponent<IInteractable>();
                if(objectOnTile != null)
                {
                    objectOnTile.ActivateObject(objectProperties);

                    if (!IfObjectIsDestructible(tileData))
                    {
                        IfObjectIsOnceUsable(tileData);
                    }
                }
            }
        }

        private void IfObjectIsOnceUsable(TileData tileData)
        {
            IOnceUsable objectOnUsable = tileData.objectOnTile.GetComponent<IOnceUsable>();
            if (objectOnUsable != null)
            {
                tileData.DeactivateObject();
            }
        }

        private bool IfObjectIsDestructible(TileData tileData)
        {
            IDestructible destructibleObject = tileData.objectOnTile.GetComponent<IDestructible>();
            if (destructibleObject != null)
            {
                tileData.DeactivateObject();
                tileData.SetObjectInactive();
                return true;
            }
            return false;
        }
    }
}
