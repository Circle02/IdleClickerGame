using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Currency")]
    public double coins = 0;
    public double coinsPerClick = 1;
    public double coinsPerSecond = 1;

    [Header("Upgrade")]
    public UpgradeButton UpgradeButtonInstance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        LoadGame();
        StartCoroutine(AutoSave());
    }

    void Update()
    {
        coins += coinsPerSecond * Time.deltaTime;
    }

    public void AddClickCoins()
    {
        coins += coinsPerClick;
    }
    public void BuyUpgrade()
    {
        if (UpgradeButtonInstance != null)
        {
            UpgradeButtonInstance.BuyUpgrade();
            SaveGame(); // immediate save after upgrade to prevent exploits
        }
    }
    public void SaveGame()
    {
        PlayerPrefs.SetString("coins", coins.ToString());
        PlayerPrefs.SetString("coinsPerClick", coinsPerClick.ToString());
        PlayerPrefs.SetString("coinsPerSecond", coinsPerSecond.ToString());

        if (UpgradeButtonInstance != null)
            PlayerPrefs.SetString("upgradeCost", UpgradeButtonInstance.upgradeCost.ToString());

        PlayerPrefs.Save();
        Debug.Log("Game Saved!");
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("coins"))
            coins = double.Parse(PlayerPrefs.GetString("coins"));

        if (PlayerPrefs.HasKey("coinsPerClick"))
            coinsPerClick = double.Parse(PlayerPrefs.GetString("coinsPerClick"));

        if (PlayerPrefs.HasKey("coinsPerSecond"))
            coinsPerSecond = double.Parse(PlayerPrefs.GetString("coinsPerSecond"));

        if (UpgradeButtonInstance != null && PlayerPrefs.HasKey("upgradeCost"))
            UpgradeButtonInstance.upgradeCost = double.Parse(PlayerPrefs.GetString("upgradeCost"));

        Debug.Log("Game Loaded!");
    }
    private IEnumerator AutoSave()
    {
        while (true)
        {
            SaveGame();
            yield return new WaitForSeconds(5f);
        }
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            SaveGame();
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Save file reset!");
        coins = 0;
        coinsPerClick = 1;
        coinsPerSecond = 1;
        if (UpgradeButtonInstance != null)
            UpgradeButtonInstance.upgradeCost = 10;
    }
}
