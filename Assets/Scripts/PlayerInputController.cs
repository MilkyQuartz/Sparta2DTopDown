using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main; // mainCamera 태그에 붙어있는 카메라를 가져온다.
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        //Vector2 newAim = value.Get<Vector2>();
        //Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        //Vector2 lookDirection = (worldPos - (Vector2)transform.position).normalized;

        //CallLookEvent(lookDirection);
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
    }
}
