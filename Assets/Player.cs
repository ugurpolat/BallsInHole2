using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        print("ahmet");
    }

    // Update is called once per frame
    void Update()
    {
        
            this.transform.RotateAround(this.transform.position, new Vector3(0f, 1f, 0), 90f* Time.deltaTime);
        
        

    }
    
}
