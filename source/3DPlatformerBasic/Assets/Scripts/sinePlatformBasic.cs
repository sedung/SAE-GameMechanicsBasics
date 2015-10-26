using UnityEngine;
using System.Collections;

public class sinePlatformBasic : MonoBehaviour {

    Vector3 startPos;

    protected void Start()
    {
        startPos = transform.position;
    }

    protected void Update()
    {
        float distance = Mathf.Sin(Time.timeSinceLevelLoad);
        transform.position = startPos + Vector3.up * distance;
    }
}
