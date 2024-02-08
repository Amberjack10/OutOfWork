using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public enum SkillType
    {
        DecreaseCool,
        increaseAtk,
        increaseAtkSphere
    }

    public SkillType type;
    public int amount;
    public bool isUnlocked = false;
    public SkillTree prevTree;

    public void CanOpen()
    {
        if(prevTree.isUnlocked)
        {
            //TODO: need GameManager gold check
            if (!isUnlocked)
                UnLock();
        } else
        {
            Debug.Log("prevTree is locked");
        }
    }

    public void UnLock()
    {
        switch((int)type)
        {
            case 0:
                SkillManager.instance.decreaseCool(amount);
                break;
            case 1:
                SkillManager.instance.increaseAtk(amount);
                break;
            case 2:
                SkillManager.instance.increaseAtkSphere();
                break;
        }

        isUnlocked = true;
    }
}
