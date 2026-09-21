using UnityEngine;

public class PowerMushroom : PowerUp
{
    protected override void Power()
    {
        PlayerController.instance.gameObject.transform.localScale = Vector3.one * 2;
        PlayerController.instance._poweredUp = true;
    }
}
