using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Type01 : MonoBehaviour
{
    [Header("бс Transform")]
    [SerializeField] private Transform target;

    [Header("бс Options")]
    [SerializeField] private float scrollAmount;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if( transform.position.x <= -scrollAmount )
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
    }
}
