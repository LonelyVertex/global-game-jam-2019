using UnityEngine;


public class FlashlightInteraction : MonoBehaviour
{
    [SerializeField]
    Flashlight flashlight;

    GameState gameState;

    void Start()
    {
        gameState = GameState.instance;
    }

    void Update()
    {
        if (!gameState.IsPlaying) return;

        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1))
        {
            flashlight.TurnOn();
        }

        if (Input.GetKeyUp(KeyCode.F) || Input.GetMouseButtonUp(1))
        {
            flashlight.TurnOff();
        }
    }
}
