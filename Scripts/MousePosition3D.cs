using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject whatever;

    private void FixedUpdate() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            transform.position = raycastHit.point;
        }           
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(whatever, transform.position, Quaternion.identity);
        }
    }
}
