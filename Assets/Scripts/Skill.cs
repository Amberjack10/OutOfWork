using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //TODO: if Camera is not main Camera change
    public Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCameraToLocal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetCameraToLocal()
    {
        Vector3 localCameraPos = transform.InverseTransformPoint(mainCamera.transform.position);
        transform.localPosition = localCameraPos - new Vector3(10, 0, -10);
    }
}
