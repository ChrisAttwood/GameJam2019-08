using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public SpriteRenderer[] Slots;
    public List<Action> Actions;

    public int Index;

    public AudioClip ChangeSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Cycle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cycle();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Actions[Index].OnUse();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Clown.instance.Rigidbody2D.velocity = Vector3.zero;
        }



    }

    void Cycle()
    {
        Index++;
        if(Index>= Actions.Count)
        {
            Index = 0;
        }

        for(int i = -4; i< 5; i++)
        {
            Slots[i + 4].sprite = GetAction(i + Index).Icon;
        }



    }

    public Action GetAction(int index)
    {
        int i = index;
        if (i < 0)
        {
            i = Actions.Count + i;
        }

        if (i >= Actions.Count)
        {
            i = i - Actions.Count;
        }

        return Actions[i];
    }
}
