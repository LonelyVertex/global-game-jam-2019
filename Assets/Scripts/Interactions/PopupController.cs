using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

public class PopupController : MonoBehaviour
{
    [SerializeField]
    PlayableDirector director;
    [SerializeField]
    PlayableAsset popupAnim;

    public void Trigger()
    {
        director.Play(popupAnim);
    }
}
