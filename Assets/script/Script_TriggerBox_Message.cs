using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TriggerBox_Message : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hello world");
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("GoodBye world");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
