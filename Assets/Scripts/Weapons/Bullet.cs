using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;
    private Vector3 _destination;

    public void SetVariables(float damage, float lifeTime)
    {
        _damage = damage;
        //Destroy(gameObject,lifeTime);
        //gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        var collisionDamage = collision.gameObject.GetComponent<IDamageble>();
        if (collisionDamage != null)
        {
            collisionDamage.TakeDamage(_damage);
        }
        gameObject.SetActive(false);
    }
}