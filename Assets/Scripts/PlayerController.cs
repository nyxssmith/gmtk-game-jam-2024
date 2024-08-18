using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigid;
    public float speedLimit = 1.0f;
    public float moveSpeed = 5;
    // Start is called before the first frame update
    //void Start()
    //{
    //    rigid = GetComponent<Rigidbody>();
    //}
    // Update is called once per frame
    void Update()
    {
        // take in motion
        float vertical = Input.GetAxis("Vertical")*moveSpeed;
        float horizontal = Input.GetAxis("Horizontal")*moveSpeed;
        // apply forces to self

        if (rigid.GetAccumulatedForce().magnitude < this.speedLimit) {
            rigid.AddForce(new Vector3(0,0,vertical),ForceMode.Force);
            rigid.AddForce(new Vector3(horizontal,0,0),ForceMode.Force);
        }
        
    }
}
