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
        gameObject.SetActive(false);
        StageManager.instance.OnStageClear += StageClear;
        StageManager.instance.OnStageOver += GameOver;
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        StageManager.instance.OnStageClear -= StageClear;
        StageManager.instance.OnStageOver -= GameOver;
    }

    public void OnClickcontinueButton()
    {
        Time.timeScale = 1.0f;

        if (StageManager.instance.currentStage.NowStage == 1)
        {
            LoadingSceneController.LoadScene("Ending");
            return;
        }
        LoadingSceneController.LoadScene("SelectStage");
    }

    private void StageClear(int reward)
    {
        gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Clear!";
        rewardText.text = reward.ToString();
    }

    private void GameOver()
    {
        gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Game Over";
        rewardText.text = "0";
    }
}
