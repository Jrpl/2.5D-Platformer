using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject _pointA;
    [SerializeField]
    private GameObject _pointB;
    [SerializeField]
    private float _speed = 3f;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _pointA = GameObject.Find("Point_A");
        if (!_pointA) {
            Debug.LogError("Failed to find Game Object: Point_A");
        }

        _pointB = GameObject.Find("Point_B");
        if (!_pointB) {
            Debug.LogError("Failed to find Game Object: Point_B");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        if (transform.position.x <= _pointA.transform.position.x) {
            _direction = new Vector3(_speed, 0, 0) * Time.deltaTime;
        } 
        if (transform.position.x >= _pointB.transform.position.x) {
            _direction = new Vector3(-_speed, 0, 0) * Time.deltaTime;
        }
        
        transform.Translate(_direction);
    }
}
