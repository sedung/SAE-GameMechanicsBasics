using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

    public int coinValue = 100;
    public int destroyCoinAfterXSeconds = 0;
    public float rotationSpeed = 100.0f;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

	void OnTriggerEnter()
    {
        player ply = GameObject.Find("Player").GetComponent<player>();

        ply.calcPoints(coinValue);
    
        Destroy(gameObject, destroyCoinAfterXSeconds);
    }

}
