using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    public new Camera camera;
    public Transform spawner;
    public GameObject bulletPrefab;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void Update() {
        RotateTowardsMouse();
        CheckFiring();
    }

    private void RotateTowardsMouse() {
        float angle = GetAngleTowardsMouse();

        transform.rotation = Quaternion.Euler(0, 0, angle);
        spriteRenderer.flipY = angle >= 90 && angle <= 270;
    }

    private float GetAngleTowardsMouse() {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;

        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angle;
    }

    private void CheckFiring() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            Destroy(bullet, 2f);
        }
    }
}
