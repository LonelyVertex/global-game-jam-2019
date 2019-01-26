using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DialogController : MonoBehaviour
{
    [SerializeField]
    Dialog dialog;

    [SerializeField]
    float textDelay = 1.5f;

    GameState gameState;
    DialogHolder dialogHolder;

    Text title;
    Image image;
    Text description;

    void Start()
    {
        gameState = GameState.instance;
        dialogHolder = DialogHolder.instance;

        title = dialogHolder.GetTitle();
        image = dialogHolder.GetImage();
        description = dialogHolder.GetDescription();
    }

    public void StartDialog()
    {
        StartCoroutine(PlayDialog());
    }

    IEnumerator PlayDialog()
    {
        dialogHolder.ShowDialogCanvas();

        var events = dialog.dialogEvents;

        foreach (var e in events)
        {
            title.text = e.title;
            image.sprite = e.image;

            foreach (var t in e.texts)
            {
                description.text = t;

                yield return new WaitForSeconds(textDelay);
            }
        }

        dialogHolder.HideDialogCanvas();
    }
}
