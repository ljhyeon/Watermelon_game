using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class predeadline : MonoBehaviour
{
    public GameObject deadline;

    int time = 0;

    void Start()
    {
        deadline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.time >= 60)
        {
            deadline.SetActive(true);
        }
        else
        {
            deadline.SetActive(false);
        }
        print(time);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // deadline.SetActive(true);
        this.time = this.time + 1;
    }

  /*  void OnTriggerEnter2D(Collider2D other)
    {
        this.time = this.time + 1;
    }*/

    void OnTriggerExit2D(Collider2D other)
    {
        // deadline.SetActive(false);
        this.time = 0;
    }

}
