using UnityEngine;
using System.Collections;

public class MemoryImmediateInteraction : ImmediateInteraction
{
    protected override string InteractionTag => "MemoryImmediate";


    protected override void Interact(Collider collider)
    {
        var controller = collider.GetComponent<DialogController>();

        controller.StartDialog();
    }
}
