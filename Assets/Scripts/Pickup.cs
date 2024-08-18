using UnityEngine;
using UnityEngine.TextCore;

public class Pickup : MonoBehaviour
{
    // attached to any rigidbody that can pick up stuff
    public Rigidbody rigid;

    public string pickupTag="pickup";
    
    void OnCollisionEnter(Collision collision)
    {
        
        foreach (ContactPoint contact in collision.contacts)
        {
            // get other object
            GameObject other = contact.otherCollider.gameObject;// collision.rigidbody.gameObject;
            if(other.tag == pickupTag){
                // disable collision for it
                other.GetComponent<Collider>().enabled = false;
                // disable gravity
                other.GetComponent<Rigidbody>().useGravity = false;
                // parent it
                other.transform.SetParent(this.transform);
                // make a joint
                FixedJoint joint = other.AddComponent<FixedJoint>();
                // set anochor
                joint.anchor = contact.point;// collision.contacts[0].point;
                // set connection
                joint.connectedBody = rigid;
            }
        }   
        
    }
}
