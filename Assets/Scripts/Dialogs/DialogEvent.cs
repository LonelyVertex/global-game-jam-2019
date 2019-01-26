using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogs/Dialog Event")]
public class DialogEvent : ScriptableObject
{
    public string title;

    [Header("Content")]
    public Sprite image;
    public string[] texts;
}
