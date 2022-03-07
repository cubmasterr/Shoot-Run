using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;
    private Vector3 _destination;

    public void SetVariables(Vector3 destination, float damage, float lifeTime )
    {
        _destination = destination;
        _damage = damage;
        Destroy(gameObject,lifeTime);
    }

    private void Update()
    {
        if (_destination != null)
        {
            transform.position += _destination * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collisionDamage = collision.gameObject.GetComponent<ICollisionDamage>();
        if (collisionDamage != null)
        {
            collisionDamage.TakeCollisionDamage(_damage);
        }
        Destroy(gameObject);
    }
}