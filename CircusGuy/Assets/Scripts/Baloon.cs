using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    public GameObject Effect;
  
    public AudioClip[] CollideEffects;

    public HudText HudText;

    public int Score = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var ht = Instantiate(HudText);
        ht.Set(transform.position, string.Format("+{0}",Score));
        MainCanvas.instance.UpdateScore(Score);
        var effect = Instantiate(Effect);
        effect.transform.position = transform.position;
        AudioEffects.instance.PlayEffect(CollideEffects[Random.Range(0, CollideEffects.Length)], 0.5f, 1f);
        MainCanvas.instance.RemoveBaloon();
        Destroy(gameObject);
    }
}
