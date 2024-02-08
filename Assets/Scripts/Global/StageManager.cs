using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string Name { get; private set; }
    public int Level { get; private set; }

    // TODO : 생성 가능한 몬스터 종류
    // public MonsterType[] stageMonsters;

    // 스테이지 클리어 시 보상. 스킬 강화용 재화
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
