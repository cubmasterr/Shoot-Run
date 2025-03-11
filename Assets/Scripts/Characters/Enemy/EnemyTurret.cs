using UnityEngine;

public class EnemyTurret : Enemy
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletVelocity;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _timeToShoot;
    [SerializeField] private int _bulletCount;
    private float timer;
    private PoolMono<Bullet> _poolMono;
    protected override void Start()
    {
        _poolMono = new PoolMono<Bullet>(_bulletPrefab, _bulletCount, transform);
        _poolMono.IsAutoExpand = true;
    }
    protected override void Death()
    {
        Instantiate(_explosionEffect);
        base.Death();
    }
    private void Update()
    {
        if (_target != null && _isDeath == false)
        {
            //var rotation = Quaternion.LookRotation(_target.position);
            //var sequince = DOTween.Sequence();
            //sequince.Append(transform.DORotate(rotation.eulerAngles, _timeToShoot));
            transform.LookAt(_target);
            if (timer < _timeToShoot)
            {
                timer += Time.deltaTime;
            }
            else 
            {
                timer = 0;
                var bullet = _poolMono.GetFreeElement();
                bullet.transform.position = _shootPoint.position;
                bullet.SetVariables(_damage, _bulletLifeTime);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _bulletVelocity;
                _poolMono.RemoveElement(bullet);
            }
        }
        else
        {
            timer = 0;
        }

    }

}
