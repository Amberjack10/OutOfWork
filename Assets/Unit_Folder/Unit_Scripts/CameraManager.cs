using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public Camera cam;
    public GameObject mapScale;

    private Vector2 mapSize;
    private Vector2 center;

    private float cameraWidth;
    private float cameraHeight;

    private Vector3 cameraStartPosition;
    private Vector3 cameraSetPosition;

    [SerializeField]private bool canMoveCamera = false;

    private void Awake()
    {
        instance = this;
        cameraStartPosition = new Vector3(15, 0, cam.transform.position.z);
        cameraSetPosition = new Vector3(-20, 0, cam.transform.position.z);

        mapSize = mapScale.transform.localScale;
        center = mapScale.GetComponent<TilemapCollider2D>().bounds.center;
    }

    private void Start()
    {
        StartCoroutine("StartCamera");
    }

    void LimitCameraArea()
    {
        float lx = mapSize.x - cameraWidth;
        float clampX = Mathf.Clamp(cam.transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - cameraHeight;
        float clampY = Mathf.Clamp(cam.transform.position.y, -ly + center.y, ly + center.y);

        cam.transform.position = new Vector3(clampX, clampY, cam.transform.position.z);
    }

    IEnumerator StartCamera()
    {
        cam.transform.position = cameraStartPosition;
        yield return new WaitForSeconds(1f);

        while (!canMoveCamera)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, cameraSetPosition, Time.deltaTime * 1.5f);
            yield return null;

            float offset = 1f;
            if (cam.transform.position.x - offset <= cameraSetPosition.x)
            {
                canMoveCamera = true;
            }
        }

    }
}
