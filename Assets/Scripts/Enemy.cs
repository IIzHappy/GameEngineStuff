using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 10;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocityX = _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y < -0.5f)
                {
                    Hit();
                }
                else
                {
                    Attack(player);
                }
            }
        }
        else if (collision.gameObject.tag == "ground")
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Mathf.Abs(contact.normal.x) > 0.5f)
                {
                    Turn();
                }
            }
        }
    }

    protected abstract void Hit();
    void Attack(PlayerController player)
    {
        player.TakeDamage();
    }

    void Turn()
    {
        _moveSpeed *= -1;
        _rb.linearVelocityX = _moveSpeed;
    }

}
