using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisImpact : MonoBehaviour
{
    Vector3 pos;
    Rigidbody rigid;

    void Start()
    {
        
        pos = this.gameObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (pos.x != this.gameObject.transform.position.x || pos.y != this.gameObject.transform.position.y)
        {
            //for(int i=0;i<10;i++)
            //{
            //    transform.Translate(transform.up * -2f * Time.deltaTime);
            //}
            //Invoke("fadeDebris", 3f);
            //Invoke("TriggerOn", 3f);
            //InvokeRepeating("fadeDebris", 3f, 0.2f);
           
            //StartCoroutine(MoveDown(transform, 0.7f, 0.7f));

      
            //Invoke("downDebris", 1);
            Destroy(this.gameObject, 3f);
        }
    }
    void TriggerOn()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    void fadeDebris()
    {
       
        transform.position -= Vector3.up * 0.2f * Time.deltaTime;
        //for (int i = 0; i < 10; i++)
        //{
        //    transform.Translate(transform.up * -2f * Time.deltaTime);
        //}
    }
    IEnumerator MoveDown(Transform thisTransform, float distance, float speed)
    {
        float startPos = thisTransform.position.y;
        float endPos = startPos - distance;
        float rate = 1.0f / Mathf.Abs(startPos - endPos) * speed;
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * rate;
            Vector3 pos = thisTransform.position;
            pos.y = Mathf.Lerp(startPos, endPos, t);
            thisTransform.position = pos;
            yield return 0;
        }
    }
}
