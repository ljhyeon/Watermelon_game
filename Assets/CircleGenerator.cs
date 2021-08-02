using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public GameObject[] circlePrefab;

    void Start()
    {
        GameObject circle = Instantiate(circlePrefab[0]) as GameObject;
        circle.transform.position = new Vector3(-0.01f, 4.53f, 0);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("CreateCircle", 2f);
        }
    }

    void CreateCircle()
    {
        int i = Random.Range(0, circlePrefab.Length);
        GameObject circle = Instantiate(circlePrefab[i]) as GameObject;
        circle.transform.position = new Vector3(-0.01f, 4.53f, 0);
    }
}
