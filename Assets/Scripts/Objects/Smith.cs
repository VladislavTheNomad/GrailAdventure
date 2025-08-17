using UnityEngine;

namespace Grail
{
    public class Smith : MonoBehaviour, IInteractable, IOnceUsable
    {
        public void ActivateObject(ObjectProperties objectProperties)
        {
            PlayerStats.instance.ModifyMight(objectProperties.mightBonus);
        }
    }
}
