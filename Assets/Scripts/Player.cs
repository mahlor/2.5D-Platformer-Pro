using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canJump = false;
    private int _coinCount;
    private UIManager _uiManager;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void addCoin()
    {
        _coinCount++;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.UpdateCoinCounter(_coinCount);
    }
    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canJump = true;
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canJump)
                { 
                    _yVelocity += _jumpHeight;
                    _canJump = false;
                }
            }
            else
            {
                _yVelocity -= _gravity;
            }

        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
