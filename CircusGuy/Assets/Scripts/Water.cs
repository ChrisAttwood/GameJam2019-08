using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject EffectPrefab;
    GameObject Effect;


    public AudioClip[] CollideEffects;
    // Start is called before the first frame update
    void Start()
    {
        Effect = Instantiate(EffectPrefab);
        Effect.transform.position = transform.position;
        Effect.gameObject.SetActive(false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Effect.gameObject.SetActive(true);
        AudioEffects.instance.PlayEffect(CollideEffects[Random.Range(0, CollideEffects.Length)], 0.5f, 1f);
    }

  

    private void OnTriggerStay2D(Collider2D collision)
    {
        Effect.gameObject.SetActive(true);
        var pos = Clown.instance.transform.position;
        pos.y -= 0.5f;

        Effect.transform.position = pos;
        Debug.Log("x");
        Clown.instance.MoveMod = 0.1f;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Clown.instance.MoveMod = 1f;
        Effect.gameObject.SetActive(false);
    }
   

}
