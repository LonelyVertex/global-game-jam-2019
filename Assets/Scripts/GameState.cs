using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameState : MonoBehaviour
{
    const string CURRENT_SCENE = "CURRENT_SCENE";

    public static GameState instance = null;

    public SceneField nextScene;
    public float sceneSwitchDelay = 1.5f;

    public bool IsPlaying { get; private set; } = true;
    public bool IsShowingUI { get; private set; } = false;

    void Awake()
    {
        if (instance == null) {
            instance = this;

        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public void Play()
    {
        IsPlaying = true;
        IsShowingUI = !IsPlaying;
    }

    public void Pause()
    {
        IsPlaying = false;
    }

    public void ShowUI()
    {
        IsShowingUI = true;
        IsPlaying = false;
    }

    public void HideUI()
    {
        IsShowingUI = false;
        IsPlaying = true;
    }

    public void NextScene()
    {
        StartCoroutine(NextSceneDelayed());
    }

    IEnumerator NextSceneDelayed()
    {
        var sceneLoading = SceneManager.LoadSceneAsync(nextScene);
        sceneLoading.allowSceneActivation = false;

        var progress = 0f;
        while (sceneLoading.progress < 0.9f || progress < sceneSwitchDelay) {
            progress += Time.deltaTime;
            yield return null;
        }

        sceneLoading.allowSceneActivation = true;
    }
}
