using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using System.Collections;

namespace Grail
{
    public class PlayerController : MonoBehaviour
    {
        private Tilemap worldTilemap;
        private TurnsManager turnsManager;
        private Vector3Int playerCellPosition = new Vector3Int(0, 0, 0);

        //input sys

        private PlayerInputSystem inputActions;
        private float pauseTimeBetweenTurns = 0.2f;
        private bool isPaused;

        public void Initialize(Tilemap tilemapReference, TurnsManager deliveredTurnsManager)
        {
            inputActions = new PlayerInputSystem();
            inputActions.Player.Move.performed += OnMovePerformed;

            turnsManager = deliveredTurnsManager;
            worldTilemap = tilemapReference;
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            if (isPaused)
            {
                return;
            }
            isPaused = true;
            StartCoroutine(LittlePauseBetweenTurns());
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
                Debug.Log(playerCellPosition.x);
                Debug.Log(playerCellPosition.y);
                Vector3 worldPosition = worldTilemap.GetCellCenterWorld(playerCellPosition);
                transform.position = worldPosition;
                turnsManager.AddTurns(TileCheckManager.CheckMoveCost(tile));
            }
        }

        private IEnumerator LittlePauseBetweenTurns()
        {
            yield return new WaitForSeconds(pauseTimeBetweenTurns);
            isPaused = false;
        }
    }
}