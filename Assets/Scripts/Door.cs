#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Door : BinaryStateObject
{
    public Transform doorWrapper;

    protected override void ApplyValue(float value)
    {
        doorWrapper.localRotation = Quaternion.Euler(new Vector3(0, value, 0));
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Handles.color = new Color(1f, 0.0f, 1f, 0.3f);
        Handles.DrawSolidArc(transform.position, transform.up, transform.right, openValue, 1);
    }
#endif
}