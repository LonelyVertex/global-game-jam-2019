using UnityEngine;


public class Flashlight : MonoBehaviour
{
    [SerializeField]
    Light spotlight;

    public AudioClip turnOnAudio, turnOffAudio;
    AudioSource audioSource;
    bool stateOn = false;

    private void Start()
    {
        spotlight.enabled = false;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
    }

    public void TurnOn()
    {
        spotlight.enabled = true;
        if (!stateOn) {
            audioSource.PlayOneShot(turnOnAudio);
            stateOn = true;
        }
    }

    public void TurnOff()
    {
        spotlight.enabled = false;
        if (stateOn) {
            audioSource.PlayOneShot(turnOffAudio);
            stateOn = false;
        }
    }
}
