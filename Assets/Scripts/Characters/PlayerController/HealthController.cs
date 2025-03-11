using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, IDamageble
{
  
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private float _totalHealth;
    private float _health;
    private void Start()
    {
        _health = _totalHealth;
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
    public void Death()
    {
        GameStateManager.Instance.GameOver();
    }
}
