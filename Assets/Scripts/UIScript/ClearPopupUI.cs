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
        StageManager.instance.OnStageClear += StageClear;
        StageManager.instance.OnStageOver += GameOver;
    }

    private void Update()
    {
        
    }

    public void OnClickcontinueButton()
    {
        LoadingSceneController.LoadScene("StageScene-KSM");
    }

    private void StageClear()
    {
        this.gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Clear!";
    }

    private void GameOver()
    {
        this.gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Game Over";
        rewardText.text = "0";
    }
}
