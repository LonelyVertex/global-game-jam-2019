using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogs/Dialog")]
public class Dialog : ScriptableObject
{
    public DialogEvent[] dialogEvents;
}
