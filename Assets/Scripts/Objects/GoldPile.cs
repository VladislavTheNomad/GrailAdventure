using UnityEngine;

namespace Grail
{
    public class GoldPile : MonoBehaviour, IInteractable, IDestructible
    {

        public void ActivateObject(ObjectProperties objectProperties)
        {
            PlayerInventory.instance.GetGold(Random.Range(objectProperties.minGoldFromPile, objectProperties.maxGoldFromPile));
        }
    }
}

