using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TextMeshProUGUI priceTxt;
    [SerializeField] AudioClip errorSound;

    public SkillTree prevTree;

    public void CanOpen()
    {
        if(prevTree.isUnlocked)
        {
            if (!isUnlocked && IsPointEnough())
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

        SkillManager.instance.skillPoint -= price;
        isUnlocked = true;
        SkillTreeController.instance.UnlockInteract();
    }

    private bool IsPointEnough()
    {
        if (SkillManager.instance.skillPoint >= price) return true;
        
        SoundManager.instance.PlaySFX(errorSound);
        return false;
    }
}
