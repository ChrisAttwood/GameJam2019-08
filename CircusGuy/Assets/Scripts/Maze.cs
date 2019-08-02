using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public GameObject Wall;
    public Sprite WallMap;

    private void Awake()
    {
        Create();
    }


    void Create()
    {
        for(int x= 0; x < 32; x++)
        {
            for (int y = 0; y < 32; y++)
            {
                if(WallMap.texture.GetPixel(x,y) == Color.black)
                {
                    var p = Instantiate(Wall, transform);
                    p.transform.position = new Vector2(x-16, y-16);
                }
            }
        }
    }

    
}
