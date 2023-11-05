using System;
using UnityEngine;
using Time = Codice.Client.Common.Time;

namespace Core.Pong.Runtime
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float speed = 1f;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _previousDirection;
        private BoxCollider2D _boxCollider2D;


        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {   
            var colliderCenterPoint = _boxCollider2D.bounds.center;

            if (!other.gameObject.CompareTag("Ball"))return ;
            foreach (var contact in other.contacts)
            {
                var relativePosition = contact.point.y - colliderCenterPoint.y; 
                _rigidbody2D.velocity *= relativePosition; 
                EventManager.Instance.OnSpeedChangedEvent(_rigidbody2D.velocity);
            }
        }

        private void OnDrawGizmos()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            var center = _boxCollider2D.bounds.center;
            var max = _boxCollider2D.bounds.max;
            var min = _boxCollider2D.bounds.min;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(min, 0.1f) ;
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(max, 0.1f);
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(center, 0.1f);
        }

        public void Move(Vector2 direction)
        {
            if (direction != Vector2.zero && _previousDirection != direction)
            {
                _rigidbody2D.velocity *= -1;
            }

            _rigidbody2D.AddForce(direction * speed);
            _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, speed);

            _previousDirection = direction;
        }
    }
}