using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public GameObject[] Items;
    public Sprite[] Maps;

    public int BalloonLayer = 1;

    public Vector2Int StartPosition;

    public int BalloonsRequired = 20;
}
