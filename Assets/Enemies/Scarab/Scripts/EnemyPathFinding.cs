using UnityEngine;

public class EnemyPathFinding : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 1.0f;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveDirection;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rigidbody.MovePosition(_rigidbody.position + _moveDirection *
                                (_moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition) {
        _moveDirection = targetPosition;
    }
}
