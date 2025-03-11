using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<HealthController>();
        if (player != null)
        {
            player.Death();
        }
        
    }
}
