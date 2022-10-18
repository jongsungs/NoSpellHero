using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    protected readonly int _aniHashKeyState = Animator.StringToHash("State");
    public enum State : int
    {
        Idle = 0,
        Walk = 1,
        Attack = 2,
        Hit = 3,
        Die = 4,
        Attack2 = 5,

    }

    Animator _animator;
    public State _state;
    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    bool IsState(State state)
    {
        return _state == state;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            ChangeState(State.Walk);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ChangeState(State.Die);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeState(State.Attack);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeState(State.Attack2);

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeState(State.Idle);
        }
    }





    virtual protected void ChangeState(State state)
    {
        if (IsState(state))
            return;
        _state = state;


    }
    public void iChangeState(State state)
    {
        if (IsState(state))
            return;
        _state = state;
        _animator.SetInteger(_aniHashKeyState, (int)_state);

        switch (_state)
        {
            case State.Idle:
             

                break;
            case State.Walk:
                

                break;
            case State.Attack:
               


                break;
            case State.Hit:

                break;
            case State.Die:
                break;
            case State.Attack2:
               
                break;
        }
    }



}