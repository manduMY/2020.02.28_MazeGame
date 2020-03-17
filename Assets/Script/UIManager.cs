using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        SceneLoader.Instance.LoadScene("StageSelect");
    }
    public void OnClickExitBtn()
    {
        Application.Quit();
    }
    public void OnClickStage1()
    {
        SceneLoader.Instance.LoadScene("Stage1");
    }
    public void OnClickStage2()
    {
        SceneLoader.Instance.LoadScene("Stage2");
    }
}
