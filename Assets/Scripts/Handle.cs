using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Handle : BinaryStateObject
{
    public Transform leverWrapper;
    public List<Door> doors;

    public override void Toggle()
    {
        base.Toggle();
        foreach (var door in doors) {
            door.Toggle();
        }
    }

    protected override void ApplyValue(float value)
    {
        leverWrapper.localRotation = Quaternion.Euler(new Vector3(0, value, 0));
    }

    void OnDrawGizmos()
    {
        var collider = GetComponent<SphereCollider>();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + collider.center, collider.radius);
    }
}