using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunPicker : MonoBehaviour
{
    [SerializeField] GameObject GunPickerParent;
    [SerializeField] GameObject Gun;
    [SerializeField] Button pickUputton;

    private void Start()
    {
        pickUputton.onClick.AddListener(GunPickUp);
    }


    public void GunPickUp()
    {
        Gun.transform.SetParent(GunPickerParent.transform);
        //Gun.transform.position = Vector3.Lerp(Gun.transform.position, GunPickerParent.transform.position, 2f);
        Gun.transform.localPosition = Vector3.zero;
        Gun.transform.localRotation = Quaternion.Euler(Vector3.zero);
        Gun.GetComponent<GunController>().enabled = true;
        transform.GetComponent<FirstPersonLook>().enabled = true;
    }
}
