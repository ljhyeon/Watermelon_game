using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle07Controller : MonoBehaviour
{
    ScoreDirector scoreDirector;

    CircleGenerator circleGenerator;

    Rigidbody2D myRigid;
    bool execute;
    public GameObject[] circle07;
    public GameObject circle08;
    bool delete = false;


    float r = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        scoreDirector = GameObject.Find("ScoreDirector").GetComponent<ScoreDirector>();
        circleGenerator = GameObject.Find("CircleGenerator").GetComponent<CircleGenerator>();

        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle07 = GameObject.FindGameObjectsWithTag("circle07");
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                execute = true;
                gameObject.tag = "circle07";
            }
        }


        // 충돌 감지
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle07.Length; i++)
        {
            p2.Add(this.circle07[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle07[i]);
                circle08.transform.position = p1;
                Instantiate(circle08);

                scoreDirector.total_score += 64;

                delete = true;
                break;
            }
        }
        
        if(delete)
        {
            // 재생성
            this.circle07 = GameObject.FindGameObjectsWithTag("circle07");
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        circleGenerator.check = 0;
    }
}
