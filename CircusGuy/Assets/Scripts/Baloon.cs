using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    public GameObject Effect;
  
    public AudioClip[] CollideEffects;

    public HudText HudText;

    public SpriteRenderer SpriteRenderer;
    public Color[] Colours;
    float Seed;

    public int Score = 100;
    Vector2 route;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer.color = Colours[Random.Range(0, Colours.Length)];
        Seed = Random.Range(0f, 9999f);
        route = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float rise = Mathf.PerlinNoise(Time.time, Seed);
        transform.localPosition = new Vector2(route.x, route.y - rise);
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
