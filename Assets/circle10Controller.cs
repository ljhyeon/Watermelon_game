using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle10Controller : MonoBehaviour
{
    ScoreDirector scoreDirector;

    CircleGenerator circleGenerator;

    Rigidbody2D myRigid;
    bool execute;
    public GameObject[] circle10;
    public GameObject circle11;
    bool delete = false;

    float r = 0.975f;

    // Start is called before the first frame update
    void Start()
    {
        scoreDirector = GameObject.Find("ScoreDirector").GetComponent<ScoreDirector>();
        circleGenerator = GameObject.Find("CircleGenerator").GetComponent<CircleGenerator>();

        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle10 = GameObject.FindGameObjectsWithTag("circle10");
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                execute = true;

                gameObject.tag = "circle10";
            }

        }


        // 충돌 감지
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle10.Length; i++)
        {
            p2.Add(this.circle10[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle10[i]);
                circle11.transform.position = p1;
                Instantiate(circle11);

                scoreDirector.total_score += 512;

                delete = true;
                break;
            }
        }
        
        if(delete)
        {
            // 재생성
            this.circle10 = GameObject.FindGameObjectsWithTag("circle10");
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        circleGenerator.check = 0;
    }
}
