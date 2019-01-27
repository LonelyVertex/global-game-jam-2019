using UnityEngine;


public class InGameUIController : MonoBehaviour
{
    public SceneField menuScene;
    public GameObject uiObject;

    GameState gameState;


    public void ToMenu()
    {
        gameState.nextScene = menuScene;
        gameState.NextScene();
    }

    public void Continue()
    {
        uiObject.SetActive(false);
    }

    void Start()
    {
        uiObject.SetActive(false);
        gameState = GameState.instance;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            uiObject.SetActive(!uiObject.activeSelf);
        }
    }
}
