using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;
    GameObject t_clone;

    public void Explosion()
    {
        t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);
        Rigidbody[] t_rigids = t_clone.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < t_rigids.Length; i++)
        {
            t_rigids[i].AddExplosionForce(m_force, transform.position + m_offset, 10f);
        }
        gameObject.SetActive(false);

        Invoke("triggerCheck", 2f);
        InvokeRepeating("fadeDebris", 2f, 0.5f);
        Invoke("CancelingInvoke", 3f);
        Destroy(t_clone, 3.8f);
    }
    void triggerCheck()
    {
        for (int i = 0; i < 64; i++)
        {
            t_clone.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    void fadeDebris()
    {
        for (int i = 0; i < 64; i++)
        {
            t_clone.transform.GetChild(i).transform.position -= Vector3.up * 0.2f * Time.deltaTime;
        }
    }
    void CancelingInvoke()
    {
        CancelInvoke("fadeDebris");
    }
}