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

    private void OnDestroy()
    {
        StageManager.instance.OnStageClear -= StageClear;
        StageManager.instance.OnStageOver -= GameOver;
    }

    public void OnClickcontinueButton()
    {
        Time.timeScale = 1.0f;

        //LoadingSceneController.LoadScene("StageScene-KSM");
        if (StageManager.instance.currentStage.NowStage == 1)
        {
            Debug.Log("ending button");
            LoadingSceneController.LoadScene("Ending_KSM");
            return;
        }
        LoadingSceneController.LoadScene("SSH_GameLogic");
    }

    private void StageClear(int reward)
    {
        Debug.Log("StageClear");
        gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Clear!";
        rewardText.text = reward.ToString();
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        gameObject.SetActive(true);
        stageText.text = GameManager.instance.selectedStage.ToString();
        headText.text = "Game Over";
        rewardText.text = "0";
    }
}
