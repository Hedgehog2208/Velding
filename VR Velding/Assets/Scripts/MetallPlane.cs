using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

                            ContactPoint point = collision.contacts[0];

                            if (obj == null)
                            {
                                float scaleX;
                                if (((trig.transform.position.x - trig.transform.lossyScale.x / 2) - (trig1.transform.position.x + trig1.transform.lossyScale.x / 2))
                                    < (trig.transform.position.x + trig.transform.lossyScale.x / 2) - (trig1.transform.position.x - trig1.transform.lossyScale.x / 2))
                                {
                                    scaleX = (trig.transform.position.x - trig.transform.lossyScale.x / 2) - (trig1.transform.position.x + trig1.transform.lossyScale.x / 2);
                                }

                                else scaleX = (trig.transform.position.x + trig.transform.lossyScale.x / 2) - (trig1.transform.position.x - trig1.transform.lossyScale.x / 2);

                                float posX;
                                if (trig.transform.position.x > trig1.transform.position.x)
                                { posX = trig.transform.position.x - (trig.transform.position.x - trig1.transform.position.x) / 2; }
                                else posX = trig.transform.position.x + (trig1.transform.position.x - trig.transform.position.x) / 2;

                                Debug.Log("fsfsf");

                                obj = Instantiate(pref, new Vector3(posX, gameObject.transform.position.y, point.point.z), Quaternion.identity);
                                obj.transform.localScale = new Vector3(scaleX, obj.transform.lossyScale.y, obj.transform.lossyScale.z);
                            }
                            else 
                            { 
                                    if (obj.transform.position.z > point.point.z)
                                    {
                                        float oldPosZ = obj.transform.position.z;

                                        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y,
                                            point.point.z + ((obj.transform.position.z + obj.transform.lossyScale.z / 2) - point.point.z) / 2);

                                        obj.transform.localScale = new Vector3(obj.transform.lossyScale.x, obj.transform.lossyScale.y,
                                            oldPosZ + obj.transform.lossyScale.z / 2 - point.point.z);
                                    }
                                    else
                                    {
                                        float oldPosZ = obj.transform.position.z;

                                        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y,
                                            point.point.z - (point.point.z - (obj.transform.position.z - obj.transform.lossyScale.z / 2)) / 2);

                                        obj.transform.localScale = new Vector3(obj.transform.lossyScale.x, obj.transform.lossyScale.y,
                                            point.point.z - oldPosZ - obj.transform.lossyScale.z / 2);
                                    }
                            }
                        }
                    }
                }
            }
        }
    }
}