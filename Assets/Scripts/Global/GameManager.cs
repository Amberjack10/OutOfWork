using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int stageCleared;

    public event Action<int> OnStageSelect;

    public int selectedStage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("StageCleared"))
        {
            PlayerPrefs.DeleteKey("StageCleared");
            stageCleared = PlayerPrefs.GetInt("StageCleared");
        }
        else stageCleared = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        StageManager.instance.OnStageClear += StageClear;
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
        SceneManager.LoadScene("Stage");
        
        selectedStage = index;
        OnStageSelect?.Invoke(index);
    }

    // TODO : Stage Unlock
    private void StageClear(int reward)
    {
        stageCleared--;
        PlayerPrefs.SetInt("StageCleared", stageCleared);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // StageManager.instance.OnStageClear += StageClear;
        if (PlayerPrefs.HasKey("StageCleared"))
        {
            stageCleared = PlayerPrefs.GetInt("StageCleared");
        }
        else stageCleared = 5;
    }

    // TODO : Skill point Manage.
}
