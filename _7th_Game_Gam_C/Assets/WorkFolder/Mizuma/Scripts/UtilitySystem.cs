using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilitySystem
{
    public static void EndGame()
    {
#if UNITY_EDITOR
        Debug.LogError("UtilitySystem.EndGame()���Ă΂ꂽ�ׁA�I�����܂��B");
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
