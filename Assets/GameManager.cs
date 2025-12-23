using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Currency")]
    public double coins = 0;
    public double coinsPerClick = 1;
    public double coinsPerSecond = 1;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        coins += coinsPerSecond * Time.deltaTime;
    }

    public void AddClickCoins()
    {
        coins += coinsPerClick;
    }
}
