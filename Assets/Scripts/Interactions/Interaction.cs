using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    protected abstract string InteractionTag { get; }

    bool interactionEnabled = false;
    Collider currentCollider;


    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(InteractionTag)) return;

        currentCollider = other;

        ShowInteractionPopup();
        interactionEnabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(InteractionTag)) return;

        currentCollider = null;

        ShowInteractionPopup();
        interactionEnabled = false;
    }

    protected void ShowInteractionPopup()
    {
        Debug.Log("Show interaction popup!");
    }

    void Update()
    {
        if (!interactionEnabled) return;

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Interact(currentCollider);
        }
    }

    protected abstract void Interact(Collider collider);
}
