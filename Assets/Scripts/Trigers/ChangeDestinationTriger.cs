using UnityEngine;

public  class  ChangeDestinationTriger : MonoBehaviour
{
    [SerializeField] private Transform _nextWayPoint;

    private void OnTriggerEnter(Collider other)
    {
        var iSetDestination = other.GetComponent<IAchievable>();
        if (iSetDestination != null)
        {
            iSetDestination.SetAchievable(_nextWayPoint.position);
        }
    }
}