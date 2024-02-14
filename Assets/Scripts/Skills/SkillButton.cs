using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] private Button btn;
    private bool isCool = true;
    
    public void PressButton()
    {
        btn.interactable = false;
        SkillManager.instance.SkillButton();
        StartCoroutine(CoolTime());
    }

    IEnumerator CoolTime()
    {
        float cool = SkillManager.instance.coolTime;
        float maxCool = cool;
        while (cool > 0f)
        {
            cool -= Time.deltaTime;
            img.fillAmount = (cool / maxCool);

            yield return new WaitForFixedUpdate();
        }
        btn.interactable = true;
    }
}
