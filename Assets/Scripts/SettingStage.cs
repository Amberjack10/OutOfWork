using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingStage : MonoBehaviour
{
    public Stage stage;
    public float timeLimit = 120f;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe Player's Attack Event
        // OnElevatorAttack += OnTakeDamage;

        stage = StageManager.instance.currentStage;
        InvokeRepeating("MakeMonsters", 0, stage.generateMonsterRate);
        //StageManager.instance.StartRegenPlayerUnitCost();
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        if (timeLimit <= 0) StageManager.instance.StageOver();
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
