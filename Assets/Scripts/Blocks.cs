using UnityEngine;

public abstract class Blocks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                Hit();
                Deactivate();
            }
        }
    }

    protected abstract void Hit();
    private void Deactivate() 
    {
        SpriteRenderer _block = gameObject.GetComponent<SpriteRenderer>();
        _block.color = Color.white;
        Destroy(this);
    }
}
