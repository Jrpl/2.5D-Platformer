using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 4f;
    private CharacterController _controller;

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
        float xInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(xInput, 0, 0);

        _controller.Move(direction * _speed * Time.deltaTime);
    }
}
