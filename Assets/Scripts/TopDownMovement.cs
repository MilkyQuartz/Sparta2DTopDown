using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // 실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection;
    private Animator animator;
    private char initial;

    public float walkAnimationThreshold = 0.01f; // 걷는 애니메이션을 전환할 이동량 임계값
    private float currentWalkDistance = 0f; // 현재 이동한 거리


    // Awake는 주로 내 컴포넌트 안에서 끝나는거
    private void Awake()
    {
        // controller랑 TopDownMovement랑 같은 GameObject에 있다라는 가정
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        string selectedCharacterName = PlayerPrefs.GetString("selectCharacter", "");
        initial = selectedCharacterName[0];
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
            animator.SetFloat("LastMoveX", direction.x);
            animator.SetFloat("LastMoveY", 0);
        }
        else if (direction.y != 0)
        {
            animator.SetFloat("LastMoveX", 0);
            animator.SetFloat("LastMoveY", direction.y);
        }

        // 대기 애니메이션
        if (direction.magnitude == 0f)
        {
            SetIdleAnimation(direction);
            return; 
        }

        // 걷는 애니메이션
        if (direction.magnitude > walkAnimationThreshold)
        {
            currentWalkDistance += direction.magnitude;
            if (currentWalkDistance >= walkAnimationThreshold)
            {
                SetWalkAnimation(direction);
                currentWalkDistance = 0f;
            }
        }
        else
        {
            animator.SetBool("Walking", false);
            currentWalkDistance = 0f;
        }
    }

    private void SetWalkAnimation(Vector2 direction)
    {
        string animationName = "";

        float absX = Mathf.Abs(direction.x);
        float absY = Mathf.Abs(direction.y);

        if (absX > absY)
        {
            if (direction.x < 0f)
            {
                animationName += initial + "WalkLeft";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
            else if (direction.x > 0f)
            {
                animationName += initial + "WalkRight";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
        }
        else if (absY > absX)
        {
            if (direction.y > 0f)
            {
                animationName += initial + "WalkUp";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
            else if (direction.y < 0f)
            {
                animationName += initial + "WalkDown";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
        }
        else
        {
            animationName += initial + "Walk" + (direction.y > 0f ? "Up" : "Down");
            Debug.Log("애니메이션 클립 이름: " + animationName);
        }

        animator.Play(animationName, 0, 0f);
    }

    private void SetIdleAnimation(Vector2 lastDirection)
    {
        Debug.Log("애니메이션 벡터: " + "(x,y)" + lastDirection);
        string animationName = "";

        float absX = Mathf.Abs(lastDirection.x);
        float absY = Mathf.Abs(lastDirection.y);

        if (absX > absY)
        {
            if (lastDirection.x < 0f)
            {
                animationName += initial + "IdleLeft";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
            else if (lastDirection.x > 0f)
            {
                animationName += initial + "IdleRight";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
        }
        else if (absY > absX)
        {
            if (lastDirection.y > 0f)
            {
                animationName += initial + "IdleUp";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
            else if (lastDirection.y < 0f)
            {
                animationName += initial + "IdleDown";
                Debug.Log("애니메이션 클립 이름: " + animationName);
            }
        }
        else
        {
            animationName += initial + "Idle" + (lastDirection.y > 0f ? "Up" : "Down");
            Debug.Log("애니메이션 클립 이름: " + animationName);
        }

        animator.Play(animationName, 0, 0f);
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
