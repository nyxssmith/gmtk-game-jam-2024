using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;

    void FixedUpdate()
    {

        //Vector3 desiredPosition = new Vector3(target.position.x,0,target.position.z) + locationOffset;
        Vector3 desiredPosition = target.position + locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = Quaternion.Euler(rotationOffset);
        transform.rotation = desiredrotation;
        //Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        //transform.rotation = smoothedrotation;
    }
}