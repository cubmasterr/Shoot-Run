using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private GunCharacteristics _gunCharacteristics;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private KeyCode _shootKeyCode;
    private LineRenderer _lineRenderer;
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(_shootKeyCode)) // ЛКМ зажата
        {
            ShootLaser();
        }
        else // ЛКМ отпущена
        {
            _lineRenderer.enabled = false;
        }
    }

    void ShootLaser()
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, _firePoint.position);

        RaycastHit hit;
        if (Physics.Raycast(_firePoint.position, _firePoint.forward, out hit, _maxDistance))
        {
            _lineRenderer.SetPosition(1, hit.point);

            var enemy = hit.collider.GetComponent<IDamageble>();
            if (enemy != null)
            {
                enemy.TakeDamage(_gunCharacteristics.damage * Time.deltaTime);
            }
        }
        else
        {
            _lineRenderer.SetPosition(1, _firePoint.position + _firePoint.forward * _maxDistance);
        }
    }
}
