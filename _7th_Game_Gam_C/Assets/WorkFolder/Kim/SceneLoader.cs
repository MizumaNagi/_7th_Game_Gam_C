using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public CanvasGroup fadecg;

    [Range(0.5f, 2.0f)]
    public float fadeDuration = 1.0f;

    public Dictionary<string, LoadSceneMode> loadScenes = new Dictionary<string, LoadSceneMode>();

    void InitSceneInfo()
    {
        loadScenes.Add("Title", LoadSceneMode.Additive);
        loadScenes.Add("Result", LoadSceneMode.Additive);
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        InitSceneInfo();

        fadecg.alpha = 1.0f;

        foreach (var _loadScene in loadScenes)
        {
            yield return StartCoroutine(LoadScene(_loadScene.Key, _loadScene.Value));
        }

        StartCoroutine(Fade(0.0f));
    }

    IEnumerator LoadScene(string sceneName, LoadSceneMode mode)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, mode);

        Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(loadedScene);
    }

    IEnumerator Fade(float finalAlpha)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Title"));
        fadecg.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(fadecg.alpha - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadecg.alpha, finalAlpha))
        {
            fadecg.alpha = Mathf.MoveTowards(fadecg.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        fadecg.blocksRaycasts = false;

        SceneManager.UnloadSceneAsync("SceneLoading");
        SceneManager.UnloadSceneAsync("Title");
    }

    // Update is called once per frame
    void Update()
    {

    }
}