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

   // public List<GameObject> totalAnswers = new List<GameObject>(); //list of every answer
   // int tracker = 0; //tracks total number of selected or highlighted cells

  //  RaycastHit hit;

   // Renderer rend;

    //Used when submitting answers. Total number of correct answers.
    private int score;

	// Use this for initialization
	void Start () {
        progressText.text = "When finished, submit chosen answers here.";
	}

    //private void Update()
    //{
    //    foreach (var item in totalAnswers)
    //    {


    //        //if (item.GetComponent<Image>().color == Color.white)
    //        //{
    //        //    tracker++;
    //        //}


    //        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
    //        {
    //            rend = hit.collider.GetComponent<Renderer>();
    //            Debug.Log(hit.transform.name);

    //           // hit.transform.position = new Vector3(hit.transform.position.x - 0.001f, hit.transform.position.y, hit.transform.position.z);

    //            if (hit.collider.tag == "ans")
    //            {

    //                tracker++;
    //            }
    //            // rend.material.color = Color.clear;
    //        }
    //        else
    //        {
    //            rend.material.color = Color.white;
    //        }

    //    }


    //    if (tracker < totalAnswers.Count)
    //    {
    //        Debug.Log("something highlighted");
    //    }
    //    tracker = 0;
    //}



    IEnumerator Progress()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);

        yield return new WaitForSeconds(3);

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
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            progressText.text = "Goal met; proceed to next floor.";
            SceneManager.LoadScene(1);
            Progress();
        }
        else
        {
            progressText.text = "Goal unmet; return to previous floor.";
        }
    }
}
