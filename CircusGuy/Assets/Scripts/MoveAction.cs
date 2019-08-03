using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveAction : Action
{
    public Vector2 Direction;
    public float Speed = 5f;

    public GameObject Skid;
    public Direction LookDirection;

    public override void OnUse()
    {

        Clown.instance.Rigidbody2D.velocity = (Direction) * Speed * Clown.instance.MoveMod;
        Clown.instance.Direction = LookDirection;
        base.OnUse();
    }

    public override void OnStart()
    {

        SkidEffect();

        base.OnStart();
    }

    public override void OnStop()
    {
        SkidEffect();
        base.OnStop();
    }

    void SkidEffect()
    {

        var skid = Instantiate(Skid);
        var pos = Clown.instance.transform.position;
        pos.y -= 0.5f;
        skid.transform.position = pos;
    }

}
