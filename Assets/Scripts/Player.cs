using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = .5f;
    [SerializeField]
    private float _jumpHeight = 20f;
    [SerializeField]
    private int _maxJumpCount = 2;
    private float _yVelocity;
    private int _jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Left right movement
        float xInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(xInput, 0, 0);
        Vector3 velocity = direction * _speed;
        
        // Check if grounded, if not apply gravity
        if(_controller.isGrounded){
            _jumpCount = 0;

            if(Input.GetKeyDown(KeyCode.Space)) {
                _jumpCount++;
                _yVelocity = _jumpHeight;
            }
        } else {
            if(_jumpCount < _maxJumpCount) {
                if(Input.GetKeyDown(KeyCode.Space)) {
                    _jumpCount++;
                    _yVelocity += _jumpHeight;
                }
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
