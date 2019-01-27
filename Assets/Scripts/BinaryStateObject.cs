using UnityEngine;

public abstract class BinaryStateObject : MonoBehaviour
{
    public bool open;
    public float openValue;
    public float notOpenValue;
    public float openingSpeed;

    public AudioClip openAudio, closeAudio;
    AudioSource audioSource;

    float currentValue;
    float desiredValue;
    float t;

    float DesiredValue => open ? openValue : notOpenValue;

    void Start()
    {
        currentValue = DesiredValue;
        SetDesiredValue();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
    }

    public virtual void Toggle()
    {
        open = !open;
        t = 0;
        SetDesiredValue();

        if (open) {
            audioSource.PlayOneShot(openAudio);
        } else {
            audioSource.PlayOneShot(closeAudio);
        }
    }

    void SetDesiredValue()
    {
        desiredValue = DesiredValue;
    }

    void Update()
    {
        if (Mathf.Approximately(currentValue, desiredValue)) {
            currentValue = desiredValue;
        } else {
            currentValue = Mathf.Lerp(currentValue, desiredValue, t);
            t += openingSpeed * Time.deltaTime;
        }

        ApplyValue(currentValue);
    }

    void OnValidate()
    {
        ApplyValue(DesiredValue);
    }

    protected abstract void ApplyValue(float value);
}