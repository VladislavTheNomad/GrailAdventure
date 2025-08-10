using System;
using UnityEngine;

namespace Grail
{
    public class TurnsManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private int maxTurns = 100;

        public int sortingIndex => 4;
        private int currentTurns;

        public event Action OnTurnsChanged;
        public event Action OnGameOver;

        public void Initialise()
        {
            currentTurns = 0;
            //maxTurns = 100;
        }

        public void AddTurns(int addedTurns)
        {
            if (addedTurns < 0)
            {
                Debug.LogError("Negative number in TurnsManager.AddTurns");
            }
            currentTurns += addedTurns;
            OnTurnsChanged?.Invoke();
            if (IsGameOver())
            {
                OnGameOver?.Invoke();
            }
        }

        private bool IsGameOver() => currentTurns >= maxTurns;
        public int GetCurrentTurns() => currentTurns;
        public int GetMaxTurns() => maxTurns;
    }
}
