using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    [Header("бс Text")]
    [SerializeField] private TextMeshProUGUI stageTxt;

    [Header("бс GameObject")]
    [SerializeField] private GameObject prefabOptionUI;
    [SerializeField] private GameObject stageLock;

    [Header("бс Canvas")]
    [SerializeField] private Canvas canvas;

    private int stage = 5;
    private bool isClear; // TODO : Check isClear in GameManager

    private GameObject optionUI;
    
    private void Start()
    {
        stageTxt.text = stage.ToString();
        if(isClear)
        {
            stageLock.SetActive(false);
        }

        optionUI = Instantiate(prefabOptionUI, canvas.transform);
        optionUI.SetActive(false);

    }

    private void Update()
    {
        stageTxt.text = stage.ToString();
    }


    public void OnClickUpBtn()
    {
        if (stage >= 5)
            return;

        stage++;
    }

    public void OnclickDownButton()
    {
        if (isClear)
        {
            if (stage < 1)
                return;

            stage--;
        }
    }

    public void OnStageSelectButton()
    {
        // TODO : Give the stage to GameManager
        GameManager.instance.StageSelect(stage);
        LoadingSceneController.LoadScene("StartScene-KSM");
    }

    public void OnClickOptionButton()
    {
        Time.timeScale = 0f;
        optionUI.SetActive(true);
    }

}
