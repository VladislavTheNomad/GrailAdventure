using UnityEngine;
using UnityEngine.Tilemaps;

namespace Grail
{
    public class Initializator : MonoBehaviour
    {
        [SerializeField] private Tilemap worldTilemap;
        [SerializeField] private TurnsManager turnsManager;
        [SerializeField] private UIManager UIManager;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private PlayerInventory playerInvertory;
        [SerializeField] private TileGridConstructor tileGridConstructor;

        public static Initializator instance { get; private set; }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            InitializeGame();
        }

        private void InitializeGame()
        {
            tileGridConstructor.Initialize();
            playerController.Initialize();
            playerInvertory.Initialize();
            turnsManager.Initialize();
            UIManager.Initialize(); // это должно быть в конце
            Debug.Log("Game Initialized");
        }
    }
}
