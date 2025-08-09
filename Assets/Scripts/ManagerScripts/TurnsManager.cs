using System;
using UnityEngine;

namespace Grail
{
    public class TurnsManager : MonoBehaviour
    {
        private int currentTurns;
        private int maxTurns = 10;

        public event Action onTurnsChanged;
        public event Action onGameOver;

        public void Initialize()
        {
            currentTurns = 0;
            maxTurns = 10;
        }

        public void AddTurns(int addedTurns)
        {
            currentTurns += addedTurns;
            onTurnsChanged?.Invoke();
            if (GameOverCheck())
            {
                onGameOver?.Invoke();
            }
        }

        private bool GameOverCheck()
        {
            if(currentTurns >= maxTurns)
            {
                return true;
            }
            return false;
        }

        public int GetCurrentTurns() => currentTurns;
        public int GetMaxTurns() => maxTurns;
    }
}
