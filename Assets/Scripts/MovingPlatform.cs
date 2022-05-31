using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform _pointA, _pointB;
    [SerializeField]
    private float _speed = 3f;
    private bool _toPointB = true;

    void Start()
    {
        _pointA = GameObject.Find("Point_A").transform;
        if (!_pointA)
        {
            Debug.LogError("Failed to find Game Object: Point_A");
        }

        _pointB = GameObject.Find("Point_B").transform;
        if (!_pointB)
        {
            Debug.LogError("Failed to find Game Object: Point_B");
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_toPointB == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
        }

        if (transform.position == _pointA.position)
        {
            _toPointB = true;
        }
        else if (transform.position == _pointB.position)
        {
            _toPointB = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
