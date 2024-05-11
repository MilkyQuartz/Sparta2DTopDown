using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // 실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection;
    private Animator animator;

    // Awake는 주로 내 컴포넌트 안에서 끝나는거
    private void Awake()
    {
        // controller랑 TopDownMovement랑 같은 GameObject에 있다라는 가정
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        // 입력이 들어오면 해당 축에만 값을 할당하고 다른 축에는 0 할당
        if (direction.x != 0)
        {
            // x 값이 0이 아니면 x 축에만 값을 할당하고 y 축에는 0 할당
            animator.SetFloat("LastMoveX", direction.x);
            animator.SetFloat("LastMoveY", 0);
        }
        else if (direction.y != 0)
        {
            // y 값이 0이 아니면 y 축에만 값을 할당하고 x 축에는 0 할당
            animator.SetFloat("LastMoveX", 0);
            animator.SetFloat("LastMoveY", direction.y);
        }
    }

    private void FixedUpdate()
    {
        // FixedUpdate는 물리 업데이트 관련
        // Rigidbody의 값을 바꾸니깐 FixedUpdate 사용
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        movementRigidbody.velocity = direction; // velocity 공부하기
    }
}