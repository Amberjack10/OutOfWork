using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDOptionButton : MonoBehaviour
{
    [SerializeField] private GameObject optionPrefab;

    private GameObject canvas;
    private GameObject optionUI;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");

        optionUI = Instantiate(optionPrefab,canvas.transform);
        optionUI.SetActive(false);
    }

    public void OnClickOptionButton()
    {
        Time.timeScale = 0;
        optionUI.SetActive(true);
    }
}
