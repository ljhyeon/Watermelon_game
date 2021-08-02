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
            // ���콺 Ŀ�� ���� �����̴� ������Ʈ
            transform.position += new Vector3(Input.GetAxis("Mouse X"), 0, 0);

            // ���� �÷��̾��� ������ǥ�� ����Ʈ ���� ��ǥ�� ��ȯ
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

            // Mathf.clamp01(��) - �Էµ� ���� 0~1 ���̸� ����� ���ϰ� ������ �����ϴ� �Լ�
            viewPos.x = Mathf.Clamp01(viewPos.x);

            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            transform.position = worldPos;

            // ���콺 Ŭ�� ��, ������Ʈ�� �߷��� ���� ����
            if (Input.GetMouseButtonDown(0))
            {
                myRigid.isKinematic = false;
                execute = true;

               Invoke("ChangeTag", 2f);
            }

        }


        // �浹 ����
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
            // �����
            this.circle01 = GameObject.FindGameObjectsWithTag("circle01");
        }
        
    }

    void ChangeTag()
    {
       gameObject.tag = "circle01";
    }
}
