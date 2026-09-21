using UnityEngine;

public class CoinBlock : Blocks
{
    protected override void Hit()
    {
        CoinManager.instance.CoinCollected();
    }
}
