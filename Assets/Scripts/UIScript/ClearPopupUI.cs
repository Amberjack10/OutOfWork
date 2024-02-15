using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearPopupUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private TextMeshProUGUI headText;

    private void Start()
    {
        Debug.Log("Popup Start");
        gameObject.SetActive(false);
        StageManager.instance.OnStageClear += StageClear;
        StageManager.instance.OnStageOver += GameOver;
    }

    private void Update()
    {
        
    }

    public void OnClickcontinueButton()
    {
        LoadingSceneController.LoadScene("SSH_GameLogic");
    }

    private void StageClear()
    {
        Debug.Log("StageClear");
        this.gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Clear!";
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        this.gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Game Over";
        rewardText.text = "0";
    }
}
