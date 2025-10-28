using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Velding : MonoBehaviour
{
    public GameObject veldingPrefab;
    public GameObject mashine;
    public GameObject veldArea;
    public GameObject prefParent;

    private GameObject obj;

    private void OnCollisionStay(Collision collision)
    {
        float x = veldArea.transform.position.x;
        float z = veldArea.transform.position.z;
        float y = veldArea.transform.position.y;

        if (collision.gameObject.GetComponent<Electrod>())
        {
            ContactPoint contact = collision.contacts[0];
            if (contact.point.x >= x - veldArea.transform.lossyScale.x / 2 &&
                contact.point.x <= x + veldArea.transform.lossyScale.x / 2 &&
                contact.point.z >= z - veldArea.transform.lossyScale.z / 2 &&
                contact.point.z <= z + veldArea.transform.lossyScale.z / 2 &&
                contact.point.y - y - veldArea.transform.lossyScale.y / 2 <= 0.03f)
            {
                if (obj != null)
                {
                    if (contact.point.x > 0 && contact.point.z > 0)
                    {
                        if (obj.transform.position.x - contact.point.x < 0.005f && obj.transform.position.z - contact.point.z < 0.005f)
                        {
                            return;
                        }
                    }
                    else if (contact.point.x < 0 && contact.point.z < 0)
                    {
                        if (obj.transform.position.x - contact.point.x > 0.005f && obj.transform.position.z - contact.point.z > 0.005f)
                        {
                            return;
                        }
                    }
                }
                obj = Instantiate(veldingPrefab, new Vector3(contact.point.x, veldArea.transform.position.y +
                    veldArea.transform.lossyScale.y / 2, contact.point.z), Quaternion.identity, prefParent.transform);
            }
        }
    }
}