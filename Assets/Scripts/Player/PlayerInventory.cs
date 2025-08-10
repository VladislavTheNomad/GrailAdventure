using System;
using UnityEngine;

namespace Grail
{
    public class PlayerInventory : MonoBehaviour, IInitializable
    {
        public int currentGold { get; private set; }
        public int currentCrystals { get; private set; }

        public event Action OnCurrentGoldChanged;
        public event Action OnCurrentCrystalChanged;

        public static PlayerInventory instance { get; private set; }

        public int sortingIndex => 3;

        public void Initialise()
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
            OnCurrentGoldChanged?.Invoke();
        }

        public void GetCrystals(int crystalsAmount)
        {
            instance.currentCrystals += crystalsAmount;
            OnCurrentCrystalChanged?.Invoke();
        }

        public void TakeGold(int amountOfGold)
        {
            instance.currentGold -= amountOfGold;
            OnCurrentGoldChanged?.Invoke();
        }

        public void TakeCrystals(int amountOfCrystals)
        {
            instance.currentCrystals -= amountOfCrystals;
            OnCurrentCrystalChanged?.Invoke();
        }

        public int GetCurrentGold() => instance.currentGold;
        public int GetCurrentCrystal() => instance.currentCrystals;
    }
}
