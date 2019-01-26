using UnityEngine;

public class FlashlightWallAvoider : MonoBehaviour
{
    public bool IsNearWall { get; private set; }

    [SerializeField]
    Transform flashlightTransform;

    void Start()
    {
        flashlightTransform = GetComponent<Transform>();
    }

    void Update()
    {
        IsNearWall = Physics.Raycast(flashlightTransform.position, flashlightTransform.forward, out var hit) && hit.distance < 0.5f;
    }
}
