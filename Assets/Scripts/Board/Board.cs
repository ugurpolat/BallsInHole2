using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Transform m_EmptyPlane;
    public float m_height = 15;
    public float m_widht = 8;
    
    void Start()
    {
        DrawEmptyCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawEmptyCells()
    {
        for (float y = 2; y <= m_height; y++)
        {
            for (float x = 2; x <= m_widht; x++)
            {
                Transform clone;
                clone = Instantiate(m_EmptyPlane, new Vector3(x,0, y), Quaternion.identity) as Transform;
                clone.name = "Board Space(x = " + x.ToString() + " , z =" + y.ToString() + " )";
                clone.transform.parent = transform;
                
            }

        }
    }

   
}
