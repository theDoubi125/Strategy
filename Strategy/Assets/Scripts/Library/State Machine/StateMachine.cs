using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State : UnityEngine.Object
{
    private StateMachine m_stateMachine;
    protected Transform transform { get { return m_stateMachine.transform; } }

    public void SetStateMachine(StateMachine machine)
    {
        m_stateMachine = machine;
        Debug.Log("SetStateMachine");
    }

    protected void PushState(State state)
    {
        m_stateMachine.PushState(state);
    }

    protected void PopState()
    {
        m_stateMachine.PopState();
    }

    protected void SwitchState(State state)
    {
        m_stateMachine.SwitchState(state);
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void Update()
    {

    }
}

public class StateMachine : MonoBehaviour
{
    private State m_initState;

    private Stack<State> m_states = new Stack<State>();

    public State CurrentState
    {
        get
        {
            if(m_states.Count > 0)
                return m_states.Peek();
            return null;
        }
    }

	void Start ()
    {
        m_initState = new MoveState(Vector3.right * 10, 1);
        PushState(m_initState);
	}
	
	void Update ()
    {
        CurrentState.Update();
	}

    public void PushState(State state)
    {
        if(m_states.Count > 0)
            CurrentState.OnExit();
        m_states.Push(state);
        state.SetStateMachine(this);
        CurrentState.OnEnter();
    }

    public void PopState()
    {
        m_states.Pop().OnExit();
        if (m_states.Count <= 0)
            throw new UnityException("State machine stack empty");
        CurrentState.OnEnter();
    }

    public void SwitchState(State state)
    {
        m_states.Pop().OnExit();
        m_states.Push(state);
        state.SetStateMachine(this);
        CurrentState.OnEnter();
    }
}