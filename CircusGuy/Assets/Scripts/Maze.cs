using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
   
    public GameObject[] Items;
    public Sprite[] Maps;


    private void Start()
    {
        Create();
    }




    void Create()
    {

        int bCount = 0;
        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 32; y++)
            {
                for (int i = 0; i < Maps.Length; i++)
                {
                    if (Maps[i].texture.GetPixel(x, y).a > 0f)
                    {
                        if (i == 1)
                        {
                            bCount++;
                        }

                        var p = Instantiate(Items[i], transform);
                        p.transform.position = new Vector2(x - 16, y - 16);
                    }
                }
            }
        }

        MainCanvas.instance.TotalBaloons = bCount;
        MainCanvas.instance.DisplayBaloons();
    }
}
