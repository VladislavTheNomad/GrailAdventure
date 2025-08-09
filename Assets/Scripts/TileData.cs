using UnityEngine;

namespace Grail
{
    public class TileData : MonoBehaviour
    {
        private GameObject destoyableObjectOnTile;
        private bool hasGold;

        public void AddGoldPile(GoldPile goldPile)
        {
            hasGold = true;
            destoyableObjectOnTile = goldPile.gameObject;
        }
        public bool GetGoldPile() => hasGold;

        public void DestroyDestoyable()
        {
            Destroy(destoyableObjectOnTile);
        }
    }
}
