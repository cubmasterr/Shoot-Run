using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private int _bulletCount;
    [SerializeField] public float _bulletVelocity;
    [SerializeField] public float _bulletLifeTime;
    [SerializeField] private GunCharacteristics _gunCharacteristics;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private KeyCode _shootKeyCode;
    private Vector3 _destination;
    private PoolMono<Bullet> _poolMono;
    private void Start()
    {
        _poolMono = new PoolMono<Bullet>(_bulletPrefab, _bulletCount, transform);
        _poolMono.IsAutoExpand = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(_shootKeyCode))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        var bullet = _poolMono.GetFreeElement();
        bullet.transform.position = _shootPoint.position;
        bullet.SetVariables(_gunCharacteristics.damage, _bulletLifeTime);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _bulletVelocity; 
        _poolMono.RemoveElement(bullet);
    }
}