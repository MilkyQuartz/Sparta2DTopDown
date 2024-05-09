using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; // Action은 무조건 void만 반환, 아니면 Func
    public event Action<Vector2> OnLookEvent;

}
