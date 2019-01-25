using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInteraction : Interaction
{
    protected override string InteractionTag { get { return "Handles";  } }

    protected override void Interact(Collider collider)
    {
        var handle = collider.GetComponent<Handle>();

        handle.TriggerHandle();
    }
}
