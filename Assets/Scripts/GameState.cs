using UnityEngine;


public class GameState : MonoBehaviour
{
    public static GameState instance = null;

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
}
