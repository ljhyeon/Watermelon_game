using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle01Generator : MonoBehaviour
{

    public GameObject circle01Prefab;

    void Start()
    {
        GameObject circle = Instantiate(circle01Prefab) as GameObject;
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
        GameObject circle = Instantiate(circle01Prefab) as GameObject;
        circle.transform.position = new Vector3(-0.01f, 4.53f, 0);
    }
}
