using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public bool _poweredUp = false;

    Rigidbody2D _rb;
    BoxCollider2D _boxCollider;

    public Transform _startPoint;
    int _lives = 3;
    public TMP_Text _livesText;

    float _horizontalVelocity;

    [SerializeField] float _baseMoveSpeed = 8;
    [SerializeField] float _baseJumpHeight = 12;

    float _moveSpeed;
    float _jumpHeight;

    [SerializeField] LayerMask _groundLayer;

    public bool _canFly = false;
    [SerializeField] float _flySpeed = 8;

    public float _loseHeight = -5;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();

        _moveSpeed = _baseMoveSpeed;
        _jumpHeight = _baseJumpHeight;
    }

    void Update()
    {
        _horizontalVelocity = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        _rb.linearVelocityX = _horizontalVelocity;
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.Space))
        {
            if (_canFly)
            {
                _rb.AddForceY(-_flySpeed);
            }
            else if (IsGrounded())
            {
                _rb.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
            }
        }

        if (gameObject.transform.position.y < _loseHeight)
        {
            Death();
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, extraHeight, _groundLayer);
        return raycastHit.collider != null;
    }

    void ResetPlayer()
    {
        _moveSpeed = _baseMoveSpeed;
        _jumpHeight = _baseJumpHeight;
        gameObject.transform.localScale = Vector3.one;
        _canFly = false;
    }

    public void TakeDamage()
    {
        if (_poweredUp)
        {
            ResetPlayer();
            _poweredUp = false;
        } else
        {
            Death();
        }
    }

    public void ExtraLife()
    {
        _lives++;
        _livesText.text = _lives.ToString() + " lives";
    }

    void Death()
    {
        _lives--;
        _livesText.text = _lives.ToString() + " lives";
        gameObject.transform.position = _startPoint.position;
        ResetPlayer();
        _poweredUp = false;
        if (_lives == 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
        } else
        {
            _rb.linearVelocity.Set(0, 0);
        }
    }
}
