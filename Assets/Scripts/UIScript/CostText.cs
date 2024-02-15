using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] costText;

    private void Start()
    {
        for(int i = 0; i < costText.Length; i++)
        {
            costText[i].text = StageManager.instance.playerUnits[i].price.ToString();
        }
    }
}
