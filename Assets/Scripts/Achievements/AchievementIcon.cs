using UnityEngine;

public class AchievementIcon : MonoBehaviour
{
    public Achievement achievement;
    public GameObject locked;
    public GameObject unlocked;

    void Start()
    {
        if (Achievements.IsUnlocked(achievement)) {
            locked.SetActive(false);
            unlocked.SetActive(true);
        } else {
            locked.SetActive(true);
            unlocked.SetActive(false);
        }
    }
}