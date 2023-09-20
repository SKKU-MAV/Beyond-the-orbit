using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // 회전 속도

    private Vector3 lastMousePosition; // 이전 프레임의 마우스 위치

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 버튼을 누른 순간
        {
            lastMousePosition = Input.mousePosition; // 마우스 위치 초기화
        }

        if (Input.GetMouseButton(1)) // 마우스 버튼을 누르는 동안
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition; // 마우스 드래그 변위 계산
            float rotationX = -mouseDelta.y * rotationSpeed; // 상하 회전량
            float rotationY = mouseDelta.x * rotationSpeed; // 좌우 회전량

            // 수평 유지하며 회전
            transform.RotateAround(transform.position, transform.right, rotationX); // 상하 회전
            transform.RotateAround(transform.position, Vector3.up, rotationY); // 좌우 회전

            lastMousePosition = Input.mousePosition; // 마우스 위치 업데이트
        }
    }
}
