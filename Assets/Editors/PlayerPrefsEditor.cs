using UnityEditor;
using UnityEngine;

public static class PlayerPrefsEditor
{
    [MenuItem("Aqua Tools/Delete player prefs")]
    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}