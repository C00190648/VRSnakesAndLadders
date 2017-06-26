using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public bool trigger = false;

    public bool correct;

    public GameObject scorekeeper;

    private double time = 0;
    //Stores whether or not this particular answer was the one chosen.
    public bool selected;
    public void Answer()
    {//Checks the given answer against the correct one.
        selected = true;
        /*if (correct)
        {//If the user picked this answer, register it as such.
            GetComponent<Image>().color = Color.green;
        }
        else
        {//Otherwise, make sure it's not registered as selected.
            GetComponent<Image>().color = Color.red;
        }*/
        scorekeeper.GetComponent<SubmitAnswers>().Increment(correct);
    }






    private void FixedUpdate()
    {
        //if (time > 0.01) 
       //Debug.Log("state " + trigger);


        if (GetComponent<Button>().interactable)
        {
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

            if (time > 1 && time < 1.1)
            {
                Debug.Log("trig state = " + trigger);
            }
            if (time > 2 && !selected)
            {
                //Answer();
                Select();
                //  CheckAnswers();
            }

            //Select();
        }
    }

    public void GazeEnter()
    {
        if (GetComponent<Button>().interactable)
        {
            trigger = true;
        }
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
        Debug.Log("Selecting.");
        if (correct)
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (!correct)
        {
            GetComponent<Image>().color = Color.red;
        }
        scorekeeper.GetComponent<SubmitAnswers>().Increment(correct);

        DisableButtons();
    }

    private void DisableButtons()
    {//Make all three buttons on the same board uninteractable to prevent the player from changing their answer.
        this.transform.parent.transform.Find("Button1").GetComponent<Button>().interactable = false;
        this.transform.parent.transform.Find("Button2").GetComponent<Button>().interactable = false;
        this.transform.parent.transform.Find("Button3").GetComponent<Button>().interactable = false;
    }

    public bool isSelected()
    {
        return selected;
    }
}
