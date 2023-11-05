using System.Timers;
using Core.Pong.Runtime;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Pong
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private float initialSpeed = 15;
        [SerializeField] private float maxVelocity = 25;
        
    
        
        private RaycastHit2D[] _raycastHit2Ds = new RaycastHit2D[1];

        private void Start()
        {
            EventManager.Instance.OnSpeedChanged += ChangeSpeed; 
            _rb = GetComponent<Rigidbody2D>();
            this.StartTimer(1f , MoveBall);
        }

        private void MoveBall()
        {
            var vector2 = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0f)).normalized;
            _rb.velocity = vector2 * initialSpeed;
        }

        private void FixedUpdate()
        {
            if (_rb.Cast(_rb.velocity.normalized, _raycastHit2Ds, _rb.velocity.magnitude * Time.deltaTime) <= 0) return;
            var hit = _raycastHit2Ds[0];

            if (hit.collider.gameObject.CompareTag("Paddle"))
            {
                _rb.MovePosition(hit.point);
                _rb.velocity = Vector2.Reflect(_rb.velocity, hit.normal);
                _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxVelocity);
            }
        }
        
        private void ChangeSpeed (Vector3 speed)
        {
            var velocity = _rb.velocity;
            velocity = new Vector2(velocity.x * speed.x, velocity.y * speed.y);
            
            _rb.velocity += velocity;
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxVelocity);
        }
    }
}