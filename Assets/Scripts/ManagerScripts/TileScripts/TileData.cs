using UnityEngine;

namespace Grail
{
    public class TileData
    {
        public GameObject objectOnTile { private set; get; }

        private bool isActiveObject;

        public TileData()
        {

        }

        //Object

        public void AddObject(IInteractable obj)
        {
            isActiveObject = true;
            if (obj is MonoBehaviour mb)
            {
                objectOnTile = mb.gameObject;
            }
        }
        public bool GetObject() => isActiveObject;
        public void DeactivateObject() => isActiveObject = false;

        public void SetObjectInactive() => objectOnTile.SetActive(false);

    }
}
