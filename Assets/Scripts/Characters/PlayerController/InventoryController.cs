using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;
    private int _currentWeaponIndex = 0;

    void Start()
    {
        UpdateWeapon();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            NextWeapon();
        }
        else if (scroll < 0f)
        {
            PreviousWeapon();
        }
    }

   private void NextWeapon()
    {
        _currentWeaponIndex = (_currentWeaponIndex + 1) % _weapons.Length;
        UpdateWeapon();
    }

    private void PreviousWeapon()
    {
        _currentWeaponIndex--;
        if (_currentWeaponIndex < 0)
        {
            _currentWeaponIndex = _weapons.Length - 1;
        }
        UpdateWeapon();
    }

    private void UpdateWeapon()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].SetActive(i == _currentWeaponIndex);
        }
    }
}
