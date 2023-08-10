using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class GunController : MonoBehaviour
{
    float range = 20, shootRate = 0.5f;
    float shootTimer;
    [SerializeField] TrailRenderer TrailObject;
    [SerializeField] ParticleSystem gunImpact;
    Camera fpsCam;

    private void OnEnable()
    {
        transform.GetComponent<EPOOutline.Outlinable>().enabled = false;
    }
    private void Start()
    {
        fpsCam = GetComponentInParent<Camera>();    
    }
    private void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && shootTimer >= shootRate)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        shootTimer = 0;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            gunImpact.Play();
            TrailRenderer t =  Instantiate(TrailObject, transform.position,Quaternion.identity);

            StartCoroutine(TrailEffect(t, hit));
            GameObject bullet = ObjectPooler.Instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = hit.point;
                bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                bullet.SetActive(true);
            }
        }
    }
    
    IEnumerator TrailEffect(TrailRenderer trail, RaycastHit hit)
    {
        float Ttime = 0f;
        Vector3 startPos = trail.transform.position;

        while (Ttime < 0.5f)
        {
            trail.transform.position = Vector3.Lerp(startPos, hit.point, Ttime);
            Ttime += Time.deltaTime / trail.time;

            yield return null;
        }

    }

}
