using UnityEngine;
using UnityEngine.UI;


public class DialogHolder : MonoBehaviour
{
    public static DialogHolder instance = null;

    [SerializeField]
    GameObject canvasObject;
    [SerializeField]
    Text title;
    [SerializeField]
    Image image;
    [SerializeField]
    Text description;

    GameState gameState;


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
        gameState = GameState.instance;

        canvasObject = GameObject.Find("DialogCanvas");
        if (canvasObject == null) Debug.LogError("Missing DialogCanvas in scene");

        title = GameObject.Find("DialogTitle").GetComponent<Text>();
        image = GameObject.Find("DialogImage").GetComponent<Image>();
        description = GameObject.Find("DialogDescription").GetComponent<Text>();

        canvasObject.SetActive(false);
    }

    public Text GetTitle()
    {
        return title;
    }

    public Image GetImage()
    {
        return image;
    }

    public Text GetDescription()
    {
        return description;
    }

    public void ShowDialogCanvas()
    {
        canvasObject.SetActive(true);

        gameState.ShowUI();
    }

    public void HideDialogCanvas()
    {
        canvasObject.SetActive(false);

        gameState.HideUI();
    }
}
