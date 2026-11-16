using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float _speed = 1f;
    public float _lifeSpan = 2;
    float _timer = 0;

    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocityX = _speed;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
