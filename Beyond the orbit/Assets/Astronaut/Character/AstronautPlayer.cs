using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour
	{

		private Animator anim;
		private CharacterController controller;

		[SerializeField] float moveSpeed = 30.0f; // ���� �ӵ�
		[SerializeField] float jumpSpeed = 10.0f; // ���� �ӵ�
		[SerializeField] float gravity = 20.0f; // �߷�
		[SerializeField] float moveDistance = 10.0f; // �¿� �̵��Ÿ�
		[SerializeField] float maxDistance = 45.0f; // �¿� �ִ� �̵��Ÿ�
		[SerializeField] bool isMoving = false; // �����̴��� ���� üũ
		[SerializeField] bool die = false; // �÷��̾� ���
		Vector3 moveDirection = Vector3.zero;
		float beforeXPos = 0.0f;

		void Start()
		{
			controller = GetComponent<CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update()
		{
			moveDirection.z = moveSpeed; // ĳ���� ������ ���� ����, z�� �������� ������ �ӵ� speed�� ������ �̵�

			ConvertAnimation(); // �ִϸ��̼� ��ȯ

			if (controller.isGrounded)
			{
				if (Input.GetKeyDown(KeyCode.A) && !isMoving) // move to left
				{
					if (transform.position.x - 10 > -maxDistance) // ������ �Ѿ�� �̵� ����
					{
						isMoving = true;
						StartCoroutine(MoveLeft());
					}
				}
				else if (Input.GetKeyDown(KeyCode.D) && !isMoving) // move to right
				{
					if (transform.position.x + 10 < maxDistance) // ������ �Ѿ�� �̵� ����
					{
						isMoving = true;
						StartCoroutine(MoveRight());
					}
				}
				else if (Input.GetKeyDown(KeyCode.Space)) // jump
				{
					moveDirection.y = jumpSpeed;
				}
				anim.SetBool("Jump", false);
				anim.SetBool("Slide", false);

			}

			moveDirection.y -= gravity * Time.deltaTime; // ĳ���Ϳ� �߷� ����
			controller.Move(moveDirection * Time.deltaTime); // ĳ���� �̵�
		}

		void ConvertAnimation()
		{
			if (Input.GetKey(KeyCode.Space)) // jump
			{
				anim.SetBool("Jump", true);
			}
			else if (Input.GetKey(KeyCode.S)) // slide
			{
				anim.SetBool("Slide", true);
			}
			else if (die)
			{
				// ��¦ ��� ��(���������� �ִϸ��̼�)���� �ٲ� (���߿� �� ��)
			}
			else // ��, ��, ���� (Default) // ����
			{
				//anim.SetInteger("AnimationPar", 1);
			}
		}

		// �������� �̵��ϰ� ���ߴ� �Լ�
		private IEnumerator MoveLeft()
		{
			float elapsedTime = 0f;
			Vector3 startPosition = transform.position;
			Vector3 targetPosition = startPosition + Vector3.left * moveDistance;

			while (elapsedTime < 1f)
			{
				transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			transform.position = targetPosition;
			isMoving = false;
		}

		// ���������� �̵��ϰ� ���ߴ� �Լ�
		private IEnumerator MoveRight()
		{
			float elapsedTime = 0f; // ��� �ð� �ʱ�ȭ
			Vector3 startPosition = transform.position; // �̵� ���� ��ġ�� ���� ��ġ�� ����
			Vector3 targetPosition = startPosition + Vector3.right * moveDistance; // �̵� ��ǥ ��ġ�� ���� ��ġ���� ������ �������� ������ �Ÿ���ŭ �̵��� ��ġ�� ����

			// Vector3.Lerp �Լ��� ����Ͽ� ������ ��, 0���� 1 ������ �������� ��������
			// �ε巯�� ������ �̷�����Ƿ�, elapsedTime�� 1���� �������� ����
			// elapsedTime ���� 1�� �Ǹ�, Vector3.Lerp �Լ��� ��ǥ ��ġ�� ������ ������ ����
			while (elapsedTime < 1f)
			{
				transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			transform.position = targetPosition; // ���� ��ġ�� ��ǥ ��ġ�� ����
			isMoving = false;
		}

	}
}