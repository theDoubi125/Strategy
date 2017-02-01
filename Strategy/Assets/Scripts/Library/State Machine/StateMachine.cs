using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State : ScriptableObject
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

	[SerializeField]
	private State m_currentState = null;

    public State CurrentState
    {
        get
        {
            return m_currentState;
        }
    }

	void Start ()
    {
        m_initState = ScriptableObject.CreateInstance(typeof(MoveState)) as MoveState;
        (m_initState as MoveState).Init(Vector3.right * 10, 1);
        PushState(m_initState);
	}
	
	void Update ()
    {
        CurrentState.Update();
	}

    public void PushState(State state)
    {
        if(m_currentState != null)
            m_currentState.OnExit();
        m_states.Push(state);
        m_currentState = state; 
        state.SetStateMachine(this);
        m_currentState.OnEnter();
    }

    public void PopState()
    {
        State lastState = m_states.Pop();
        lastState.OnExit();
        ScriptableObject.Destroy(lastState);
        if (m_states.Count <= 0)
            throw new UnityException("State machine stack empty");
        m_currentState = m_states.Peek();
		m_currentState.OnEnter();
    }

    public void SwitchState(State state)
    {
        State lastState = m_states.Pop();
        lastState.OnExit();
        ScriptableObject.Destroy(lastState);
        m_states.Push(state);
        state.SetStateMachine(this);
        m_currentState = state;
        m_currentState.OnEnter();
    }
}