using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseOrbit(bool pause) {
        GameObject[] orbitals= GameObject.FindGameObjectsWithTag("Orbitable");
        foreach (GameObject orbital in orbitals) {
            if (orbital.GetComponent<OrbitScript>() != null) {
                orbital.GetComponent<OrbitScript>().enabled = !pause;
            }
        }
    }
}
