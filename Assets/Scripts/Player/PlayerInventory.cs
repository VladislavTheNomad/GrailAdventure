using System;
using UnityEngine;

namespace Grail
{
    public class PlayerInventory : MonoBehaviour
    {
        public int currentGold { get; private set; }
        public int currentCrystals { get; private set; }

        public event Action onCurrentGoldChanged;
        public event Action onCurrentCrystalChanged;

        public static PlayerInventory instance { get; private set; }

        public void Initialize()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            instance.currentGold = 100;
            instance.currentCrystals = 1;

        }

        public void GetGold(int goldAmount)
        {
            instance.currentGold += goldAmount;
            onCurrentGoldChanged?.Invoke();
        }

        public void GetCrystals(int crystalsAmount)
        {
            instance.currentCrystals += crystalsAmount;
            onCurrentCrystalChanged?.Invoke();
        }

        public void TakeGold(int amountOfGold)
        {
            instance.currentGold -= amountOfGold;
            onCurrentGoldChanged?.Invoke();
        }

        public void TakeCrystals(int amountOfCrystals)
        {
            instance.currentCrystals -= amountOfCrystals;
            onCurrentCrystalChanged?.Invoke();
        }

        public int GetCurrentGold() => instance.currentGold;
        public int GetCurrentCrystal() => instance.currentCrystals;
    }
}
