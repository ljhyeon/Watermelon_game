using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_down04Controller : MonoBehaviour
{
    Rigidbody2D myRigid;
    bool execute;
    public GameObject circle;
    public GameObject[] circle04;
    public GameObject circle05;
    bool delete = false;

    float r = 0.40625f;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
        this.circle04 = GameObject.FindGameObjectsWithTag("circle04");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p1 = transform.position;
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
                Destroy(gameObject);
                circle.transform.position = p1;
                Instantiate(circle);
                execute = true;
            }

        }


        // �浹 ����

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
                
                delete = true;
                break;
            }
        }
        
        if(delete)
        {
            // �����
            this.circle04 = GameObject.FindGameObjectsWithTag("circle04");
        }
        
    }
}
