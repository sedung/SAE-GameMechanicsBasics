using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera/orbitCamera")]
public class orbitCamera : MonoBehaviour {

    public Transform target;
    public float distance = 4.0f;
    public float xSpeed = 100.0f;
    public float ySpeed = 100.0f;

    public float yMin = -20.0f;
    public float yMax = 90.0f;

    public float distanceMin = 0.6f;
    public float distanceMax = 30.0f;

    private Rigidbody rigid;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        rigid = GetComponent<Rigidbody>();

        // Freeze Rotation of the rigidbody if it exists
        if(rigid != null)
        {
            rigid.freezeRotation =true;
        }
    }

    void Update()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

        y = ClampAngle(y, yMin, yMax);

        Quaternion rot = Quaternion.Euler(y, x, 0);

        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

        RaycastHit hit;
        if(Physics.Linecast(target.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rot * negDistance + target.position;

        transform.rotation = rot;
        transform.position = position;

    }

    public static float ClampAngle(float a, float min, float max)
    {
        if(a < -360F)
        {
            a += 360F;
        }
        if(a > 360F)
        {
            a -= 360F;
        }

        return Mathf.Clamp(a, min, max);
    }

}
