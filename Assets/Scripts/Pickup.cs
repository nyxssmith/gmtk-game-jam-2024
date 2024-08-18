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
                ModifySelf(other,contact);
            }
        }   
    }

    private void ModifyPickup(GameObject other,ContactPoint contact){
        // TODO debug crazy jiggling
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
    private void ModifySelf(GameObject other,ContactPoint contact){
        // first check where object hit on face
        // need to check that ball is covered enough before a scale change

        // if not big enough add size of other to size should add buffer
        // once its time for a scale change do that
        // ex: small objs add .5 and keep track of list of small objects this size change
        // once has enough small can get medium etc
        Debug.Log(contact.normal);


        // TODO change below to above code
        // make self bigger based on other object
        //collider.radius+=1;

        // update camera
        //cameraFollower.UpdateLocationOffset(collider.radius);


    }
    public void UpdateCamera(CameraFollow newCameraFollwer){
        // camera calls this to tell player about itself
        cameraFollower = newCameraFollwer;
    }
}
