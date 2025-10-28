using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MetallPlane : MonoBehaviour
{
    public GameObject veldMash;
    public MetallPlane[] planes;
    private Collider trig;
    private Collider trig1;
    private GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < planes.Length; i++) 
        { 
            if (planes[i].transform.position == other.transform.position)
            {
                return;
            } 
        }
        if ( trig == null ) trig = other; else trig1 = other;
            Destroy(gameObject.GetComponent<Throwable>());
        Destroy(gameObject.GetComponent<Interactable>());
        //Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.transform.position = other.transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].transform.position == trig.transform.position && collision.gameObject.GetComponent<Velding>())
            {
                for (int j = 0; j < planes.Length; j++)
                {
                    if (planes[j].transform.position == trig1.transform.position)
                    {
                        Debug.Log("asdadwa");
                        float scaleX;
                        if (((trig.transform.position.x - trig.transform.lossyScale.x / 2) - (trig1.transform.position.x + trig1.transform.lossyScale.x / 2))
                            < (trig.transform.position.x + trig.transform.lossyScale.x / 2) - (trig1.transform.position.x - trig1.transform.lossyScale.x / 2))
                        {
                            scaleX = (trig.transform.position.x - trig.transform.lossyScale.x / 2) - (trig1.transform.position.x + trig1.transform.lossyScale.x / 2);
                        }
                       
                        else scaleX = (trig.transform.position.x + trig.transform.lossyScale.x / 2) - (trig1.transform.position.x - trig1.transform.lossyScale.x / 2);
                        float posX;
                        if (trig.transform.position.x > trig.transform.lossyScale.x)
                        { posX = trig.transform.position.x - (trig.transform.position.x - trig1.transform.position.x); }
                        else posX = trig.transform.position.x + (trig1.transform.position.x - trig.transform.position.x);

                        Debug.Log("fsfsf");

                        gameObject.transform.localScale = new Vector3(scaleX, 2, 2);
                    }
                }
            }
        }
    }
}
