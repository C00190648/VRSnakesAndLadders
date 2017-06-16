using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateQuestions : MonoBehaviour {

    List<string[]> questionBank = new List<string[]>();

    // Use this for initialization
    void Start () {
        Debug.Log("It's time to create some motherfucking questions, bitch.");

        string[] q1 = new string[5];
        //Question
        q1[0] = "According to the pre-crash Report what age group had the highest number of passenger deaths in collisions where alcohol was a factor?";
        //Correct answer; will be placed randomly on the board.
        q1[1] = "17-24 years";
        //Incorrect answers; will be placed randomly on the board.
        q1[2] = "50-65 years";
        q1[3] = "25-34 years";
        q1[4] = "10-16 years";
        //Submit this question to the bank to be randomly pulled.
        questionBank.Add(q1);

        string[] q2 = new string[5];
        //Question
        q2[0] = "What is the maximum disqualification period imposed in court where the learner driver has a blood alcohol concentration (BAC) level in excess of 80 mg?";
        //Correct answer; will be placed randomly on the board.
        q2[1] = "Six years";
        //Incorrect answers; will be placed randomly on the board.
        q2[2] = "Two years";
        q2[3] = "Four years";
        q2[4] = "One year";
        //Submit this question to the bank to be randomly pulled.
        questionBank.Add(q2);

        string[] q3 = new string[5];
        //Question
        q3[0] = "Which of the following affects the braking distance of a vehicle?";
        //Correct answer; will be placed randomly on the board.
        q3[1] = "Vehicle's speed and weight";
        //Incorrect answers; will be placed randomly on the board.
        q3[2] = "Vehicle's power";
        q3[3] = "Road conditions and vehicle's tyres";
        q3[4] = "Number of passengers carried";
        //Submit this question to the bank to be randomly pulled.
        questionBank.Add(q3);

        string[] q4 = new string[5];
        //Question
        q4[0] = "What should the driver be able to see in the exterior mirrors of a vehicle when they have been properly adjusted?";
        //Correct answer; will be placed randomly on the board.
        q4[1] = "Vehicle's sides, and roads to the side";
        //Incorrect answers; will be placed randomly on the board.
        q4[2] = "Vehicle's sides only";
        q4[3] = "Should not show vehicle's sides";
        q4[4] = "Be angled 60% to the car and 40% to the road";
        //Submit this question to the bank to be randomly pulled.
        questionBank.Add(q4);

        string[] q5 = new string[5];
        //Question
        q5[0] = "What should you do when approaching traffic lights that change from green to amber?";
        //Correct answer; will be placed randomly on the board.
        q5[1] = "Stop, unless it is not safe";
        //Incorrect answers; will be placed randomly on the board.
        q5[2] = "Proceed cautiously; prepare to stop on red";
        q5[3] = "Proceed; green light is about to come on";
        q5[4] = "Accelerate and complete the turn";
        //Submit this question to the bank to be randomly pulled.
        questionBank.Add(q5);

        Debug.Log("All right, asshole, some questions were made, what the fuck now?");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<string[]> getQuestions()
    {
        return questionBank;
    }
}
