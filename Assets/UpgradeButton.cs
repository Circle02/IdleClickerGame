using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public double upgradeCost = 10;
    public double cpsIncrease = 1;

    public void BuyUpgrade()
    {
        if (GameManager.Instance.coins >= upgradeCost)
        {
            GameManager.Instance.coins -= upgradeCost;
            GameManager.Instance.coinsPerSecond += cpsIncrease;
            upgradeCost *= 1.2;
            
        }
    }
}
