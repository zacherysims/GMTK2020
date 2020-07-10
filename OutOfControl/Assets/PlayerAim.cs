using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform aimTransform;
    public Camera cam;

    private Vector3 mousePosition;
    private Vector3 aimDirection;
    private float angle;

    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        aimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
