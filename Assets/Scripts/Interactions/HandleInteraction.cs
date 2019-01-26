using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInteraction : Interaction
{
    protected override string InteractionTag => "Handle";

    protected override void Interact(Collider collider)
    {
        var handle = collider.GetComponent<Handle>();

        handle.Toggle();
    }
}
