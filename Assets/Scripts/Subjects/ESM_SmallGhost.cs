using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESM_SmallGhost : EnemyStateMachine
{
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask player;
    [SerializeField] private float localSphereOrigin, dmgSphereRad, dmg;

    [ExecuteInEditMode]
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + transform.forward * localSphereOrigin, dmgSphereRad);
    }

    public override void StartAttack()
    {
        
    }
    
    public override void Attack()
    {
        //TODO: Use link to Player and some if's instead of SphereCast to optimize code for ~1-e10 milliseconds for speed-runners
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, dmgSphereRad,
                transform.forward * localSphereOrigin, out hit, Mathf.Infinity, player))
        {
            hit.collider.gameObject.GetComponent<HaveHealth>().GetDmg(dmg);
        }
    }

    public override void StopAttack()
    {
        
    }
}
