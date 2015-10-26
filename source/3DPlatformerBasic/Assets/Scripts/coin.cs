using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

    public int coinValue = 100;
    public int destroyCoinAfterXSeconds = 0;

	void OnTriggerEnter()
    {
        player ply = GameObject.Find("Player").GetComponent<player>();

        ply.calcPoints(coinValue);
    
        Destroy(gameObject, destroyCoinAfterXSeconds);
    }

}
