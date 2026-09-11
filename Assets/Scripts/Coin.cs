using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        CoinManager.instance.AddCoinCount();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinManager.instance.CoinCollected();
        Destroy(gameObject);
    }
}
