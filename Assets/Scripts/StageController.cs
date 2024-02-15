using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public Stage stage;
    public float timeLimit = 10f;
    private List<Units> playerUnits;

    // Player's In-game Unit Cost. Uses to Generate Unit.
    [Header("Unit Cost")]
    [SerializeField] private int playerUnitCost = 0;
    [SerializeField] private int maxPlayerUnitCost = 100;
    [SerializeField] private float playerUnitCostRate = 2f;

    [SerializeField] private Transform playerUnitSpawnPoint;
    [SerializeField] private Transform enemySpawnPosition;

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
        // Subscribe Player's Attack Event
        // OnElevatorAttack += OnTakeDamage;

        stage = StageManager.instance.currentStage;
        playerUnits = StageManager.instance.playerUnits;

        StartRegenPlayerUnitCost();

        stageUI = Instantiate(uiPrefab);
        clearPopupPrefab = Instantiate(clearPopupPrefab);

        coinText = stageUI.GetComponentInChildren<TextMeshProUGUI>();
        timer = stageUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        timer.text = $"{((int)timeLimit / 60).ToString():D2}:{((int)timeLimit % 60).ToString("D2")}";

        MakeMonsters(stage.stageMonsters);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = playerUnitCost.ToString();

        timeLimit -= Time.deltaTime;

        timer.text = $"{((int)timeLimit / 60).ToString():D2}:{((int)timeLimit % 60).ToString("D2")}";

        if (timeLimit <= 0)
        {
            StageManager.instance.StageOver();
        }
    }

    public void StartRegenPlayerUnitCost()
    {
        InvokeRepeating("RegenPlayerUnitCost", 0, playerUnitCostRate);
    }

    public void RegenPlayerUnitCost()
    {
        if (playerUnitCost >= maxPlayerUnitCost) return;
        playerUnitCost += 5;
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
                    enemySpawnRate += 2;
                    break;
                case MonsterType.Cook_Robot:
                    enemySpawnRate += 3;
                    break;
                case MonsterType.Sweeper_Robot:
                    enemySpawnRate += 5;
                    break;
                case MonsterType.Director_Robot:
                    enemySpawnRate += 7;
                    break;
            }

            StartCoroutine(GenerateMonster(enemyPrefabs[(int)monsterType], enemySpawnRate));
        }
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
