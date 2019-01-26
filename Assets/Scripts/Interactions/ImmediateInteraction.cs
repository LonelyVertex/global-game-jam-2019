using UnityEngine;


public abstract class ImmediateInteraction : MonoBehaviour
{
    protected abstract string InteractionTag { get; }

    GameState gameState;

    bool interactionHappened = false;
    Collider currentCollider;


    void Start()
    {
        gameState = GameState.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameState.IsPlaying) return;
        if (interactionHappened) return;
        if (!other.CompareTag(InteractionTag)) return;

        currentCollider = other;
        interactionHappened = true;
        Interact(other);
    }

    void OnTriggerExit(Collider other)
    {
        if (!gameState.IsPlaying) return;
        if (!other.CompareTag(InteractionTag)) return;

        currentCollider = null;
    }

    protected abstract void Interact(Collider collider);
}
