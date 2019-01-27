using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class SlidingDoorHandle : BinaryStateObject
{
    public List<SlidingDoor> doors;

    public override void Toggle()
    {
        base.Toggle();
        foreach (var door in doors)
        {
            door.Toggle();
        }
    }

    protected override void ApplyValue(float value) { }
}
