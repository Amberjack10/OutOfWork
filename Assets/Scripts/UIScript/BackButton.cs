using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void OnClickBackButton()
    {
        //LoadingSceneController.LoadScene("StageScene-KSM");
        LoadingSceneController.LoadScene("SelectStage");
    }
}
