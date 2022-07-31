using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateText : MonoBehaviour
{
    // Start is called before the first frame update

    public string title;
    public string race;
    public TMP_Text body;

    TMP_Text titleText;
    TMP_Text raceText;
    TMP_Text bodyText;
    GameObject activate;
    void Awake()
    {
        titleText = GameObject.FindGameObjectWithTag("Title").GetComponent<TMP_Text>();
        bodyText = GameObject.FindGameObjectWithTag("Body").GetComponent<TMP_Text>();
        raceText = GameObject.FindGameObjectWithTag("Race").GetComponent<TMP_Text>();
        activate = GameObject.FindGameObjectWithTag("Info");
    }

    void Start() {
        activate.SetActive(false);
    }

    // Update is called once per frame
    void OnMouseDown() {
        activate.SetActive(true);
        titleText.text = title;
        raceText.text = race;
        bodyText.text = body.text;


    }
}
