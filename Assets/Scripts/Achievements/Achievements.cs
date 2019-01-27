using UnityEngine;

public static class Achievements
{
    public static bool IsUnlocked(Achievement achievement)
    {
        return PlayerPrefs.GetInt(GetKey(achievement), 0) > 0;
    }

    public static void Unlock(Achievement achievement)
    {
        PlayerPrefs.SetInt(GetKey(achievement), 1);
    }

    static string GetKey(Achievement achievement)
    {
        return "Achievement" + achievement;
    }
}
