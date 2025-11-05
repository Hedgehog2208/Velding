using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MetallPlane : MonoBehaviour
{
    public GameObject pref;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Velding>() && (gameObject.transform.position == trig.transform.position ||
                    gameObject.transform.position == trig1.transform.position))
        {
            Debug.Log("asdadwa");
            for (int i = 0; i < planes.Length; i++)
            {
                if (planes[i].transform.position == trig.transform.position)
                {
                    Debug.Log("asdadwa");
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

                            ContactPoint point = collision.contacts[0];

                            Debug.Log("fsfsf");

                            if (obj == null)
                            {
                                obj = Instantiate(pref, new Vector3(posX, gameObject.transform.position.y, point.point.z), Quaternion.identity);
                            }
                            else { obj.transform.localScale = new Vector3(scaleX, obj.transform.lossyScale.y, obj.transform.lossyScale.z);}
                                gameObject.transform.localScale = new Vector3(scaleX, 1, 2);
                        }
                    }
                }
            }
        }
    }
}