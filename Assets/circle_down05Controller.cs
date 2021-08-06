using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_down05Controller : MonoBehaviour
{

    ScoreDirector scoreDirector;

    CircleGenerator circleGenerator;

    Rigidbody2D myRigid;
    bool execute;
    public GameObject circle;
    public GameObject[] circle05;
    public GameObject circle06;
    bool delete = false;

    float r = 0.4875f;

    // Start is called before the first frame update
    void Start()
    {
        scoreDirector = GameObject.Find("ScoreDirector").GetComponent<ScoreDirector>();
        circleGenerator = GameObject.Find("CircleGenerator").GetComponent<CircleGenerator>();

        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle05 = GameObject.FindGameObjectsWithTag("circle05");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p1 = transform.position;

        if (execute == false)
        {
            // 마우스 커서 따라 움직이는 오브젝트
            transform.position += new Vector3(Input.GetAxis("Mouse X"), 0, 0);

            // 현재 플레이어의 월드좌표를 뷰포트 기준 좌표로 변환
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

            // Mathf.clamp01(값) - 입력된 값이 0~1 사이를 벗어나지 못하게 강제로 조절하는 함수
            viewPos.x = Mathf.Clamp01(viewPos.x);

            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            transform.position = worldPos;

            // 마우스 클릭 시, 오브젝트는 중력의 힘을 받음
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
                circle.transform.position = p1;
                Instantiate(circle);
                execute = true;
            }

        }


        // 충돌 감지
        

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

                scoreDirector.total_score += 16;

                delete = true;
                break;
            }
        }
        
        if(delete)
        {
            // 재생성
            this.circle05 = GameObject.FindGameObjectsWithTag("circle05");
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        circleGenerator.check = 0;
    }
}
