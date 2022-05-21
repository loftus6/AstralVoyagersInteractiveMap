using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{

    public GameObject orbit;
    
    public float speed = 5f;

    public float theta_scale = 0.01f; //lower for more points
    // Start is called before the first frame update

    public bool drawLines = true;
    private LineRenderer lineRenderer;
    private int size;
    private float radius;
    void Start()
    {
        if (drawLines) {
        float sizeValue = (2.0f * Mathf.PI) / theta_scale; 
        size = (int)sizeValue;
        size++;
        lineRenderer = orbit.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = .02f;
        lineRenderer.useWorldSpace = false;
        lineRenderer.endWidth = .02f;//thickness of line 
        lineRenderer.positionCount = size;  
        Debug.Log(sizeValue + " " + size + " " + lineRenderer.positionCount);
        transform.RotateAround(orbit.transform.position, Vector3.up, speed);
        radius = Vector3.Distance(transform.position, orbit.transform.position);
        Vector3 pos;
        float theta = 0f;
        for(int i = 0; i < size; i++){        
            lineRenderer.positionCount = size;    
            theta += (2.0f * Mathf.PI * theta_scale);         
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);          
            x += orbit.transform.position.x;
            y += orbit.transform.position.y;
            pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(orbit.transform.position, Vector3.up, Time.deltaTime * speed);
    }
}
