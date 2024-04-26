using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyStateMachine : HaveHealth
{
    [SerializeField] protected RoomFightOne room;
    
    private IState currentState;
    
    public Transform Player;
    public EnemyMovementCtrl Move;
    public float MoveRad;

    public float AttackCooldown, AttackPrep;
    
    
    protected virtual void Awake()
    {
        if (currentState != null) GameManager.Upd += currentState.UpdateState;
        OnDeath += Death;
        OnDeath += room.CheckEnemyCount;
    }

    [ExecuteInEditMode]
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, MoveRad);
        
        Gizmos.color = new Color(.8f,0,.8f);
        Gizmos.DrawWireSphere(transform.position, MoveRad * 2);
    }

    protected virtual void Start()
    {
        Player = PlayerInteracter.PI.transform;
        ChangeState(new MovingState());
    }

    public virtual void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
            GameManager.Upd -= currentState.UpdateState;
        }

        currentState = newState;
        currentState.OnEntryState(this);
        GameManager.Upd += currentState.UpdateState;
    }

    public override void GetDmg(float dmg)
    {
        base.GetDmg(dmg);
        currentState.GetHit();
    }
    
    public virtual void StartAttack()
    {
        
    }
    
    public virtual void Attack()
    {
        
    }
    
    public virtual void StopAttack()
    {
        
    }

    protected virtual void Death()
    {
        ChangeState(new DeathState());
        Destroy(gameObject); //TODO: remove later
    }
}

public interface IState
{
    EnemyStateMachine stateMachine { get; set; }

    public void OnEntryState(EnemyStateMachine sc);

    public void OnExitState();
    public void UpdateState();
    public void Act();
    public void GetHit();
}

public class IdleState : IState
{
    public EnemyStateMachine stateMachine { get; set; }

    public void OnEntryState(EnemyStateMachine sc)
    {
        stateMachine = sc;
    }
    
    public void OnExitState()
    {
        
    }

    public void UpdateState()
    {
        
    }

    public void Act()
    {
        
    }
    
    public void GetHit()
    {
        
    }
}

public class MovingState : IState
{
    public EnemyStateMachine stateMachine { get; set; }

    public void OnEntryState(EnemyStateMachine sc)
    {
        stateMachine = sc;
    }

    public void OnExitState()
    {

    }

    public void UpdateState()
    {
        Act();
    }

    public void Act()
    {
        float r = stateMachine.MoveRad;
        Transform p = stateMachine.Player;
        EnemyMovementCtrl mv = stateMachine.Move;
        
        float dis = (stateMachine.transform.position - p.position).magnitude;

        float sp = mv.GetSpeed();
        if (dis < r * 2)
        {
            float s = Mathf.Lerp(sp, 0, (r * 2 - dis) / r);
            mv.SetSpeed(s);
            if (s <= 1)
            {
                stateMachine.ChangeState(new PreAttackState());
                return;
            }
        }
        else
            mv.SetSpeed();
        
        Vector3 vel = (p.position - stateMachine.transform.position);
        vel.y = vel.z;
        vel.z = 0;
        mv.SetVector(vel.normalized);
        mv.Move();
        mv.Rotate(p, true);
    }

    public void GetHit()
    {
        stateMachine.ChangeState(new MovingState());
    }
}

public class PreAttackState : IState
{
    public EnemyStateMachine stateMachine { get; set; }
    private float t;

    public void OnEntryState(EnemyStateMachine sc)
    {
        stateMachine = sc;
        t = stateMachine.AttackPrep;
        //anim.play
    }

    public void OnExitState()
    {
        
    }

    public void UpdateState()
    {
        t -= Time.deltaTime;
        if (t<=0) Act();
    }

    public void Act()
    {
        //attack?
        stateMachine.StartAttack();
        stateMachine.ChangeState(new AttackState());
    }

    public void GetHit()
    {
        
    }
}

public class AttackState : IState
{
    public EnemyStateMachine stateMachine { get; set; }
    private float t;

    public void OnEntryState(EnemyStateMachine sc)
    {
        stateMachine = sc;
        t = 0.1f;
        //anim.play
    }

    public void OnExitState()
    {
        
    }

    public void UpdateState()
    {
        t -= Time.deltaTime;
        if (t<=0) Act();
    }

    public void Act()
    {
        //attack?
        stateMachine.Attack();
        stateMachine.ChangeState(new AfterAttackState());
    }

    public void GetHit()
    {
        stateMachine.ChangeState(new AfterAttackState());
    }
}

public class AfterAttackState : IState
{
    public EnemyStateMachine stateMachine { get; set; }
    private float t;

    public void OnEntryState(EnemyStateMachine sc)
    {
        stateMachine = sc;
        t = stateMachine.AttackCooldown;
        //anim.play
    }

    public void OnExitState()
    {
        
    }

    public void UpdateState()
    {
        t -= Time.deltaTime;
        if (t<=0) Act();
    }

    public void Act()
    {
        stateMachine.StopAttack();
        stateMachine.ChangeState(new MovingState());
    }

    public void GetHit()
    {
        
    }
}

public class DeathState : IState
{
    public EnemyStateMachine stateMachine { get; set; }
    private float t;

    public void OnEntryState(EnemyStateMachine sc)
    {
        //anim.play
    }

    public void OnExitState()
    {

    }

    public void UpdateState()
    {

    }

    public void Act()
    {

    }

    public void GetHit()
    {

    }
}
