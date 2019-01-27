using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FloorToggle : BinaryStateObject
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

    protected override void ApplyValue(float value) {}
}
