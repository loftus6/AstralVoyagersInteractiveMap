using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramrateLock : MonoBehaviour
{

    public int frameLock =30;
    // Start is called before the first frame update
    void Awake() {
        Application.targetFrameRate = frameLock;
    }
}
