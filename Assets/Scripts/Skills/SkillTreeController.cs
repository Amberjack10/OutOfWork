using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeController : MonoBehaviour
{
    [SerializeField] List<GameObject> skillTrees;

    public static SkillTreeController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UnlockInteract();
    }


    public void UnlockInteract()
    {
        for(int i = 0; i < skillTrees.Count; i++)
        {
            SkillTree tree = skillTrees[i].GetComponent<SkillTree>();
            SkillTree prevTree = tree.prevTree;
            Button btn = skillTrees[i].GetComponent<Button>();

            if(!btn.interactable && prevTree.isUnlocked && !tree.isUnlocked)
            {
                btn.interactable = true;
            }
        }
    }
}