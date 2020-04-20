using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shield;
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        MoveShield();
    }

    private void MoveShield()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shield.transform.position;

        // 方向向量转换为角度值
        float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        Quaternion quaternion = Quaternion.Euler(new Vector3(0, 0, angle + 90.0f));

        shield.transform.rotation = Quaternion.RotateTowards(
            shield.transform.rotation, 
            quaternion, 
            rotateSpeed * Time.fixedDeltaTime
            );
    }
}
