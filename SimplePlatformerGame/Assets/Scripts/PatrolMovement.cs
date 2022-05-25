using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PatrolMovement : MonoBehaviour
{
    private Vector2 StartPosition;
    private Vector2 EndPosition;
    
    public Vector2 MoveOffsetPosition;
    public float MovementTime;
    public Ease PatrolMovementEase;

    private void Start() 
    {
        StartPosition = transform.position;
        EndPosition = StartPosition + MoveOffsetPosition;
        StartPatrolMovement();
    }

    private void StartPatrolMovement()
    {
        transform.DOMove(EndPosition, MovementTime).From(StartPosition).SetLoops(-1, LoopType.Yoyo).SetEase(PatrolMovementEase);
    }
}
