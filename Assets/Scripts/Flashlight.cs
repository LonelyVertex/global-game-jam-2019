using UnityEngine;


public class Flashlight : MonoBehaviour
{
    [SerializeField]
    Light spotlight;


    private void Start()
    {
        spotlight.enabled = false;
    }

    public void TurnOn()
    {
        spotlight.enabled = true;
    }

    public void TurnOff()
    {
        spotlight.enabled = false;
    }
}
