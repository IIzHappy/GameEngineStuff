using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    int _coins = 0;
    public TMP_Text _counter;

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

    public void CoinCollected()
    {
        _coins++;
        _counter.text = _coins.ToString() + " coins";
    }
}
