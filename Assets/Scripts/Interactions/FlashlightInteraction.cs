using UnityEngine;


public class FlashlightInteraction : MonoBehaviour
{
    [SerializeField]
    Flashlight flashlight;


    void Update()
    {
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
