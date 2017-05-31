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

	// Use this for initialization
	void Start () {
        progressText.text = "When finished, submit chosen answers here.";
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
    }
}
