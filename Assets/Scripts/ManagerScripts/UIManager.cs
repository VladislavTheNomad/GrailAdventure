using TMPro;
using UnityEngine;

namespace Grail
{
    public class UIManager : MonoBehaviour
    {
        // text UI
        [SerializeField] private TextMeshProUGUI turnsText;
        [SerializeField] private TextMeshProUGUI goldText;

        // connections
        [SerializeField] private TurnsManager turnsManager;
        [SerializeField] private PlayerInventory playerInventory;

        public void Initialize()
        {
            turnsManager.onTurnsChanged += TurnsUpdate;
            turnsManager.onGameOver += GameOverUI;
            playerInventory.onCurrentGoldChanged += GoldUpdate;
            TurnsUpdate();
            GoldUpdate();
        }

        private void TurnsUpdate()
        {
            turnsText.text = $"Ходов: {turnsManager.GetCurrentTurns()} / {turnsManager.GetMaxTurns()}";
        }

        private void GoldUpdate()
        {
            goldText.text = $"Золото: {playerInventory.GetCurrentGold()}";
        }

        private void GameOverUI()
        {
            Debug.Log("There game over UI will appear");
        }

    }
}
