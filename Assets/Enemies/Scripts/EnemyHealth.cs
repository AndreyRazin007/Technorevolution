using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable {
    [SerializeField] private float _maxHealth = 3.0f;

    private float _currentHealth;

    private void Start() {
        _currentHealth = _maxHealth;
    }

    private void Die() {
        Destroy(gameObject);
    }

    public void Damage(float amountDamage) {
        _currentHealth -= amountDamage;

        if (_currentHealth <= 0) {
            Die();
        }
    }
}
