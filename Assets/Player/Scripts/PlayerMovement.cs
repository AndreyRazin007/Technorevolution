using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 4.0f;

    private PlayerActions _playerActions;
    private Vector2 _movement;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRender;

    private void Awake() {
        _playerActions = new();
        _rigidbody = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        _playerActions.Enable();
    }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        Move();
        PlayerFlip();
    }

    private void PlayerInput() {
        _movement = _playerActions.Movement.Move.ReadValue<Vector2>();

        _animator.SetFloat("movementX", _movement.x);
        _animator.SetFloat("movementY", _movement.y);
    }

    private void Move() {
        _rigidbody.MovePosition(_rigidbody.position + _movement *
                                (_moveSpeed * Time.fixedDeltaTime));
    }

    private void PlayerFlip() {
        Vector2 direction = _playerActions.Movement.Move.ReadValue<Vector2>();

        if (direction.x < 0.0f) {
            _spriteRender.flipX = true;
        } else {
            _spriteRender.flipX = false;
        }
    }
}
