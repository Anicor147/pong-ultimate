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
        private Vector2 _direction;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _direction.y = 0f;
            if (Input.GetKey(upKey))
            {
                _direction.y = 1f;
            }
            else if (Input.GetKey(downKey))
            {
                _direction.y = -1f;
            }
        }

        private void FixedUpdate()
        {
            _rigidbody2D.AddForce(_direction * speed);
        }
    }
}