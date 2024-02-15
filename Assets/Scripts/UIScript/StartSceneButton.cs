using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    [Header("бс GameObject")]
    [SerializeField] private GameObject prefabOptionUI;

    [Header("бс Canvas")]
    [SerializeField] private Canvas canvas;

    private GameObject optionUI;
    private void Start()
    {
        optionUI = Instantiate(prefabOptionUI, canvas.transform);
        optionUI.SetActive(false);
    }
    public void OnClickStartBtn()
    {
        //LoadingSceneController.LoadScene("StageScene-KSM");
        LoadingSceneController.LoadScene("SSH_GameLogic");
    }

    public void ONClickOptionBtn()
    {
        Time.timeScale = 0f;
        optionUI.SetActive(true);
    }

    

    public void OnclickExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
