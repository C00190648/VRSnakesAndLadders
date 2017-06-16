using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SubmitAnswers : MonoBehaviour {
    const int ANSWERS_PER_QUESTION = 3;

    //List containing the bank of questions to be drawn from.
    private List<string[]> questions = new List<string[]>();
    //List containing the boards on which the questions and answers will be printed.
    public List<GameObject> questionBoards = new List<GameObject>();
    //List containing all of the button objects for the correct answers.
    private List<GameObject> correctAnswers = new List<GameObject>();
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

        questions = this.GetComponent<CreateQuestions>().getQuestions();
        


        int q; //Randomly generated number that picks the question.
        List<int> qArr = new List<int>(); //List of questions that have been used so far.
        int a; //Randomly generated number that picks the answer placement.
        List<int> aArr = new List<int>(); //List of answers that have been used so far.
        Transform current; //The object we're currently working with and writing on.

        for (int i = 0; i < questionBoards.Count; i++)
        {
            q = Random.Range(0, questions.Count);
            while (qArr.Contains(q))
            {
                q = Random.Range(0, questions.Count);
            }
            qArr.Add(q);

            current = questionBoards[i].transform.Find("Panel/QCanvas/Question");
            current.GetComponent<Text>().text = questions[q][0];

            

            for (int l = 0; l < ANSWERS_PER_QUESTION; l++)
            {
                switch (l)
                {
                    case 0:
                        current = questionBoards[i].transform.Find("Panel/ACanvas/Button1");
                        break;
                    case 1:
                        current = questionBoards[i].transform.Find("Panel/ACanvas/Button2");
                        break;
                    case 2:
                        current = questionBoards[i].transform.Find("Panel/ACanvas/Button3");
                        break;
                    //case 3:
                        //current = questionBoards[i].transform.Find("Panel/ACanvas/Button4");
                        //In case we decide to add a fourth answer panel to each question board.
                        //I bring this up because most of the questions on the driving test site
                        //do have four options to choose from.
                }

                a = Random.Range(1, (ANSWERS_PER_QUESTION + 1));
                //If I uncomment this, the app won't start, it'll freeze on what I can only guess is an infinite loop.
                //No idea what's actually wrong with it. Can't Debug.Log anything, since that doesn't start up...
                while (aArr.Contains(a))
                {
                    a = Random.Range(1, (ANSWERS_PER_QUESTION + 1));
                }
                aArr.Add(a);

                current.transform.Find("A"+(l+1)+"Text").GetComponent<Text>().text = questions[q][a];
                if (a == 1)
                {//If the correct answer is the one being placed, mark it as such.
                    correctAnswers.Add(current.gameObject);
                }
                //Also, figure out how to mark which answer is the correct one when placed.
            }


            aArr.Clear();

            Debug.Log(correctAnswers[i]);
        }
        

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
