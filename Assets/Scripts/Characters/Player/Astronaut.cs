using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Astronaut : MonoBehaviour
{
    public Rigidbody2D MyRigdbody;

    [Header("Speed Setup")]
    public Vector2 Friction = new Vector2(-1, 0);
    public float Speed;
    public float forceJump = 5;
    public float SpeedRun;
    private float _currentSpeed;

    [Header("Animation Setup")]
    public float JumpScaleY = 1.5f;
    public float JumpScaleX = .7f;
    public float AnimationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string BoolRun = "Run";
    public string BoolJump = "Jump";
    public Animator animator;
    public float PlayerSwipeDuration = .1f;



    private void Update()
    {
        HandleJump();
        HandleMoviment();  
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = SpeedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = Speed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            MyRigdbody.velocity = new Vector2(-_currentSpeed, MyRigdbody.velocity.y);
            if(MyRigdbody.transform.localScale.x != -1)
            {
                MyRigdbody.transform.DOScaleX(-1, PlayerSwipeDuration);

            }
            animator.SetBool(BoolRun, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MyRigdbody.velocity = new Vector2(_currentSpeed, MyRigdbody.velocity.y);
            if (MyRigdbody.transform.localScale.x != -1)
            {
                MyRigdbody.transform.DOScaleX(1, PlayerSwipeDuration);
            }
                animator.SetBool(BoolRun, true);
        }
        else
        {
            animator.SetBool(BoolRun, false);
        }
            


        //Debug.Log(MyRigdbody.velocity);

        if (MyRigdbody.velocity.x > 0)
        {
            MyRigdbody.velocity += Friction;
        }
        else if(MyRigdbody.velocity.x < 0)
        {
            MyRigdbody.velocity -= Friction;
        }      
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            MyRigdbody.velocity = Vector2.up * forceJump;
            MyRigdbody.transform.localScale = Vector2.one;

            DOTween.Kill(MyRigdbody.transform);

            HandleScaleJump();
            animator.SetTrigger(BoolJump);
        }
        
    }

    private void HandleScaleJump()
    {
        MyRigdbody.transform.DOScaleY(JumpScaleY, AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        MyRigdbody.transform.DOScaleX(JumpScaleX, AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }


}
