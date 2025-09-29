using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velding : MonoBehaviour
{
    public GameObject veldingPrefab;
    public GameObject mashine;
    public GameObject veldArea;

    private void OnCollisionEnter(Collision collision)
    {
        float x = veldArea.transform.position.x;
        float z = veldArea.transform.position.z;

        if (collision.gameObject.GetComponent<Electrod>())
        {
            ContactPoint contact = collision.contacts[0];
            if (contact.point.x >= x - veldArea.transform.lossyScale.x / 2 &&
                contact.point.x <= x + veldArea.transform.lossyScale.x / 2 &&
                contact.point.z >= z - veldArea.transform.lossyScale.z / 2 &&
                contact.point.z <= z + veldArea.transform.lossyScale.z / 2)
            {
                Instantiate(veldingPrefab, new Vector3(contact.point.x, veldArea.transform.position.y +
                    veldArea.transform.lossyScale.y / 2, contact.point.z), Quaternion.identity);
            }
        }
    }
}
