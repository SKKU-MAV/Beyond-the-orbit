using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour
	{

		private Animator anim;
		private CharacterController controller;

		[SerializeField] float moveSpeed = 30.0f; // 직진 속도
		[SerializeField] float jumpSpeed = 10.0f; // 점프 속도
		[SerializeField] float gravity = 20.0f; // 중력
		[SerializeField] float moveDistance = 10.0f; // 좌우 이동거리
		[SerializeField] float maxDistance = 45.0f; // 좌우 최대 이동거리
		[SerializeField] bool isMoving = false; // 움직이는지 여부 체크
		[SerializeField] bool die = false; // 플레이어 목숨
		Vector3 moveDirection = Vector3.zero;
		float beforeXPos = 0.0f;

		void Start()
		{
			controller = GetComponent<CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update()
		{
			moveDirection.z = moveSpeed; // 캐릭터 움직임 방향 설정, z축 방향으로 일정한 속도 speed로 무한히 이동

			ConvertAnimation(); // 애니메이션 전환

			if (controller.isGrounded)
			{
				if (Input.GetKeyDown(KeyCode.A) && !isMoving) // move to left
				{
					if (transform.position.x - 10 > -maxDistance) // 지형을 넘어서는 이동 방지
					{
						isMoving = true;
						StartCoroutine(MoveLeft());
					}
				}
				else if (Input.GetKeyDown(KeyCode.D) && !isMoving) // move to right
				{
					if (transform.position.x + 10 < maxDistance) // 지형을 넘어서는 이동 방지
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

			moveDirection.y -= gravity * Time.deltaTime; // 캐릭터에 중력 적용
			controller.Move(moveDirection * Time.deltaTime); // 캐릭터 이동
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
				// 깜짝 놀란 것(서프라이즈 애니메이션)으로 바꿈 (나중에 할 것)
			}
			else // 좌, 우, 전진 (Default) // 삭제
			{
				//anim.SetInteger("AnimationPar", 1);
			}
		}

		// 왼쪽으로 이동하고 멈추는 함수
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

		// 오른쪽으로 이동하고 멈추는 함수
		private IEnumerator MoveRight()
		{
			float elapsedTime = 0f; // 경과 시간 초기화
			Vector3 startPosition = transform.position; // 이동 시작 위치를 현재 위치로 설정
			Vector3 targetPosition = startPosition + Vector3.right * moveDistance; // 이동 목표 위치를 시작 위치에서 오른쪽 방향으로 설정한 거리만큼 이동한 위치로 설정

			// Vector3.Lerp 함수를 사용하여 보간할 때, 0부터 1 사이의 범위에서 움직여야
			// 부드러운 보간이 이루어지므로, elapsedTime이 1보다 작을때로 설정
			// elapsedTime 값이 1이 되면, Vector3.Lerp 함수가 목표 위치에 도달한 것으로 간주
			while (elapsedTime < 1f)
			{
				transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			transform.position = targetPosition; // 최종 위치를 목표 위치로 설정
			isMoving = false;
		}

	}
}