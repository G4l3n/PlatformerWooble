using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject NightObject;
    public GameObject DayObject;

    public bool Night = false;

    private void Start()
    {
        Night = false;
    }

    public void Switching()
    {
        if (!Night)
        {
            NightObject.SetActive(true);
            DayObject.SetActive(false);

            Night = !Night;
        }
        else if (Night)
        {
            DayObject.SetActive(true);
            NightObject.SetActive(false);

            Night = !Night;
        }
    }
}
