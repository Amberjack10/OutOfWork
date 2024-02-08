using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action OnStageClear;
    public event Action OnStageOver;

    // 제한 시간
    public float limitTime = 120.0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        limitTime -= Time.deltaTime;

        // 제한 시간 초과 시
        if(limitTime <= 0)
        {
            OnStageOver?.Invoke();
        }
    }

    // TODO : 스테이지 해금 및 클리어
    // TODO : 자원 관리
}
