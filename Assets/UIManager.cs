using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Update()
    {
        coinText.text = $"Coins: {GameManager.Instance.coins:F1}";
    }
}
