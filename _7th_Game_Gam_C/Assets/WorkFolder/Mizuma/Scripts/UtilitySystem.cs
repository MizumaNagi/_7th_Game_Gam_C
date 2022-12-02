using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilitySystem
{
    public static void EndGame()
    {
#if UNITY_EDITOR
        Debug.LogError("UtilitySystem.EndGame()が呼ばれた為、終了します。");
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
