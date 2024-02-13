using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public int coolTime = 15;
    public int atk = 3;
    public int atkSphere = 1;

    //Maybe Skill Prefab
    public GameObject skill;

    public static SkillManager instance;
    private void Awake()
    {
        instance = this;
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
        //Instantiate prefab skill
    }
}
