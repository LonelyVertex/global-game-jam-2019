
using UnityEngine;


public class FloorToggleInteraction : ImmediateInteraction
{
    protected override string InteractionTag => "FloorToggle";


    protected override void Interact(Collider collider)
    {
        Debug.Log("Interacted");

        var toggle = collider.GetComponent<FloorToggle>();

        toggle.Toggle();
    }
}
