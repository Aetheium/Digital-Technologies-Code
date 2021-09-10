using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject whatever;

    private void FixedUpdate() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);             // yeah i have no idea why this works.
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {                  // but, it finds the mouse location on the camera and spits a line down to any gameObject 
            transform.position = raycastHit.point;                              // and if it hits a collider creates a point.
        }           
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {                                      // if the left mouse button is clicked, it creates a specified object at its location.
            Instantiate(whatever, transform.position, Quaternion.identity);
        }
    }
}
