using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float StartTime = 0f;
    [SerializeField] float CurrentTime = 10f;
    [SerializeField] TextMeshProUGUI countdownText;
    public Timer_test JeSuisDansUnAutreScript_Test;
    bool stopTime = false;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = CurrentTime;
    }

    // Update is called once per frame
    void Update()
    {
        FreezTime();
        timer();

    }
    void timer()
    {
        if (!stopTime)
        {
            CurrentTime -= 1 * Time.deltaTime;
            countdownText.text = CurrentTime.ToString("0");

            if (CurrentTime <= 0)
            {
                CurrentTime = 0;
                JeSuisDansUnAutreScript_Test.JeSuisDansUnAutreScript();
                EndGame();
            }

        }

       
    }
    public void FreezTime()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("je freez");
            stopTime = true;


        }
        if (Input.GetKeyDown(KeyCode.E)&&stopTime == true)
        {
            stopTime = false;


        }

    }
    void EndGame()
    {

        Debug.Log("fin de la partie");

    }
}
