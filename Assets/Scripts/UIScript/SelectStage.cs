using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI stageTxt;
    [SerializeField] private GameObject stageLock;

    private int stage = 5;

    private bool isClear; // TODO : Check isClear in GameManager

    private void Start()
    {
        stageTxt.text = stage.ToString();
        if(isClear)
        {
            stageLock.SetActive(false);
        }
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

    public void OnclickDownBtn()
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
        //SceneManager.LoadScene("GameScene");
    }
}
