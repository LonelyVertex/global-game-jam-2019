#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Transform doorWrapper;

    [SerializeField]
    bool open;

    [SerializeField]
    float openingSpeed;

    [SerializeField]
    float openRotation = 90;

    float currentRotation;
    float desiredRotation;
    float t;

    void Start()
    {
        SetDesiredRotation();
    }

    void SetDesiredRotation()
    {
        desiredRotation = open ? openRotation : 0;
    }

    public void ToggleOpen()
    {
        open = !open;
        t = 0;
        SetDesiredRotation();
    }

    void Update()
    {
        if (Mathf.Approximately(currentRotation, desiredRotation)) {
            currentRotation = desiredRotation;
        } else {
            currentRotation = Mathf.Lerp(currentRotation, desiredRotation, t);
            t += openingSpeed * Time.deltaTime;
        }

        doorWrapper.localRotation = Quaternion.Euler(new Vector3(0, currentRotation, 0));
    }

    void OnValidate()
    {
        if (doorWrapper != null) {
            var rotation = open ? openRotation : 0;
            doorWrapper.localRotation = Quaternion.Euler(new Vector3(0, rotation, 0));
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Handles.color = new Color(1f, 0.0f, 1f, 0.3f);
        Handles.DrawSolidArc(transform.position, transform.up, transform.right, openRotation, 1);
    }
#endif
}