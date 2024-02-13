using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    [SerializeField] private GameObject optionUI;
    [SerializeField] private Canvas UIcanvas;

    private GameObject _optionUI;
    private void Start()
    {
        _optionUI = Instantiate(optionUI, UIcanvas.transform);
        _optionUI.SetActive(false);
    }
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("StageScene-KSM");
    }

    public void ONClickOptionBtn()
    {
        Time.timeScale = 0f;
        _optionUI.SetActive(true);
    }

    

    public void OnclickExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
