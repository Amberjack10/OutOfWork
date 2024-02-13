using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string Name { get; private set; }
    public int Level { get; private set; }

    // Elevator Hp
    public int ElevatorHp { get; private set; }
    // Monsters generation Rate
    public float generateMonsterRate {  get; private set; }

    // TODO : Types of Monster which stage can generate.
    // public MonsterType[] stageMonsters;

    // Stage clear reward. It'll be used for skill upgrades.
    public int Reward { get; private set; }

    public void TakeDamage(int damage)
    {
        ElevatorHp -= damage;
    }

    // Temporary constructor. Will revise later.
    public Stage(int stageNumber)
    {
        Name = "Stage" + stageNumber.ToString();
        Level = stageNumber;

        if (stageNumber == 0)
        {
            ElevatorHp = 100;
            generateMonsterRate = 5f;
            Reward = 3;
        }
        else if (stageNumber == 1)
        {
            ElevatorHp = 150;
            generateMonsterRate = 4f;
            Reward = 5;
        }
        else
        {
            ElevatorHp = 200;
            generateMonsterRate = 3f;
            Reward = 10;
        }
    }
}

public class StageManager : MonoBehaviour
{
    public Stage[] stages;
    public Stage currentStage;

    public event Action OnStageClear;
    public event Action OnStageOver;

    public static StageManager instance;

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
        GameManager.instance.OnStageSelect += StageSelect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StageSelect(int stageNum)
    {
        currentStage = new Stage(stageNum);
    }

    public void StageClear()
    {
        OnStageClear?.Invoke();
    }

    public void StageOver()
    {
        OnStageOver?.Invoke();
    }

    // TODO : Making Stage, Stage Fail
}
