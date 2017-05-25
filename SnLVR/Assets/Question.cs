using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    //Stores whether or not this particular answer was the one chosen.
    private bool selected;

    public void Answer(bool given)
    {//Checks the given answer against the correct one.
        if (given)
        {//If the user picked this answer, register it as such.
            GetComponent<Image>().color = Color.yellow;
            selected = true;
         
        }
        else
        {//Otherwise, make sure it's not registered as selected.
            GetComponent<Image>().color = Color.white;
            selected = false;
        }
    }

    public bool isSelected()
    {
        return selected;
    }
}
