using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle01Controller : MonoBehaviour
{
    Rigidbody2D myRigid;
    bool execute;
    public GameObject[] circle01;
    public GameObject circle02;
    bool delete = false;

    float r = 0.1625f;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle01 = GameObject.FindGameObjectsWithTag("circle01");
    }

    // Update is called once per frame
    void Update()
    {
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
                myRigid.isKinematic = false;
                execute = true;

               Invoke("ChangeTag", 2f);
            }

        }


        // 충돌 감지
        Vector2 p1 = transform.position;

        List<Vector2> p2 = new List<Vector2>();
        List<Vector2> dir = new List<Vector2>();
        List<float> d = new List<float>();

        for (int i = 0; i < circle01.Length; i++)
        {
            p2.Add(this.circle01[i].transform.position);
            dir.Add(p1 - p2[i]);

            d.Add(dir[i].magnitude);
            if (d[i] < 2 * r)
            {
                Destroy(gameObject);
                Destroy(circle01[i]);
                circle02.transform.position = p1;
                Instantiate(circle02);
                
                delete = true;
                break;
            }
        }
        
        if(delete)
        {
            // 재생성
            this.circle01 = GameObject.FindGameObjectsWithTag("circle01");
        }
        
    }

    void ChangeTag()
    {
       gameObject.tag = "circle01";
    }
}
