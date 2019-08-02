using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveAction : Action
{
    public Vector2 Direction;
    public float Speed = 5f;

    public GameObject Skid;

    public override void OnUse()
    {

        Clown.instance.Rigidbody2D.velocity = (Direction) * Speed;

        base.OnUse();
    }

    public override void OnSelect()
    {
       // var skid = Instantiate(Skid);


        base.OnSelect();
    }

}
