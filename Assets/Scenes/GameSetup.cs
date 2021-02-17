using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    Grid grid = new Grid(9, 16, 1);
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting to create Cube");        
        StartCoroutine(setupBlocks());        
    }

    IEnumerator setupBlocks()
    {
        for (int y = 0; y < grid.getHeight(); y++)
        {
            for (int x = 0; x < grid.getWidth(); x++)
            {
                if (x == 0 || x == (grid.getWidth() - 1) || y == 0 || y == (grid.getHeight() - 1))
                {
                    GameObject clone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    clone.transform.position = new Vector3(x + grid.getCellSize(), 0, y + grid.getCellSize());
                    clone.transform.parent = transform;
                    yield return new WaitForSeconds(0.005f);
                }
            }
        }
        //GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = new Vector3(Random.Range(2, 9), 0, Random.Range(2, 15));
        //GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = new Vector3(Random.Range(2, 9), 0, Random.Range(2, 15));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
