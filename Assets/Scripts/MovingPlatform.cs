using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _targetA = null, _targetB = null;

    [SerializeField] private float _speed = 1.0f;

    private bool _switching = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _targetA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }

        if (transform.position == _targetB.position)
        {
            _switching = true;
        }
        else if (transform.position == _targetA.position)
        {
            _switching = false;
        }
    }
}
