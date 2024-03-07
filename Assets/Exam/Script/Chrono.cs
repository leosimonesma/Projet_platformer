using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chrono : MonoBehaviour
{
    [SerializeField] float StartTime = 0f;
    [SerializeField] float CurrentTime = 10f;
    [SerializeField] TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = CurrentTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer();

    }
    void timer()
    {
        CurrentTime += 1 * Time.deltaTime;
        countdownText.text = CurrentTime.ToString("0");

      
    }
}

