using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private new Camera camera;
    private Animator animator;

    private int direction; // 방향을 나타내는 변수
    private bool isWalk; // 플레이어가 움직이는지 여부

    public Sprite upSprite;  // 애니메이션 파라미터 0
    public Sprite downSprite;// 애니메이션 파라미터 1
    public Sprite leftSprite;// 애니메이션 파라미터 2
    public Sprite rightSprite;// 애니메이션 파라미터 3

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        camera = Camera.main; // mainCamera 태그에 붙어있는 카메라를 가져온다.
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 움직임이 없을 때
    private void FixedUpdate()
    {
        if (!isWalk)
        {
            animator.SetBool("IsWalk", false);
        }
    }


    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        if (moveInput != Vector2.zero)
        {
            isWalk = true;
            direction = GetDirection(moveInput);
            UpdateAnimation();
        }
        else
        {
            isWalk = false;
            animator.SetBool("IsWalk", false); // 가만히 있는 상태
        }

        // 움직임 이벤트 호출
        CallMoveEvent(moveInput);
    }

    private int GetDirection(Vector2 moveInput)
    {
        if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
        {
            if (moveInput.y > 0) return 0;
            else return 1;
        }
        else
        {
            if (moveInput.x < 0) return 2;
            else return 3;
        }
    }


    // 애니메이션 업데이트
    private void UpdateAnimation()
    {
        animator.SetInteger("Direction", direction);
        animator.SetBool("IsWalk", isWalk);

        // 방향에 따라 스프라이트 설정.. 근데 잘 안됨
        switch (direction)
        {
            case 0: 
                spriteRenderer.sprite = upSprite;
                break;
            case 1: 
                spriteRenderer.sprite = downSprite;
                break;
            case 2: 
                spriteRenderer.sprite = leftSprite;
                break;
            case 3: 
                spriteRenderer.sprite = rightSprite;
                break;
        }
    }


    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos -  (Vector2)transform.position).normalized;
        CallLookEvent(newAim);
    }
}
