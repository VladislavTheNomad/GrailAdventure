using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using System.Collections;

namespace Grail
{
    public class PlayerController : MonoBehaviour, IInitializable
    {
        //connections
        [SerializeField] private Tilemap worldTilemap;
        [SerializeField] private TurnsManager turnsManager;
        [SerializeField] private TileDataManager tileDataManager;
        // settings
        [SerializeField] private float pauseTimeBetweenTurns = 0.2f;

        //own
        private Vector3Int playerCellPosition;
        private PlayerInputSystem inputActions;
        private bool isPaused;
        public int sortingIndex => 2;

        public void Initialise()
        {
            inputActions = new PlayerInputSystem();
            inputActions.Enable();
            inputActions.Player.Move.performed += OnMovePerformed;
            playerCellPosition = new Vector3Int(0, 0, 0);
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            if (isPaused)
            {
                return;
            }
            isPaused = true;
            StartCoroutine(WaitBetweenTurns());
            Vector2 directionRaw = context.ReadValue<Vector2>();
            Vector2Int direction;

            if(directionRaw.x != 0)
            {
                direction = new Vector2Int ((int)directionRaw.x, 0);
            }
            else if (directionRaw.y != 0)
            {
                direction = new Vector2Int(0, (int)directionRaw.y);
            }
            else
            {
                return;
            }
            
            Vector3Int targetCellPosition = playerCellPosition + new Vector3Int(direction.x, direction.y, 0);
            TileBase tile = worldTilemap.GetTile(targetCellPosition);

            if (TileCheckManager.CheckTileIsWalkable(tile))
            {
                playerCellPosition = targetCellPosition;
                Vector3 worldPosition = worldTilemap.GetCellCenterWorld(playerCellPosition);
                transform.position = worldPosition;
                turnsManager.AddTurns(TileCheckManager.CheckMoveCost(tile));
                tileDataManager.CheckObjectsOnTile(playerCellPosition);
            }
        }

        private IEnumerator WaitBetweenTurns()
        {
            yield return new WaitForSeconds(pauseTimeBetweenTurns);
            isPaused = false;
        }
    }
}