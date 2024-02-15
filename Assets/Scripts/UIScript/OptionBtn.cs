using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionBtn : MonoBehaviour
{
    [SerializeField] private GameObject exitButtonObject;


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SSH_StartScene 1")
        {
            exitButtonObject.SetActive(false);
        }
        else
        {
            exitButtonObject.SetActive(true);
        }

    }
    public void OnClickOptionCloseBtn()
   {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
   }

    public void OnClickOptionBackBtn()
    {
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().name == "SSH_GameLogic")
        {
            LoadingSceneController.LoadScene("SSH_StartScene 1");
        }
        else
            LoadingSceneController.LoadScene("SSH_GameLogic");
    }
}
