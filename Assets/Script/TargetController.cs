using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] string tagName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            collision.gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagName))
        {
            other.gameObject.SetActive(false);   
        }
    }
}
