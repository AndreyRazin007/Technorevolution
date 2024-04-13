using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    private HealthBar _healthBar;

    private void Awake() {
        _healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start() {
        _currentHealth = _maxHealth;
    }

    private void Die() {
        Destroy(gameObject);
    }

    public void Damage(float damageAmount) {
        _currentHealth -= damageAmount;

        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

        if (_currentHealth <= 0) {
            Die();
        }
    }
}
