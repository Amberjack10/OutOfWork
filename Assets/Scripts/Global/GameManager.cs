using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action OnStageClear;
    public event Action OnStageOver;

    // Time Limit
    public float limitTime = 120.0f;

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
        limitTime -= Time.deltaTime;

        // Reached Time Limit
        if(limitTime <= 0)
        {
            OnStageOver?.Invoke();
        }
    }

    // TODO : Stage Unlock
    // TODO : Skill point Manage.
}
