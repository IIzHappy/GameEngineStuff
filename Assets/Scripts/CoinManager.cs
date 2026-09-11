using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static CoinManager instance;
    int _totalCoins = 0;
    int _coins = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddCoinCount()
    {
        _totalCoins++;
    }

    public void CoinCollected()
    {
        _coins++;
        if (_coins >= _totalCoins)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Won");
    }
}
