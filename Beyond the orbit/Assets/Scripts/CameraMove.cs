using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Transform: ��ġ, ȸ��, ũ�⸦ �����ϴ� ������Ʈ
    // transform: ������Ʈ�� �Ҵ�� Transform ������Ʈ, GetComponent<Transform>()�� ����. ���� ��� �ִ� ��ü�̴�.
    Transform playerTransform;
    Vector3 Offset;

    void Awake()
    {
        // FindGameObjectWithTag(): �־��� �±׷� ������Ʈ �˻�
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Player�� ��ġ, ȸ��, ũ�� ������Ʈ
        Offset = transform.position - playerTransform.position; // ���� ī�޶�� �÷��̾� ��ġ ���� ����
    }

    // Update �ڿ� �����, UI/ī�޶� �̵��� ���� ���� �̷����
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}