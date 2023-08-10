using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }
    private void OnEnable()
    {
        if(this.gameObject) {
            Invoke("DisableOject",2f);
        }
    }

    private void OnDisable()
    {
        transform.position = initialPos;
    }

    private void DisableOject()
    {
        gameObject.SetActive(false);
    }
}
