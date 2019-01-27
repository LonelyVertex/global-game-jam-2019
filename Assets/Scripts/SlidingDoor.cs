using UnityEngine;

public class SlidingDoor : BinaryStateObject
{
    public Vector3 directionMask;
    public Transform doorTransform;


    protected override void ApplyValue(float value)
    {
        var position = doorTransform.localPosition;

        position.x = Mathf.Approximately(directionMask.x, 0) ? position.x : directionMask.x * value;
        position.y = Mathf.Approximately(directionMask.y, 0) ? position.y : directionMask.y * value;
        position.z = Mathf.Approximately(directionMask.z, 0) ? position.z : directionMask.z * value;

        doorTransform.localPosition = position;
    }
}
