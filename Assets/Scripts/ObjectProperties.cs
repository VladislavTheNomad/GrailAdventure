using UnityEngine;

namespace Grail
{
    [CreateAssetMenu(fileName = "ObjectProperties", menuName = "Scriptable Objects/ObjectProperties")]
    public  class ObjectProperties : ScriptableObject
    {
        [Header ("GoldPile")]
        [SerializeField] public int minGoldFromPile;
        [SerializeField] public int maxGoldFromPile;

        [Header("Smith")]
        [SerializeField] public int mightBonus;
    }
}
