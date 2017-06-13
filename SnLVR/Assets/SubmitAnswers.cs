using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SubmitAnswers : MonoBehaviour {
    //List containing all of the button objects for the correct answers.
    public List<GameObject> correctAnswers = new List<GameObject>();
    //Total number of correct answers required to progress to the next level.
    public int minimumCorrect;
    //Text that will change to display current progress.
    public Text progressText;

    //Used when submitting answers. Total number of correct answers.
    private int score;

    public bool trigger = false;

    private double time = 0;
	// Use this for initialization
	void Start () {
        progressText.text = "When finished, submit chosen answers here.";
	}

    public void GazeEnter()
    {
        //Debug.Log("triggered =  " + trigger);
        //if (trigger == true)
        //{
        trigger = true;
       
    }

    private void FixedUpdate()
    {
        if (trigger == true)
        {
            time += Time.fixedDeltaTime;
        }

        if (time > 1)
        {
            if (this.GetComponent<Button>().interactable)
            {
                CheckAnswers();
            }
        }
    }

    public void GazeExit()
    {

        trigger = false;
        time = 0;
    }




    public void CheckAnswers()
    {//When the player presses the Submit button, the game checks to see if the correct answers were selected.
        score = 0;
        for (int i = 0; i < correctAnswers.Count; i++)
        {//For every correct answer, check if it was selected. If not, one of the wrong answers was picked.
            if (correctAnswers[i].GetComponent<Question>().isSelected())
            {//If it was correct, the player gains a point.
                score++;
            }
            correctAnswers[i].GetComponent<Button>().interactable = false;
            correctAnswers[i].GetComponent<Image>().color = Color.green;
        }

        //Next, check to see if the player got enough questions right.
        if (score >= minimumCorrect)
        {
            progressText.text = "Goal met; proceed to next floor.";
            //SceneManager.LoadScene(1);
            LadderClimb.ladder.gameObject.SetActive(true);
        }
        else
        {
            progressText.text = "Goal unmet; return to previous floor.";
            TrapFloor.floor.setMoving(true);
        }
	    
	this.GetComponent<Button>().interactable = false;
    }
}
