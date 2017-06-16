using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public bool trigger = false;

    private double time = 0;
    //Stores whether or not this particular answer was the one chosen.
    public bool selected;
    public void Answer(bool given)
    {//Checks the given answer against the correct one.
        if (given)
        {//If the user picked this answer, register it as such.
            GetComponent<Image>().color = Color.red;
            selected = true;
        }
        else
        {//Otherwise, make sure it's not registered as selected.
            GetComponent<Image>().color = Color.white;
            selected = false;
        }
    }






    private void FixedUpdate()
    {
        //if (time > 0.01) 
       //Debug.Log("state " + trigger);

        if (trigger == true)
        {
            time += Time.fixedDeltaTime; 
            //play answer select starting sound here
        }
        else
        {
        //    selected = false;
            time = 0;
        }
        
        if (time >1 && time < 1.1)
        {
            Debug.Log("trig state = " + trigger); 
        }
        if (time > 2)
        {
            Answer(true);
          //  CheckAnswers();
        }

       Select();
    }

    public void GazeEnter()
    {
        trigger = true;

    }


    public void GazeExit()
    {

        Debug.Log("exito");
        trigger = false;
        Debug.Log("exit executed, trigger = " + trigger);
        time = 0;
    }



    public void Select()
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
