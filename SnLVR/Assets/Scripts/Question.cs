using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    //Stores whether or not this particular answer was the one chosen.
    public bool selected;

    public void Answer(bool given)
    {//Checks the given answer against the correct one.
        if (given)
        {//If the user picked this answer, register it as such.
            GetComponent<Image>().color = Color.green;
            selected = true;
        }
        else
        {//Otherwise, make sure it's not registered as selected.
            GetComponent<Image>().color = Color.white;
            selected = false;
        }
    }

    public void Update()
    {
        if (GetComponent<Button>().interactable)
        {
            if (selected == true)
            {
                GetComponent<Image>().color = Color.red;
            }
            else
            {
                GetComponent<Image>().color = Color.white;
            }
        }
    }

    public bool isSelected()
    {
        return selected;
    }
}
