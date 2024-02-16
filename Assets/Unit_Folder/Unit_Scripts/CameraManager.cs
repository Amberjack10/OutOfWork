using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    Vector2 clickPoint;
    float dragSpeed = 30f;

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

        mapSize = mapScale.GetComponent<TilemapCollider2D>().bounds.size;
        center = mapScale.GetComponent<TilemapCollider2D>().bounds.center;
    }

    private void Start()
    {
        StartCoroutine("StartCamera");

        cameraHeight = cam.orthographicSize;
        cameraWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1)) clickPoint = Input.mousePosition;
        if (Input.GetMouseButton(1) && canMoveCamera)
        {
            
            float lx = (mapSize.x / 2) - cameraWidth;
            float ly = (mapSize.y / 2) - cameraHeight;

            Vector3 position = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);
            Vector3 move = position * (Time.deltaTime * dragSpeed);

            cam.transform.Translate(move);
            cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, -lx + center.x, lx + center.x), Mathf.Clamp(cam.transform.position.y, -ly + center.y, ly + center.y), cam.transform.position.z);
        }
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
