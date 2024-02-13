using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public Stage stage;
    public float timeLimit = 120f;

    // Player's In-game Unit Cost. Uses to Generate Unit.
    public int playerUnitCost = 0;
    public int maxPlayerUnitCost = 10;
    public float playerUnitCostRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe Player's Attack Event
        // OnElevatorAttack += OnTakeDamage;

        stage = StageManager.instance.currentStage;
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
        playerUnitCost++;
    }

    // Generate Units.
    public void OnUnitSelectButton(int index)
    {
        // if(playerUnitCost >= UnitCost) Instantiate(Unit);
        MakeUnits(index);
    }

    private void MakeUnits(int index)
    {
        Debug.Log($"Making Unit {index}");
    }

    private void MakeMonsters()
    {
        // TODO : Generate Monsters
        Debug.Log("MakingMonsters");
    }

    private void OnTakeDamage(int _damage)
    {
        stage.TakeDamage(_damage);

        // When ElevatorHp gets lower then 0
        if (stage.ElevatorHp <= 0)
        {
            // Stage Clear
            StageManager.instance.StageClear();
        }
    }
}
