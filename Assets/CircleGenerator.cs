using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public GameObject[] circlePrefab;

    public int check;

    void Start()
    {
        GameObject circle = Instantiate(circlePrefab[0]) as GameObject;
        circle.transform.position = new Vector3(-0.01f, 4.53f, 0);

        this.check = 0;

    }


    void Update()
    {
        if(this.check == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.check = 1;
                Invoke("CreateCircle", 2f);
            }
        }
        print(check);
    }

    void CreateCircle()
    {
        int i = Random.Range(0, circlePrefab.Length);
        GameObject circle = Instantiate(circlePrefab[i]) as GameObject;
        circle.transform.position = new Vector3(-0.01f, 4.53f, 0);
    }
}
