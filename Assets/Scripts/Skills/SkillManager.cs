using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public float coolTime = 15.0f;
    public int atk = 3;
    public int atkSphere = 1;

    public int skillPoint = 0;

    public List<bool> treeUnlocked = new List<bool>();

    //Skill Prefab
    public GameObject skillSphere;
    [SerializeField] List<GameObject> skills = new List<GameObject>();


    public static SkillManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StageManager.instance.OnStageClear += UpdateSkillPoint;
    }

    void Update()
    {
        for(int i = 0; i < skills.Count; i++)
        {
            if (skills[i] == null)
            {
                skills.RemoveAt(i);
                continue;
            }
            skills[i].transform.position += new Vector3(10f * Time.deltaTime, 0, 0);
        }
    }

    public void decreaseCool(int _amount)
    {
        coolTime -= _amount;
    }

    public void increaseAtk(int _amount)
    {
        atk += _amount;
    }

    public void increaseAtkSphere()
    {
        atkSphere *= 3;
    }

    public void SkillButton()
    {
        for(int i = 0; i < atkSphere; i++)
        {
            GameObject go = Instantiate(skillSphere);
            go.transform.position += new Vector3(-1.1f * i, 0, 0);
            skills.Add(go);
        }
    }

    public void StartSkill(GameObject _go)
    {
        _go.transform.Translate(Vector3.right * 5f * Time.deltaTime);
    }

    private void UpdateSkillPoint(int _reward)
    {
        skillPoint += _reward;
        Debug.Log(skillPoint);
    }

    public void SaveUnlocked(int _index, bool _isUnlocked)
    {
        treeUnlocked[_index] = _isUnlocked;
    }
}
