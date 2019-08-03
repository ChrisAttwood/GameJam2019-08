using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public SpriteRenderer[] Slots;
    public List<Action> Actions;

    public int Index;

    public AudioClip[] ChangeSoundEffects;
    public AudioClip[] LiftSoundEffects;
    


    public List<Action> Queued;

    public static Barrel instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        Queued = new List<Action>();


        for(int i = 0; i < 99; i++)
        {
            Queued.Add(Actions[Random.Range(0, Actions.Count)]);
        }



        Cycle();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioEffects.instance.PlayEffect(ChangeSoundEffects[Random.Range(0, ChangeSoundEffects.Length)], 0.5f,1f);
            
            Queued[Index].OnStart();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Queued[Index].OnUse();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Cycle();
            AudioEffects.instance.PlayEffect(LiftSoundEffects[Random.Range(0, LiftSoundEffects.Length)], 0.5f, 1f);
            Clown.instance.Rigidbody2D.velocity = Vector3.zero;
            Queued[Index].OnStop();
        }

        

    }

    void Cycle()
    {
        Index++;
        if(Index>= Queued.Count)
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
            i = Queued.Count + i;
        }

        if (i >= Queued.Count)
        {
            i = i - Queued.Count;
        }

        return Queued[i];
    }

   
}
