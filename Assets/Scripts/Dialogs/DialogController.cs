using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DialogController : MonoBehaviour
{
    [SerializeField]
    Dialog dialog;

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

        yield return null;

        foreach (var e in events) {
            title.text = e.title;
            image.sprite = e.image;

            foreach (var t in e.texts) {
                yield return null;
                description.text = t;

                while (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetKeyDown(KeyCode.E) &&
                       !Input.GetKeyDown(KeyCode.F)) {
                    yield return null;
                }
            }
        }

        dialogHolder.HideDialogCanvas();
    }
}