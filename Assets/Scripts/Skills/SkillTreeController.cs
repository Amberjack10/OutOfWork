using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeController : MonoBehaviour
{
    [SerializeField] List<GameObject> skillTrees;
    [SerializeField] List<Animator> linesAnim;

    public static SkillTreeController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadUnlocked();
        UnlockInteract();
    }


    public void UnlockInteract()
    {
        for(int i = 1; i < skillTrees.Count; i++)
        {
            SkillTree tree = skillTrees[i].GetComponent<SkillTree>();
            SkillTree prevTree = tree.prevTree;
            Button btn = skillTrees[i].GetComponent<Button>();

            //Debug.Log($"{i}¹ø {!btn.interactable}, {prevTree.isUnlocked}, {!tree.isUnlocked}");
            if(prevTree.isUnlocked && !tree.isUnlocked)
            {
                btn.interactable = true;
                linesAnim[i-1].SetBool("isInteractable", true);
            } else
            {
                btn.interactable = false;
                if(tree.isUnlocked)
                {
                    Debug.Log($"{i}¹ø {tree.isUnlocked}");
                    linesAnim[i - 1].SetTrigger("Unlocked");
                }
            }
        }

        SaveUnlocked();
    }

    private void SaveUnlocked()
    {
        for(int i = 0; i < skillTrees.Count; i++)
        {
            SkillTree tree = skillTrees[i].GetComponent<SkillTree>();

            SkillManager.instance.SaveUnlocked(i, tree.isUnlocked);
        }
    }

    private void LoadUnlocked()
    {
        for (int i = 0; i < skillTrees.Count; i++)
        {
            SkillTree tree = skillTrees[i].GetComponent<SkillTree>();

            tree.isUnlocked = SkillManager.instance.treeUnlocked[i];
        }
    }
}
