using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    SceneField scene;

    public void Switch()
    {
        SceneManager.LoadScene(scene);
    }
}
