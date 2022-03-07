using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    public Action<Vector3> OnCalculateDestination;
    [SerializeField] private int _bulletCount;
    [SerializeField] private GunCharacteristics _gunCharacteristics;
    private Vector3 _destination;
    private PoolMono<Bullet> _poolMono;

    private void Start()
    {
        _poolMono = new PoolMono<Bullet>(_gunCharacteristics.BulletPrefab, _bulletCount, transform);
        _poolMono.IsAutoExpand = true;
        InputManager.Instance.OnClic += Shoot;
    }

    public virtual void Shoot()
    {
        if (!this.enabled)
        {
            return;
        }
        _destination = new Vector3();
        RaycastHit hit;
        #if UNITY_EDITOR
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        #else
        #if UNITY_IOS || UNITY_ANDROID
        var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);     
        #endif
        #endif      
        if (Physics.Raycast(ray, out hit))
        {
            _destination = hit.point;
        }
        else
        {
            _destination = ray.origin + ray.direction * _gunCharacteristics.AimLenght;
        }
        _destination = (_destination - transform.position).normalized * _gunCharacteristics.BulletSpeed;
        OnCalculateDestination?.Invoke(_destination);
        SpawnBullet();
    }

    public void SpawnBullet()
    {
        var bullet = _poolMono.GetFreeElement();
        bullet.SetVariables(_destination, _gunCharacteristics.BulletDamage, _gunCharacteristics.BulletLifeTime);
        _poolMono.RemoveElement(bullet);
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnClic -= Shoot;
    }
}
