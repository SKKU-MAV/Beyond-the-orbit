using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // ȸ�� �ӵ�

    private Vector3 lastMousePosition; // ���� �������� ���콺 ��ġ

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ���콺 ��ư�� ���� ����
        {
            lastMousePosition = Input.mousePosition; // ���콺 ��ġ �ʱ�ȭ
        }

        if (Input.GetMouseButton(1)) // ���콺 ��ư�� ������ ����
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition; // ���콺 �巡�� ���� ���
            float rotationX = -mouseDelta.y * rotationSpeed; // ���� ȸ����
            float rotationY = mouseDelta.x * rotationSpeed; // �¿� ȸ����

            // ���� �����ϸ� ȸ��
            transform.RotateAround(transform.position, transform.right, rotationX); // ���� ȸ��
            transform.RotateAround(transform.position, Vector3.up, rotationY); // �¿� ȸ��

            lastMousePosition = Input.mousePosition; // ���콺 ��ġ ������Ʈ
        }
    }
}
