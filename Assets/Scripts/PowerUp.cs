using UnityEngine;

public abstract class PowerUp : Interactable
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerController.instance._poweredUp)
        {
            Power();
        } else
        {
            PlayerController.instance.ExtraLife();
        }
            Destroy(gameObject);
    }

    protected abstract void Power();
}
