using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class predeadline : MonoBehaviour
{
    public GameObject deadline;

    int time = 0;
    int count;

    void Start()
    {
        deadline.SetActive(false);
        this.time = 0;
        this.count = 0;
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
            if(count == 0) deadline.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.count += 1;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        this.time = this.time + 1;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.count -= 1;
        this.time = 0;
    }

}
