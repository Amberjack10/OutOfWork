using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void OnClickOptionBtn()
    {

    }

    public void OnclickExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
