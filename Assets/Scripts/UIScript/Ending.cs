using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private float moveSpeed;
    [SerializeField] private TextMeshProUGUI[] titleText;
    [SerializeField] private TextMeshProUGUI bodyText;

    private float titleTextTime;
    private float bodyTextTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        if(Camera.main.transform.position.y >= 55)
        {
            moveSpeed = 0f;
            FadeInTitle();
            Invoke("FadeInText", 4.5f);
        }
       
    }

    private void FadeInTitle()
    {
        if(titleTextTime < 3f)
        {
            titleText[0].color = new Color(1, 1, 1, titleTextTime / 3);
            titleText[1].color = new Color(1, 1, 1, titleTextTime / 3);
            titleText[2].color = new Color(1, 1, 1, titleTextTime / 3);
        }
        else
        {
            return;
        }
        titleTextTime += Time.deltaTime;
    }
    
    private void FadeInText()
    {
        if (bodyTextTime < 3f)
        {
            bodyText.color = new Color(1,1,1, bodyTextTime / 3);
        }
        else
        {
            return;
        }

        bodyTextTime += Time.deltaTime;
    }
}
