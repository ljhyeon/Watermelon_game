using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle02Controller : MonoBehaviour
{
    Rigidbody2D myRigid;
    bool execute;
    public GameObject[] circle02;
    public GameObject circle03;
    bool delete = false;

    float r = 0.24375f;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle02 = GameObject.FindGameObjectsWithTag("circle02");
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                execute = true;
                gameObject.tag = "circle02";
            }
        }


        // 충돌 감지
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle02.Length; i++)
        {
            p2.Add(this.circle02[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle02[i]);
                circle03.transform.position = p1;
                Instantiate(circle03);

                delete = true;
                break;
            }
        }

        if (delete)
        {
            // 재생성
            this.circle02 = GameObject.FindGameObjectsWithTag("circle02");
        }

    }
}
