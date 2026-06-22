using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objPickup : MonoBehaviour
{
    public GameObject crosshair1, crosshair2;
    public Transform objTransform, cameraTrans;
    public bool interactable, pickedUp;
    public Rigidbody objRigidbody;
    public float throwAmount;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(true);
            crosshair2.SetActive(false);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(true);
            crosshair2.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                objTransform.parent = cameraTrans;
                objRigidbody.useGravity = false;
                pickedUp = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                pickedUp = false;
            }
            if (pickedUp == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    objRigidbody.velocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                    pickedUp = false;
                }

            }
        }
    }
}
         
        