using UnityEngine;

public class PowerWings : PowerUp
{
    protected override void Power()
    {
        PlayerController.instance._canFly = true;
        PlayerController.instance._poweredUp = true;
    }
}
