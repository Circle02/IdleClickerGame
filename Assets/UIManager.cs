using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI upgradeCostText;
    public UpgradeButton upgradeButton;

    void Update()
    {
        coinText.text = $"Coins: {GameManager.Instance.coins:F0}";
        if (upgradeCostText != null && upgradeButton != null)
            upgradeCostText.text = $"Upgrade: {upgradeButton.upgradeCost:F0}";
    }
}
