using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = .5f;
    [SerializeField]
    private float _jumpHeight = 20f;
    [SerializeField]
    private int _maxJumpCount = 2;
    [SerializeField]
    private int _coins = 0;
    private int _health = 3;
    private int _jumpCount;
    private float _yVelocity;
    private Vector3 _respawnPoint;

    // Components
    private CharacterController _controller;
    private UIManager _uiManager;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (!_controller)
        {
            Debug.LogError("Failed to find Character Controller");
        }

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (!_uiManager)
        {
            Debug.LogError("Failed to find Game Object: UIManager");
        }

        _respawnPoint = GameObject.Find("Respawn_Point").transform.position;
        if (_respawnPoint == new Vector3())
        {
            Debug.LogError("Failed to find transform.position of Game Object: Respawn_Point");
        }
    }

    void Update()
    {
        Movement();
        CheckFallDamage();
    }

    void Movement()
    {
        // Left right movement
        float xInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(xInput, 0, 0);
        Vector3 velocity = direction * _speed;

        // Check if grounded, if not apply gravity
        if (_controller.isGrounded)
        {
            _jumpCount = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpCount++;
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            if (_jumpCount < _maxJumpCount)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _jumpCount++;
                    _yVelocity += _jumpHeight;
                }
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoin()
    {
        _coins++;
        _uiManager.UpdateCoins(_coins);
    }

    public void CheckFallDamage()
    {
        if (transform.position.y < -3)
        {
            _health--;
            gameObject.SetActive(false);
            _uiManager.UpdateHealthDisplay(_health);
            if (_health > 0)
            {
                transform.position = _respawnPoint;
                gameObject.SetActive(true);
            }
        }
    }
}
