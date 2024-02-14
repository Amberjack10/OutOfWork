using System;
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
    [SerializeField] private GameObject upButton;
    [SerializeField] private GameObject downButton;

    [Header("бс Canvas")]
    [SerializeField] private Canvas canvas;

    private int stage = 5;
    private bool isClear; // TODO : Check isClear in GameManager

    private GameObject optionUI;
    
    private void Start()
    {
        stageTxt.text = stage.ToString();
        //if(isClear)
        //{
        //    stageLock.SetActive(false);
        //}
        if (GameManager.instance.stageCleared < int.Parse(stageTxt.text))
        {
            stageLock.SetActive(false);
        }

        if(stage == 5)
        {
            upButton.SetActive(false);
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

        // If downButton was deactivated
        if (downButton.activeSelf == false) downButton.SetActive(true);

        stage++;
        stageTxt.text = stage.ToString();

        // If Elevator reached 5th floor, deactivate upButton.
        if (stage >= 5)
            upButton.SetActive(false);
    }

    public void OnclickDownButton()
    {
        if (GameManager.instance.stageCleared < int.Parse(stageTxt.text))
        {
            if (stage < 1)
                return;

            stage--;
            stageTxt.text = stage.ToString();

            SetStageLock();

            // If upButton was deactivated
            if (upButton.activeSelf == false) upButton.SetActive(true);
        }
        else return;
    }

    private void SetStageLock()
    {
        // If Elevator reached 1st floor, deactivate downButton.
        if (stage <= 1)
        {
            downButton.SetActive(false);
        }
        else if (GameManager.instance.stageCleared < int.Parse(stageTxt.text)) return;
        else stageLock.SetActive(true);
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
