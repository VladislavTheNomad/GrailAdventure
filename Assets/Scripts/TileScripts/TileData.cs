using UnityEngine;

namespace Grail
{
    public class TileData
    {
        public GameObject destroyableObjectOnTile { private set; get; }

        private bool hasGold;

        private bool hasSmith;

        //private bool firstEnter;

        public TileData()
        {
            //firstEnter = true;
        }
        //Gold Pile
        public void AddGoldPile(GoldPile goldPile)
        {
            hasGold = true;
            destroyableObjectOnTile = goldPile.gameObject;
        }
        public bool GetGoldPile() => hasGold;

        public void RemoveGoldPile() => hasGold = false;

        // Smith
        public void AddSmith() => hasSmith = true;
        public bool GetSmith() => hasSmith;
        public void RemoveSmith() => hasSmith = false;
    }
}
