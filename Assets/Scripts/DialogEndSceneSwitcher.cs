using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEndSceneSwitcher : MonoBehaviour
{
    public DialogController dialogController;


    void Update()
    {
        if (dialogController.Finished)
        {
            GameState.instance.NextScene();
        }
    }
}
