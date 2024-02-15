using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MonsterType
{
    Patrol_Robot,
    Guard_Robot,
    Cook_Robot,
    Sweeper_Robot,
    Director_Robot,
}

public class Stage
{
    public string Name { get; private set; }
    public int Level { get; private set; }

    // Elevator Hp
    public int ElevatorHp { get; private set; }
    // Monsters generation Rate
    public float generateMonsterRate {  get; private set; }

    // TODO : Types of Monster which stage can generate.
    public MonsterType[] stageMonsters { get; private set; }

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

        switch (stageNumber)
        {
            case 5:
                ElevatorHp = 100;
                generateMonsterRate = 5f;
                stageMonsters = new MonsterType[] { MonsterType.Patrol_Robot, MonsterType.Guard_Robot };
                Reward = 30;
                break;
            case 4:
                ElevatorHp = 150;
                generateMonsterRate = 4.5f;
                stageMonsters = new MonsterType[] { MonsterType.Patrol_Robot, MonsterType.Guard_Robot, MonsterType.Cook_Robot };
                Reward = 40;
                break;
            case 3:
                ElevatorHp = 200;
                generateMonsterRate = 4f;
                stageMonsters = new MonsterType[] { MonsterType.Guard_Robot, MonsterType.Cook_Robot, MonsterType.Sweeper_Robot };
                Reward = 50;
                break;
            case 2:
                ElevatorHp = 250;
                generateMonsterRate = 3.5f;
                stageMonsters = new MonsterType[] { MonsterType.Cook_Robot, MonsterType.Sweeper_Robot, MonsterType.Director_Robot };
                Reward = 70;
                break;
            case 1:
                ElevatorHp = 300;
                generateMonsterRate = 3f;
                stageMonsters = new MonsterType[] { MonsterType.Cook_Robot, MonsterType.Sweeper_Robot, MonsterType.Director_Robot };
                Reward = 100;
                break;
        }
    }
}

public class StageManager : MonoBehaviour
{
    public Stage[] stages;
    public Stage currentStage;

    public event Action OnStageClear;
    public event Action OnStageOver;

    [HideInInspector] public Transform EnemyStopPosition;

    public GameObject elevator;

    private Elevator_Door elevatorDoor;

    public List<Units> playerUnits;

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
        elevatorDoor = elevator.GetComponent<Elevator_Door>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void StageSelect(int stageNum)
    {
        currentStage = new Stage(stageNum);
        elevatorDoor.maxHealth = currentStage.ElevatorHp;
        elevatorDoor.SetHP();
    }

    public void StageClear()
    {
        OnStageClear?.Invoke();
    }

    public void StageOver()
    {
        OnStageOver?.Invoke();
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
        if(scene.buildIndex == 8)
        {
            Instantiate(elevator);
        }
    }
}
