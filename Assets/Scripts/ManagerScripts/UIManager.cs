using TMPro;
using UnityEngine;

namespace Grail
{
    public class UIManager : MonoBehaviour, IInitializable
    {
        // resources UI
        [SerializeField] private TextMeshProUGUI turnsText;
        [SerializeField] private TextMeshProUGUI goldText;

        // player stats UI

        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private TextMeshProUGUI manaText;
        [SerializeField] private TextMeshProUGUI mightText;
        [SerializeField] private TextMeshProUGUI magicText;
        [SerializeField] private TextMeshProUGUI physDefText;
        [SerializeField] private TextMeshProUGUI magicDefText;

        // connections
        [SerializeField] private TurnsManager turnsManager;
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private PlayerStats playerStats;

        public int sortingIndex => 99;

        public void Initialise()
        {
            turnsManager.OnTurnsChanged += TurnsUpdateUI;
            turnsManager.OnGameOver += GameOverUI;
            playerInventory.OnCurrentGoldChanged += GoldUpdateUI;
            playerStats.OnStatsChanged += StatsUpdateUI;

            TurnsUpdateUI();
            GoldUpdateUI();

            StatsUpdateUI();
        }
        // resources update
        private void TurnsUpdateUI()
        {
            turnsText.text = $"Ходов: {turnsManager.GetCurrentTurns()} / {turnsManager.GetMaxTurns()}";
        }

        private void GoldUpdateUI()
        {
            goldText.text = $"Золото: {playerInventory.GetCurrentGold()}";
        }
        // player's stats update

        private void StatsUpdateUI()
        {
            hpText.text = $"HP: {playerStats.hp}";
            manaText.text = $"Mana: {playerStats.mana}";
            mightText.text = $"Might: {playerStats.might}";
            magicText.text = $"Magic: {playerStats.magic}";
            physDefText.text = $"Phys. Def.: {(int)(playerStats.physicalDefence * 100)}%";
            magicDefText.text = $"Magic Def.: {(int)(playerStats.magicalDefence * 100)}%";
        }

        //other methods

        private void GameOverUI()
        {
            Debug.Log("There game over UI will appear");
        }

    }
}
