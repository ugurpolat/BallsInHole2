using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest1 : MonoBehaviour
{

    public Swipe swipeControls;
    public Transform player;
    private Vector3 startPos;
    Animator anim;
    Vector3 endPos;
    private Rigidbody rb;

    public float zTop = 15f;
    public float zBottom = 2f;
    public float xLeft = 2;
    public float xRight = 8;
    float distanceZ = 0;
    float distanceX = 0;
    bool isRolling;


    private void Start()
    {
        rb = player.gameObject.GetComponent<Rigidbody>();
        startPos = player.transform.position;
        anim = gameObject.GetComponent<Animator>();
        //anim.enabled = false;
    }
    void Update()
    {
        if (!isRolling)
        {
            if (swipeControls.SwipeLeft)
            {

                distanceX = xLeft - startPos.x;
                endPos = startPos + new Vector3(distanceX, 0, 0);

                if (player.transform.position == endPos)
                {

                }
                else if (player.transform.position == startPos)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.AddForce((endPos - startPos) * 120);
                    isRolling = true;
                }


            }
            if (swipeControls.SwipeRight)
            {
                distanceX = xRight - startPos.x;
                endPos = startPos + new Vector3(distanceX, 0, 0);

                if (player.transform.position == endPos)
                {


                }
                else if (player.transform.position == startPos)
                {

                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.AddForce((endPos - startPos) * 120);
                    isRolling = true;
                }

            }
            if (swipeControls.SwipeUp)
            {

                distanceZ = zTop - startPos.z;
                endPos = startPos + new Vector3(0, 0, distanceZ);

                if (player.transform.position == endPos)
                {

                }
                else if (player.transform.position == startPos)
                {

                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.AddForce((endPos - startPos) * 140f);
                    isRolling = true;
                }

            }
            if (swipeControls.SwipeDown)
            {

                distanceZ = zBottom - startPos.z;
                endPos = startPos + new Vector3(0, 0, distanceZ);

                if (player.transform.position == endPos)
                {


                }
                else if (player.transform.position == startPos)
                {

                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.AddForce((endPos - startPos) * 140);
                    isRolling = true;
                }


            }
        }
        
        


    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Square")
        {

            if (target.gameObject.transform.position.z == endPos.z)
            {

                StartCoroutine(StopForce());

            }
            else if (target.gameObject.transform.position.x == endPos.x)
            {
                StartCoroutine(StopForce());
            }

        }
        
        if (target.gameObject.tag == "Gold")
        {
            Destroy(target.gameObject);
        }
       
    }
    

    IEnumerator StopForce()
    {
        
        yield return new WaitForSeconds(0.32f);
        rb.Sleep();
        player.position = endPos;
        startPos = endPos;
        
        isRolling = false;
        
        
    }

    IEnumerator StopForce2()
    {
        yield return new WaitForSeconds(0.32f);
        rb.Sleep();
        
    }
}
    

