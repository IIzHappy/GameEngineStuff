using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool _inUse = false;
    public float _speed = 1f;
    public float _lifeSpan = 2;
    float _timer = 0;

    Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifeSpan)
        {
            Despawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Despawn();
    }

    private void OnEnable()
    {
        _timer = 0;
        _inUse = true;
        _rb.linearVelocityX = _speed;
    }

    public void Despawn()
    {
        _inUse = false;
        ProjectileManager.Instance.DespawnProjectile(gameObject);
        gameObject.SetActive(false);
    }
}
