using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] Transform target, point;
    [SerializeField] GameObject circle;
    [SerializeField] bool isShowing;
    [SerializeField] float r;

    private void Awake()
    {
        GameManager.FxUpd += SetTargetPos;
        SetPointVis(false);
    }

    public void SetTarget(Transform targ)
    {
        target = targ;
    }

    public void SetPointVis(bool s)
    {
        isShowing = s;

        point.gameObject.SetActive(isShowing);
        circle.SetActive(isShowing);
    }

    public void SetTargetPos()
    {
        if (Input.GetMouseButtonDown(1)) SetPointVis(true);
        if (Input.GetMouseButtonUp(1)) SetPointVis(false);

        if (!isShowing) return;

        Vector3 pos = target.position;
        pos.y = transform.position.y;

        pos -= transform.position;
        pos = pos.normalized * r;

        point.position = pos + transform.position;
    }
}
