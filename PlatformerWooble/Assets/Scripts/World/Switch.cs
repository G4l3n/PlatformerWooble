using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject NightObject;
    public GameObject DayObject;

    public bool Night = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && Night == false)
        {
            Debug.Log("aa");
            NightObject.SetActive(true);
            DayObject.SetActive(false);

            Night = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Night == true)
        {
            DayObject.SetActive(true);
            NightObject.SetActive(false);

            Night = false;
        }

    }
}
