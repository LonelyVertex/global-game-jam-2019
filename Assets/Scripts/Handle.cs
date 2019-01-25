using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField]
    bool on;

    public List<Door> doors;

    public void TriggerHandle()
    {
        foreach (var door in doors) {
            door.ToggleOpen();
        }

        on = !on;
        StateChanged();
    }

    void StateChanged()
    {
        // TODO do something to change visual state of the handle
    }

    void OnValidate()
    {
        StateChanged();
    }
}
