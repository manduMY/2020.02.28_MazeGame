using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMove : MonoBehaviour
{
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

        
        
    }
    void BreakBrick()
    {
        //GameObject temp = GameObject.Find("Cube");
        //GameObject go = GameObject.Find("Player");
        ////go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        ////go.transform.position = transform.position
        ////+ new Vector3(-0.5f, 0, 0);
        //transform.position += transform.forward * 0.5f;
        //go.AddComponent<Rigidbody>();
        ////go.GetComponent<Rigidbody>().AddForce(transform.forward * 2f);
        //go.AddComponent<DWGDestroyer>();

        ////Destroy(go, 5f);
    }
}
