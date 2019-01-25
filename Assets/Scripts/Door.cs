using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    bool open;

    [SerializeField]
    float openingSpeed;

    float currentRotation;
    float desiredRotation;
    float t;

    public void ToggleOpen()
    {
        open = !open;
        t = 0;
        desiredRotation = open ? 90 : 0;
    }

    void Update()
    {
        if (Mathf.Approximately(currentRotation, desiredRotation)) {
            currentRotation = desiredRotation;
        } else {
            currentRotation = Mathf.Lerp(currentRotation, desiredRotation, t);
            t += openingSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, currentRotation, 0));
    }

    void OnValidate()
    {
        var rotation = open ? 90 : 0;
        transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
    }
}