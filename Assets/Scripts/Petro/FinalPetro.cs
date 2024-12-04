using System;
using UnityEngine;

namespace Petro
{
    public class FinalPetro : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Jump = Animator.StringToHash("Jump");
        public Transform player; 
        public float jumpDuration = 1f; 
        public float timeBetweenJumps = 3f; 
        public float jumpHeight = 2f; 

        private Vector2 _initialPosition; 
        private bool _isJumping = false;
        private float _jumpTimer = 0f;
        private float _cooldownTimer = 0f; 
        private Vector2 _startPosition;
        private Vector2 _targetPosition; 

        void Start()
        {
            _initialPosition = transform.position;
            _cooldownTimer = timeBetweenJumps;
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (_isJumping)
            {
                PerformJump();
            }
            else
            {
                _cooldownTimer -= Time.deltaTime;

                if (_cooldownTimer <= 0f)
                {
                    StartJump(player.position); 
                }
            }
        }

        private void StartJump(Vector2 target)
        {
            _isJumping = true;
            _animator.SetBool(Jump,true);
            _jumpTimer = 0f;
            _startPosition = transform.position;
            
            _targetPosition = _startPosition == (Vector2)_initialPosition ? target : _initialPosition;
        }

        private void PerformJump()
        {
            _jumpTimer += Time.deltaTime / jumpDuration;

            if (_jumpTimer > 1f)
            {
                _animator.SetBool(Jump,false);
                transform.position = _targetPosition;
                _isJumping = false;
                if (_targetPosition == _initialPosition)
                {
                    _cooldownTimer = timeBetweenJumps;
                }
                return;
            }
            
            Vector2 horizontalPosition = Vector2.Lerp(_startPosition, _targetPosition, _jumpTimer);
            
            float verticalOffset = Mathf.Sin(_jumpTimer * Mathf.PI) * jumpHeight;
            
            transform.position = new Vector2(horizontalPosition.x, horizontalPosition.y + verticalOffset+1);
        }
    }
}
