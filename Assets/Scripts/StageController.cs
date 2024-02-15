using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public Stage stage;
    public float timeLimit = 180f;
    private List<Units> playerUnits;

    private bool attendence_boss;

    [SerializeField] private GameObject elevator;
    [SerializeField] private Elevator_Door elevatorDoor;
    public float elevatorHPRate;

    // Player's In-game Unit Cost. Uses to Generate Unit.
    [Header("Unit Cost")]
    [SerializeField] private int playerUnitCost = 0;
    [SerializeField] private int maxPlayerUnitCost = 100;
    [SerializeField] private float playerUnitCostRate = 2f;

    [SerializeField] private Transform playerUnitSpawnPoint;
    [SerializeField] private Transform enemySpawnPosition;
    [SerializeField] private Transform enemyStopPosition;

    [Header("UI")]
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private GameObject clearPopupPrefab;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI timer;

    [Header("Enemy Unit")]
    [SerializeField] private GameObject[] enemyPrefabs;

    private GameObject stageUI;

    // Start is called before the first frame update
    void Start()
    {
        StageManager.instance.EnemyStopPosition = enemyStopPosition;
        StageManager.instance.ElevatorPosition = elevator.transform;

        stage = StageManager.instance.currentStage;
        playerUnits = StageManager.instance.playerUnits;

        elevatorDoor = elevator.GetComponent<Elevator_Door>();

        elevatorDoor.maxHealth = StageManager.instance.currentStage.ElevatorHp;
        elevatorDoor.SetHP();

        StartRegenPlayerUnitCost();

        stageUI = Instantiate(uiPrefab);
        //clearPopupPrefab = Instantiate(clearPopupPrefab);

        coinText = stageUI.GetComponentInChildren<TextMeshProUGUI>();
        timer = stageUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        timer.text = $"{((int)timeLimit / 60).ToString():D2}:{((int)timeLimit % 60).ToString("D2")}";

        MakeMonsters(stage.stageMonsters);

        attendence_boss = false;
    }

    // Update is called once per frame
    void Update()
    {
        elevatorHPRate = elevatorDoor.HealthRate;

        if (!attendence_boss)
        {
            switch (stage.NowStage)
            {
                case 5:
                    if (elevatorHPRate <= 0.8)
                    {
                        MakeBoss();
                    }
                    break;
                default:
                    if (elevatorHPRate <= 0.5)
                    {
                        MakeBoss();
                    }
                    break;
            }
        }

        coinText.text = playerUnitCost.ToString();

        timeLimit -= Time.deltaTime;

        timer.text = $"{((int)timeLimit / 60).ToString():D2}:{((int)timeLimit % 60).ToString("D2")}";
    }
    private void FixedUpdate()
    {
        if (timeLimit <= 0)
        {
            StageManager.instance.StageOver();
            Time.timeScale = 0;
        }
    }

    public void StartRegenPlayerUnitCost()
    {
        InvokeRepeating("RegenPlayerUnitCost", 0, playerUnitCostRate);
    }

    public void RegenPlayerUnitCost()
    {
        if (playerUnitCost >= maxPlayerUnitCost) return;
        playerUnitCost += 25;
    }

    // Generate Units.
    public void OnUnitSelectButton(int index)
    {
        if (playerUnitCost >= playerUnits[index].price)
        {
            MakeUnits(index);
            playerUnitCost = playerUnitCost - playerUnits[index].price > 0 ? playerUnitCost - playerUnits[index].price : 0;
        }
        else return;
    }

    private void MakeUnits(int index)
    {
        Debug.Log($"Making Unit {index}");
        GameObject playerUnit = Instantiate(playerUnits[index].unitPrefab, playerUnitSpawnPoint.position, Quaternion.identity);
    }

    private void MakeMonsters(MonsterType[] monster)
    {
        // TODO : Generate Monsters

        float enemySpawnRate;

        foreach(MonsterType monsterType in stage.stageMonsters)
        {
            enemySpawnRate = stage.generateMonsterRate;
            switch (monsterType)
            {
                case MonsterType.Patrol_Robot:
                    enemySpawnRate += 0;
                    break;
                case MonsterType.Guard_Robot:
                    enemySpawnRate *= (stage.NowStage < 4 ? 10f : 6f);
                    break;
                case MonsterType.Cook_Robot:
                    enemySpawnRate *= (stage.NowStage < 4 ? 2.5f : 4f);
                    break;
                case MonsterType.Sweeper_Robot:
                    enemySpawnRate *= 8f;
                    break;
                case MonsterType.Director_Robot:
                    enemySpawnRate *= 15f;
                    break;
            }

            StartCoroutine(GenerateMonster(enemyPrefabs[(int)monsterType], enemySpawnRate));
        }
    }

    private void MakeBoss()
    {
        Instantiate(enemyPrefabs[(int)MonsterType.Attendence_Recoder], enemySpawnPosition.position, Quaternion.identity);
        attendence_boss = true;
    }

    IEnumerator GenerateMonster(GameObject monster, float enemySpawnRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnRate);

            GameObject monsterPrefab = Instantiate(monster, enemySpawnPosition.position, Quaternion.identity);
        }
    }
}
