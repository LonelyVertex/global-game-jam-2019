using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneSwitcher))]
[RequireComponent(typeof(DialogController))]
public class SceneStartTrigger : MonoBehaviour
{
    [SerializeField]
    float sceneSwitchDelay;

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
        yield return new WaitForSeconds(sceneSwitchDelay);

        sceneSwitcher.Switch();
    }
}
