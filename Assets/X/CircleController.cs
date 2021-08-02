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
            }

        }        
    }
}
