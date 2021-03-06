﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameState : MonoBehaviour
{
    public static GameState instance = null;

    public SceneField nextScene;
    public float sceneSwitchDelay = 1.5f;

    public bool IsPlaying { get; private set; } = true;
    public bool IsShowingUI { get; private set; } = false;

    public SceneFade sceneFade;


    bool startedSceneLoad = false;

    void Awake()
    {
        if (instance == null) {
            instance = this;

        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneFade.FadeIn();
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
        if (startedSceneLoad) return;

        startedSceneLoad = true;
        StartCoroutine(NextSceneDelayed());
    }

    IEnumerator NextSceneDelayed()
    {
        sceneFade.FadeOut();

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
