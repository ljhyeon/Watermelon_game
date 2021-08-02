using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    Rigidbody2D myRigid;
    bool execute;

    void Start()
    {
        this.myRigid = GetComponent<Rigidbody2D>();
        this.execute = false;
    }

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
            }

        }        
    }
}
