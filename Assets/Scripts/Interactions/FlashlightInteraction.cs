using UnityEngine;


public class FlashlightInteraction : MonoBehaviour
{
    [SerializeField]
    Flashlight flashlight;
    [SerializeField]
    FlashlightWallAvoider wallAvoider;

    GameState gameState;

    bool pressing;

    void Start()
    {
        gameState = GameState.instance;
    }

    void Update()
    {
        if (!gameState.IsPlaying) return;

        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            pressing = true;
        }

        if (Input.GetKeyUp(KeyCode.F) || Input.GetMouseButtonUp(0))
        {
            pressing = false;
        }

        if (pressing && !wallAvoider.IsNearWall) {
            flashlight.TurnOn();
        } else {
            flashlight.TurnOff();
        }

    }
}
