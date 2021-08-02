using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle03Controller : MonoBehaviour
{
    Rigidbody2D myRigid;
    bool execute;
    public GameObject[] circle03;
    public GameObject circle04;
    bool delete = false;

    float r = 0.325f;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle03 = GameObject.FindGameObjectsWithTag("circle03");
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                execute = true;
                gameObject.tag = "circle03";
            }

        }

        // 충돌 감지
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle03.Length; i++)
        {
            p2.Add(this.circle03[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle03[i]);
                circle04.transform.position = p1;
                Instantiate(circle04);

                delete = true;
                break;
            }
        }

        if (delete)
        {
            // 재생성
            this.circle03 = GameObject.FindGameObjectsWithTag("circle03");
        }

    }
}
