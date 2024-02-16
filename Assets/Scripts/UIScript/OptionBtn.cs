using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionBtn : MonoBehaviour
{
    [SerializeField] private GameObject backButtonObject;
    [SerializeField] private GameObject exitButtonObject;


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            backButtonObject.SetActive(false);
            exitButtonObject.SetActive(false);
        }
        else
        {
            backButtonObject.SetActive(true);
            exitButtonObject.SetActive(true);
        }

    }
    public void OnClickOptionCloseBtn()
   {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
   }

    public void OnClickOptionBackButton()
    {
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().name == "SelectStage")
        {
            LoadingSceneController.LoadScene("StartScene");
        }
        else
            LoadingSceneController.LoadScene("SelectStage");
    }

    public void OnClickOptionExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
