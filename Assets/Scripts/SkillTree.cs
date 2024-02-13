using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public enum SkillType
    {
        DecreaseCool,
        increaseAtk,
        increaseAtkSphere
    }

    public SkillType type;    
    public bool isUnlocked = false;
    [SerializeField] private int amount;
    [SerializeField] private int price;
    [SerializeField] private SkillTree prevTree;

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

    private void UnLock()
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

        //SkillPoint »©±â
        isUnlocked = true;
    }
}
