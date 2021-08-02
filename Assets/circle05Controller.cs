using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle05Controller : MonoBehaviour
{
    Rigidbody2D myRigid;
    bool execute;
    public GameObject[] circle05;
    public GameObject circle06;
    bool delete = false;

    float r = 0.4875f;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle05 = GameObject.FindGameObjectsWithTag("circle05");
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == false)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                execute = true;
                gameObject.tag = "circle05";
            }

        }


        // �浹 ����
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle05.Length; i++)
        {
            p2.Add(this.circle05[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle05[i]);
                circle06.transform.position = p1;
                Instantiate(circle06);

                delete = true;
                break;
            }
        }

        if (delete)
        {
            // �����
            this.circle05 = GameObject.FindGameObjectsWithTag("circle05");
        }

    }

}