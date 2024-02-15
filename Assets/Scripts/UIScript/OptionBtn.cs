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
        if (SceneManager.GetActiveScene().name == "SSH_StartScene")
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
        if(SceneManager.GetActiveScene().name == "SSH_GameLogic")
        {
            LoadingSceneController.LoadScene("SSH_StartScene");
        }
        else
            LoadingSceneController.LoadScene("SSH_GameLogic");
    }

    public void OnClickOptionExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
