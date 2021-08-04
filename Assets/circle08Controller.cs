using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle08Controller : MonoBehaviour
{
    ScoreDirector scoreDirector;

    Rigidbody2D myRigid;
    bool execute = false;
    public GameObject[] circle08;
    public GameObject circle09;
    bool delete = false;

    float r = 0.76375f;

    // Start is called before the first frame update
    void Start()
    {
        scoreDirector = GameObject.Find("ScoreDirector").GetComponent<ScoreDirector>();

        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle08 = GameObject.FindGameObjectsWithTag("circle08");
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                execute = true;
                gameObject.tag = "circle08";
            }
        }

        // 충돌 감지
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle08.Length; i++)
        {
            p2.Add(this.circle08[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle08[i]);
                circle09.transform.position = p1;
                Instantiate(circle09);

                scoreDirector.total_score += 128;

                delete = true;
                break;
            }
        }

        if (delete)
        {
            // 재생성
            this.circle08 = GameObject.FindGameObjectsWithTag("circle08");
        }

    }

}
