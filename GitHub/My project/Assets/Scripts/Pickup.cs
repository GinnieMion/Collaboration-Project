using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool isHolding = false;
    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    TempParent tempParent;
    Rigidbody rb;

    Vector3 objectPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tempParent = TempParent.Instance;
    }


    void Update()
    {
        if (isHolding)
            Hold();
    }

    private void OnMouseOver()
    {
        if (tempParent != null)
        {
            if(Input.GetKeyDown(KeyCode.E) && !isHolding)
            {
                distance = Vector3.Distance(this.transform.position, tempParent.transform.position);

                if (distance <= maxDistance)
                {
                    isHolding = true;
                    rb.useGravity = false;
                    rb.detectCollisions = true;

                    this.transform.SetParent(tempParent.transform);
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && isHolding)
            {
                Drop();
            }
          
        }
        else
        {
            Debug.Log("Temp Parent item not found in scene!");
        }
    }

    //private void OnMouseUp()
    //{
      //  Drop();
   // }

    private void OnMouseExit()
    {
        //Drop();
    }
    private void Hold()
    {
        Debug.Log("Holding");
        distance = Vector3.Distance(this.transform.position, tempParent.transform.position);

        if (distance >= maxDistance)
        {
            Drop();
        }
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (Input.GetMouseButtonDown(1))
        {
            rb.AddForce(tempParent.transform.forward * throwForce);
            Drop();
        } 
    }

    private void Drop()
    {
        if (isHolding)
        {
            Debug.Log("dropped");
            isHolding=false;
            objectPos= this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
            rb.detectCollisions = true;

        }
    }
          
      
    

    
    
}
