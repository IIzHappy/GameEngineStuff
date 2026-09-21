using UnityEngine;

public class Coin : Interactable
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        CoinManager.instance.CoinCollected();
        Destroy(gameObject);
    }
}
