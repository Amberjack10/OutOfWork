using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    [Header("�� GameObject")]
    [SerializeField] private GameObject prefabOptionUI;

    [Header("�� Canvas")]
    [SerializeField] private Canvas canvas;

    private GameObject optionUI;
    private void Start()
    {
        optionUI = Instantiate(prefabOptionUI, canvas.transform);
        optionUI.SetActive(false);
    }
    public void OnClickStartBtn()
    {
        LoadingSceneController.LoadScene("SelectStage");
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
