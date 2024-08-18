using UnityEngine;

public class Pickup : MonoBehaviour
{
    // attached to any rigidbody that can pick up stuff
    public Rigidbody rigid;
    
    void OnCollisionEnter(Collision collision)
    {
        
        foreach (Rigidbody other in collision)
        {
            Debug.Log(other);
            // if other has the correct tag or tags
            // disable mass for it
            // parent it
            // 
        }
        

        
    }
}
