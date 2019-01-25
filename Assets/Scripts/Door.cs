using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    bool open;

    public void ToggleOpen()
    {
        open = !open;
        StateChanged();
    }

    void StateChanged()
    {
        // TODO do something to change visual state and collider
    }

    void OnValidate()
    {
        StateChanged();
    }
}
