using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushSecure : MonoBehaviour
{
    public void secure()
    {
        this.GetComponent<Collider2D>().enabled = false;

    }
    public void back()
    {
        this.GetComponent<Collider2D>().enabled = true;

    }

}
