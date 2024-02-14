using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public void OnClickcontinueButton()
    {
        LoadingSceneController.LoadScene("StageScene-KSM");
    }
}
