using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject rotateTarget;

    public Vector3 center = new Vector3(0, 0, 0);
    public float radius = .1f;
    public float speed = .5f;
    public float sensitivity = 20f;
    public float minFov = 10f;
    public float maxFov = 90f;
    public float orbitDistance = 5f;
    public OrbitPause orbitPause;

    private GameObject defaultTarget;
    private float defaultFov;
    void Start()
    {
        defaultTarget = rotateTarget;
        Camera.main.transform.LookAt(rotateTarget.transform);
        defaultFov = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            if (objectHit.tag == "Orbitable") {
                rotateTarget = objectHit.gameObject;
            }
            orbitPause.PauseOrbit(true);
            // Do something with the object that was hit by the raycast.
        }
        }
        else if (Input.GetMouseButton(0))
        {
            if (rotateTarget != null) {
                Camera.main.transform.RotateAround(rotateTarget.transform.position, Vector3.up,-Input.GetAxis("Mouse X")*speed);
                //Camera.main.transform.RotateAround(rotateTarget.transform.position, Vector3.right,-Input.GetAxis("Mouse Y")*speed);
            }
        }
        if(Input.GetMouseButtonDown(1)){
            rotateTarget = defaultTarget;
            Camera.main.transform.LookAt(rotateTarget.transform);
            orbitPause.PauseOrbit(false);
            Camera.main.fieldOfView = defaultFov;
        }
        if (rotateTarget != null) {
            Camera.main.transform.LookAt(rotateTarget.transform);
            float fov = Camera.main.fieldOfView;
            fov += -Input.GetAxis("Mouse ScrollWheel") * sensitivity; 
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }
    }

}
