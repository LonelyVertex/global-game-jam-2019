using UnityEngine;

public abstract class BinaryStateObject : MonoBehaviour
{
    public bool open;
    public float openValue;
    public float notOpenValue;
    public float openingSpeed;

    float currentValue;
    float desiredValue;
    float t;

    float DesiredValue => open ? openValue : notOpenValue;

    void Start()
    {
        currentValue = DesiredValue;
        SetDesiredValue();
    }

    public virtual void Toggle()
    {
        open = !open;
        t = 0;
        SetDesiredValue();
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