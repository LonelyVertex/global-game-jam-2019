using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneSwitcher))]
[RequireComponent(typeof(DialogController))]
public class SceneStartTrigger : MonoBehaviour
{
    SceneSwitcher sceneSwitcher;
    DialogController controller;


    void Start()
    {
        controller = GetComponent<DialogController>();
        sceneSwitcher = GetComponent<SceneSwitcher>();

        controller.StartDialog();

        StartCoroutine(SwitchScene());
    }

    IEnumerator SwitchScene()
    {
        var dialog = GameObject.Find("DialogCanvas");

        while (dialog.activeSelf) {
            yield return null;
        }

        GameState.instance.NextScene();
    }
}
