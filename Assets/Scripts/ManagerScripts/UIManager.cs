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
        //[SerializeField] private PlayerStats playerStats;

        public int sortingIndex => 99;

        public void Initialise()
        {
            turnsManager.OnTurnsChanged += TurnsUpdateUI;
            turnsManager.OnGameOver += GameOverUI;
            playerInventory.OnCurrentGoldChanged += GoldUpdateUI;
            PlayerStats.instance.OnStatsChanged += StatsUpdateUI;

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
            hpText.text = $"HP: {PlayerStats.instance.hp}";
            manaText.text = $"Mana: {PlayerStats.instance.mana}";
            mightText.text = $"Might: {PlayerStats.instance.might}";
            magicText.text = $"Magic: {PlayerStats.instance.magic}";
            physDefText.text = $"Phys. Def.: {(int)(PlayerStats.instance.physicalDefence * 100)}%";
            magicDefText.text = $"Magic Def.: {(int)(PlayerStats.instance.magicalDefence * 100)}%";
        }

        //other methods

        private void GameOverUI()
        {
            Debug.Log("There game over UI will appear");
        }

    }
}
