using System.Linq;
using UnityEngine;

namespace Grail
{
    public class Initializer : MonoBehaviour
    {

        private void Awake()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            var initialisables = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IInitializable>().OrderBy(i => i.sortingIndex);

            foreach (var item in initialisables)
            {
                item.Initialise();
            }
            Debug.Log("Game Initialized");
        }
    }
}
