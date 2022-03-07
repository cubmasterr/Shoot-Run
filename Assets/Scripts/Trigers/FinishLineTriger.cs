using UnityEngine;

public class FinishLineTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameStateManager.Instance.LineFinished();
    }
}