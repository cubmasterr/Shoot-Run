using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour,IDamageble
{
    [SerializeField] private float _totalHealth;
    [SerializeField] protected float _timeToDestroy;
    [SerializeField] protected GameObject _explosionEffect;
    [SerializeField] protected float _damage;
    [SerializeField] private Slider _healthBarSlider;
    protected float _health;
    protected Transform _target;
    protected bool _isDeath;
    protected BoxCollider _boxCollider;
    protected virtual void Start()
    {
        _boxCollider = gameObject.GetComponent<BoxCollider>();
        _health = _totalHealth;
        GameStateManager.Instance.AddEnemy();
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        _healthBarSlider.value = _health / _totalHealth;
        if (_health <= 0)
        {
            Death();
        }
    }
    protected virtual void Death()
    {
        _boxCollider.enabled = false;
        _isDeath = true;
        _healthBarSlider.gameObject.SetActive(false);
        GameStateManager.Instance.SubtractEnemy();
        Destroy(gameObject, _timeToDestroy);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MovementController>()!=null)
        {
            _target = other.transform;
        }
    }

}