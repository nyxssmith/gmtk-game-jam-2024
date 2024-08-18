using UnityEngine;
using UnityEngine.TextCore;

public class Pickup : MonoBehaviour
{
    // attached to any rigidbody that can pick up stuff
    public Rigidbody rigid;

    public string pickupTag="pickup";
    public float massMultiplierToPickups=0.1f;// 1.0 = no chancge to mass of pickups
    
    private SphereCollider collider;
    private CameraFollow cameraFollower;
    void Start()
    {
        // when started get self's collider and setup ranges
        collider = GetComponent<SphereCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        foreach (ContactPoint contact in collision.contacts)
        {
            // get other object
            GameObject other = contact.otherCollider.gameObject;// collision.rigidbody.gameObject;
            if(other.tag == pickupTag){
                ModifyPickup(other,contact);
                ModifySelf(other);
            }
        }   
    }

    private void ModifyPickup(GameObject other,ContactPoint contact){

                // disable collision for it
                other.GetComponent<Collider>().enabled = false;
                // disable gravity
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().mass*=massMultiplierToPickups;
                // parent it
                other.transform.SetParent(this.transform);
                // make a joint
                FixedJoint joint = other.AddComponent<FixedJoint>();
                // set anochor
                joint.anchor = contact.point;// collision.contacts[0].point;
                // set connection
                joint.connectedBody = rigid;
    }
    private void ModifySelf(GameObject other){
        // make self bigger based on other object
        collider.radius+=1;
        // update camera
        cameraFollower.UpdateLocationOffset(collider.radius);


    }
    public void UpdateCamera(CameraFollow newCameraFollwer){
        cameraFollower = newCameraFollwer;
    }
}
