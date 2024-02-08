using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string Name { get; private set; }
    public int Level { get; private set; }

    // TODO : ���� ������ ���� ����
    // public MonsterType[] stageMonsters;

    // �������� Ŭ���� �� ����. ��ų ��ȭ�� ��ȭ
    public int Reward { get; private set; }
}

public class StageManager : MonoBehaviour
{
    public Stage[] stages;
    public Stage currentStage;

    public static StageManager instance;

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
        
    }

    public void OnStageSelectButton(int index)
    {
        currentStage = stages[index];
    }
}
