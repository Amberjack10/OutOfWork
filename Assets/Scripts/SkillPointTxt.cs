using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillPointTxt : MonoBehaviour
{
    private TextMeshProUGUI pointTxt;
    private void Awake()
    {
        pointTxt = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointTxt.text = SkillManager.instance.skillPoint.ToString();
    }
}
