using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle02Genertor : MonoBehaviour
{
    public GameObject circle02Prefab;

    void Start()
    {
        GameObject circle = Instantiate(circle02Prefab) as GameObject;
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
        GameObject circle = Instantiate(circle02Prefab) as GameObject;
        circle.transform.position = new Vector3(-0.01f, 4.53f, 0);
    }
}
