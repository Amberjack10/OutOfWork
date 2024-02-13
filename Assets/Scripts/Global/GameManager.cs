using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int stageCleared;

    public event Action<int> OnStageSelect;

    public int selectedStage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageManager.instance.OnStageClear += StageClear;
        if (PlayerPrefs.HasKey("StageCleared"))
        {
            stageCleared = PlayerPrefs.GetInt("StageCleared");
        }
        else stageCleared = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StageSelect(int index)
    {
        // If Selected Stage is locked
        if (index < stageCleared) return;

        // Load Stage Scene
        SceneManager.LoadScene("SSH_Stage");
        
        selectedStage = index;
        OnStageSelect?.Invoke(index);
    }

    // TODO : Stage Unlock
    private void StageClear()
    {
        stageCleared--;
        PlayerPrefs.SetInt("StageCleared", stageCleared);
    }

    // TODO : Skill point Manage.
}
