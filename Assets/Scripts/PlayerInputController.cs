using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera _camera;
    private Animator animator;
    private Vector2 lastMoveDirection;


    private void Awake()
    {
        _camera = Camera.main; // mainCamera 태그에 붙어있는 카메라를 가져온다.
        animator = GetComponent<Animator>();

    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        lastMoveDirection = moveInput;
        CallMoveEvent(moveInput);
        SetIdleAnimation(lastMoveDirection);

    }
    public void OnLook(InputValue value)
    {
        //Vector2 newAim = value.Get<Vector2>();
        //Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        //Vector2 lookDirection = (worldPos - (Vector2)transform.position).normalized;

        //CallLookEvent(lookDirection);
    }

    private void SetIdleAnimation(Vector2 lastDirection)
    {
        if (lastDirection.x <= -1)
        {
            animator.Play("IdleLeft", -1, 0f);
        }
        else if (lastDirection.x >= 1)
        {
            animator.Play("IdleRight", -1, 0f);
        }
        else if (lastDirection.y >= 1)
        {
            animator.Play("IdleUp", -1, 0f);
        }
        else if (lastDirection.y <= -1)
        {
            animator.Play("Idle Down", -1, 0f);
        }
    }


    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
    }
}
