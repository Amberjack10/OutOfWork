using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    Vector2 clickPoint;
    float dragSpeed = 30f;

    // Min, Max values about Camera position.x
    float limitMinX = -28f, limitMaxX = 24f;
    // Camera Half Width Size
    float cameraHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Input.GetMouseButtonDown(1) : On Right Mouse Button Click
        if (Input.GetMouseButtonDown(1)) clickPoint = Input.mousePosition;
        // Input.GetMouseButton(1) : While Pressing Right Mouse Button
        if (Input.GetMouseButton(1))
        {
            Vector3 position = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);
            Vector3 move = position * (Time.deltaTime * dragSpeed);

            float y = transform.position.y;

            transform.Translate(move);
            transform.transform.position = new Vector3(Mathf.Clamp(transform.position.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth), y, transform.position.z);
        }
    }
}
