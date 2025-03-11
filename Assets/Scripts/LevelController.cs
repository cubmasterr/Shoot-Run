using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    private void Start()
    {
        _levels[Random.Range(0, _levels.Count)].SetActive(true); 
    }
}