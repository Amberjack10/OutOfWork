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
}

public class StageManager : MonoBehaviour
{
    public Stage[] stages;
    public Stage currentStage;

    public event Action OnStageClear;

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
        // Subscribe Player's Attack Event
        // OnElevatorAttack += OnTakeDamage;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStageSelectButton(int index)
    {
        currentStage = stages[index];
        MakeStage();
    }

    private void MakeStage()
    {
        InvokeRepeating("MakeMonsters", 0f, currentStage.generateMonsterRate);
    }

    private void MakeMonsters()
    {
        // TODO : Instantiate(generate monsters);
    }

    private void OnTakeDamage(int _damage)
    {
        currentStage.TakeDamage(_damage);

        // When ElevatorHp gets lower then 0
        if(currentStage.ElevatorHp <= 0)
        {
            // Stage Clear
            OnStageClear?.Invoke();
        }
    }

    // TODO : Making Stage, Stage Fail
}
