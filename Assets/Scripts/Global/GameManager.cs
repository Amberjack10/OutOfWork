using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action OnStageClear;
    public event Action OnStageOver;
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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStageSelectButton(int index)
    {
        SceneManager.LoadScene("SSH_Stage");
        selectedStage = index;
        OnStageSelect?.Invoke(index);
    }

    // TODO : Stage Unlock
    // TODO : Skill point Manage.
}
