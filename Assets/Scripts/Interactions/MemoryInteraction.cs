using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryInteraction : Interaction
{
    protected override string InteractionTag => "Memory";


    protected override void Interact(Collider collider)
    {
        var controller = collider.GetComponent<DialogController>();

        controller.StartDialog();
    }
}
