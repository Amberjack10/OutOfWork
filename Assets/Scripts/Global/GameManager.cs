using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action OnStageClear;
    public event Action OnStageOver;

    // ���� �ð�
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

        // ���� �ð� �ʰ� ��
        if(limitTime <= 0)
        {
            OnStageOver?.Invoke();
        }
    }

    // TODO : �������� �ر� �� Ŭ����
    // TODO : �ڿ� ����
}
