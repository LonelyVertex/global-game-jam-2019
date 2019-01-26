using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    public Transform target;
    public MeshCollider stairsCollider;

    public void DisableStairsCollider()
    {
        stairsCollider.enabled = false;
    }
}