﻿using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    protected abstract string InteractionTag { get; }
    protected GameState gameState;

    [SerializeField]
    PopupController popupController;

    bool interactionEnabled = false;
    Collider currentCollider;


    void Start()
    {
        gameState = GameState.instance;
    }

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
        interactionEnabled = false;
    }

    protected void ShowInteractionPopup()
    {
        popupController.Trigger();
    }

    void Update()
    {
        if (!gameState.IsPlaying) return;
        if (!interactionEnabled) return;

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
        {
            Interact(currentCollider);
        }
    }

    protected abstract void Interact(Collider collider);
}
