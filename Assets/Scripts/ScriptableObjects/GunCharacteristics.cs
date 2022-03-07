using UnityEngine;

[CreateAssetMenu(fileName = "Gun Characteristics", menuName = "Gun Characteristics")]
public class GunCharacteristics : ScriptableObject
{
    public float AimLenght;
    public float BulletSpeed;
    public float BulletDamage;
    public float BulletLifeTime;
    public Bullet BulletPrefab;
}