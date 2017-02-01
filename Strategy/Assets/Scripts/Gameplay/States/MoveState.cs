using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveState : State
{
    [SerializeField]
    private Vector3 m_direction;
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private float m_time;

    public MoveState(Vector3 direction, float speed)
    {
        m_direction = direction;
        m_speed = speed;
        m_time = m_direction.magnitude / speed;
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void Update()
    {
        float deltaTime = Mathf.Min(Time.deltaTime, m_time);
        m_time -= deltaTime;
        transform.position += m_direction.normalized * m_speed * deltaTime;
        if (m_time <= 0)
            PopState();
    }
}
