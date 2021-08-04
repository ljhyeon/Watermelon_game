using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle04Controller : MonoBehaviour
{
    ScoreDirector scoreDirector;

    Rigidbody2D myRigid;
    bool execute;
    public GameObject[] circle04;
    public GameObject circle05;
    bool delete = false;

    float r = 0.40625f;

    // Start is called before the first frame update
    void Start()
    {
        scoreDirector = GameObject.Find("ScoreDirector").GetComponent<ScoreDirector>();

        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle04 = GameObject.FindGameObjectsWithTag("circle04");
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                execute = true;

                gameObject.tag = "circle04";
            }

        }


        // 충돌 감지
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle04.Length; i++)
        {
            p2.Add(this.circle04[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle04[i]);
                circle05.transform.position = p1;
                Instantiate(circle05);

                scoreDirector.total_score += 8;

                delete = true;
                break;
            }
        }

        if (delete)
        {
            // 재생성
            this.circle04 = GameObject.FindGameObjectsWithTag("circle04");
        }

    }

}
