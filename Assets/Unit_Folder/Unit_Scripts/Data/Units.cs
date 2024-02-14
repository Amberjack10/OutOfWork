using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerUnit", fileName = "Unit_")]
public class Units : ScriptableObject
{
    public GameObject unitPrefab;
    public string unitName;
    public int price;
    public float coolTime;
}
