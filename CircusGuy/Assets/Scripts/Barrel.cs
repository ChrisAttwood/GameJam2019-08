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

    public bool Spinning = false;

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

        if (Input.GetKey(KeyCode.Space)&&!Spinning)
        {
            Queued[Index].OnUse();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Cycle();
            AudioEffects.instance.PlayEffect(LiftSoundEffects[Random.Range(0, LiftSoundEffects.Length)], 0.5f, 1f);

            if (!Spinning)
            {
                Clown.instance.Rigidbody2D.velocity = Vector3.zero;
            }

           
            Queued[Index].OnStop();
        }

        if (Spinning)
        {
            Clown.instance.Rigidbody2D.velocity = new Vector2((Mathf.PerlinNoise(Time.time, 0f) - 0.5f)*20f, (Mathf.PerlinNoise(Time.time, 100f) - 0.5f)*20f);
        }

        

    }

    public void Spin()
    {
        Spinning = true;
        Clown.instance.Direction = Direction.Spin;
        Invoke("ReturnControl", 1f);
    }

    void ReturnControl()
    {
        Spinning = false;
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
