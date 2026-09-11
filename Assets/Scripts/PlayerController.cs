using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;

    float _horizontalVelocity;
    float _verticalVelocity = 0;

    public float _moveSpeed = 1;
    public float _jumpHeight = 5;

    public float _loseHeight = -10;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontalVelocity = Input.GetAxis("Horizontal") * _moveSpeed;
        _rb.AddForce(new Vector2(_horizontalVelocity, 0));
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
        }

        if (gameObject.transform.position.y < _loseHeight)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }
}
