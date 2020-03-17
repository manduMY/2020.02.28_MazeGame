using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    public Dictionary<string, LoadSceneMode> loadScenes = new Dictionary<string, LoadSceneMode>();

    void InitSceneInfo()
    {
        // 호출할 씬 사전에 기록
        loadScenes.Add("StageSelect", LoadSceneMode.Additive);
        //loadScenes.Add("Game", LoadSceneMode.Additive);
    }

    //IEnumerator Start()
    //{
    //    InitSceneInfo();

    //    foreach (var _loadScene in loadScenes)
    //    {
    //        yield return StartCoroutine(LoadScene(_loadScene.Key, _loadScene.Value));
    //    }
    //}

    IEnumerator foreachLoad()
    {
        foreach (var _loadScene in loadScenes)
        {
            yield return StartCoroutine(LoadScene(_loadScene.Key, _loadScene.Value));
        }
        //StartCoroutine(FadeFlow());
    }
    public void Fade()
    {
        InitSceneInfo();

        //foreachLoad();

        StartCoroutine(FadeFlow());
    }
    
    IEnumerator LoadScene(string sceneName, LoadSceneMode mode)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, mode);

        Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(loadedScene);
    }
    IEnumerator FadeFlow()
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("StageSelect"));
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            /*Fade Out 처리*/
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;

        

        foreach (var _loadScene in loadScenes)
        {
            yield return StartCoroutine(LoadScene(_loadScene.Key, _loadScene.Value));
        }

        Scene scene = SceneManager.GetSceneByName("StageSelect");
        SceneManager.MoveGameObjectToScene(Panel.gameObject,scene);

        // 대기시간을 1초 준다
        yield return new WaitForSeconds(1f);

        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("StageSelect"));

        while (alpha.a > 0f)
        {
            //Debug.Log("gogo:"+alpha.a);
            /*Fade In 처리*/
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;

        //foreach (var _loadScene in loadScenes)
        //{
        //    yield return StartCoroutine(LoadScene(_loadScene.Key, _loadScene.Value));
        //}
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("StageSelect"));
        SceneManager.UnloadSceneAsync("Main");

    }
}
