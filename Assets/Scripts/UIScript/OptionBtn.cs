using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
   public void OnClickOptionExitBtn()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
