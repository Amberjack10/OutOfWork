using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public Stage stage;
    public float timeLimit = 120f;
    private List<Units> playerUnits;

    // Player's In-game Unit Cost. Uses to Generate Unit.
    [SerializeField] private int playerUnitCost = 0;
    [SerializeField] private int maxPlayerUnitCost = 100;
    [SerializeField] private float playerUnitCostRate = 2f;

    [SerializeField] private Transform playerUnitSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe Player's Attack Event
        // OnElevatorAttack += OnTakeDamage;

        stage = StageManager.instance.currentStage;
        playerUnits = StageManager.instance.playerUnits;
        StartRegenPlayerUnitCost();
        InvokeRepeating("MakeMonsters", 0, stage.generateMonsterRate);
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        if (timeLimit <= 0) StageManager.instance.StageOver();
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

    private void MakeMonsters()
    {
        // TODO : Generate Monsters
        Debug.Log("MakingMonsters");
        GameObject monsterUnit = Instantiate(Resources.Load("EnemyUnit/Director_Robot Variant")) as GameObject;
    }
}
