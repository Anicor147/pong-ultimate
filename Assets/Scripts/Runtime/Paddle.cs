using System;
using UnityEngine;

namespace Core.Pong
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float boundY = 5f;
        [SerializeField] private KeyCode upKey = KeyCode.W;
        [SerializeField] private KeyCode downKey = KeyCode.S;
        
        
        private Rigidbody2D _rigidbody2D;
        private float _direction;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _direction = 0f;
            if (Input.GetKey(upKey))
            {
                _direction = 1f;
            }
            else if (Input.GetKey(downKey))
            {
                _direction = -1f;
            }
        }

        private void FixedUpdate()
        {
            var velocity = new Vector2(0, _direction * speed);
            _rigidbody2D.MovePosition(_rigidbody2D.position + velocity);
            // transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -boundY, boundY));
        }
    }
}