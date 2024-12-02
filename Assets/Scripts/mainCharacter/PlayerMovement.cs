using UnityEngine;

namespace mainCharacter
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement settings")]
        [SerializeField] private float moveSpeed = 5f;
    
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movementInput;

        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        { 
            _movementInput.x = Input.GetAxisRaw("Horizontal");
            _movementInput.y = Input.GetAxisRaw("Vertical");
            _movementInput = _movementInput.normalized;
        }

        void FixedUpdate()
        {
            _rigidbody2D.velocity = _movementInput * moveSpeed;
        }
    }
}
