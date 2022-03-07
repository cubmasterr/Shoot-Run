using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour,ICollisionDamage
{
    public static event EnemyDeath OnEnemyDeath;
    public delegate void EnemyDeath(Enemy enemy);
    [SerializeField] private float _totalHealth;
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Slider _healthBarSlider;
    private float _health;
    private Animator _animator;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        GameStateManager.Instance.OnRestartMatch += DestroyCharacter;
        GameStateManager.Instance.OnRandomLevel += DestroyCharacter;
    }

    private void DestroyCharacter()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        _health = _totalHealth;
        _animator = gameObject.GetComponent<Animator>();
        _boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void TakeCollisionDamage(float damage)
    {
        _health -= damage;
        _healthBarSlider.value = _health / _totalHealth;
        if (_health <= 0)
        {
            _healthBarSlider.gameObject.SetActive(false);
            _animator.enabled = false;
            _boxCollider.enabled = false;
            foreach (Rigidbody rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
            OnEnemyDeath(this);
        }
    }

    public void OnDestroy()
    {
        GameStateManager.Instance.OnRestartMatch -= DestroyCharacter;
        GameStateManager.Instance.OnRandomLevel -= DestroyCharacter;
    }
}