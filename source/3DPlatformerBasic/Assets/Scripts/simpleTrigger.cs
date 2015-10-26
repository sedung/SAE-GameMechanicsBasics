using UnityEngine;
using System.Collections;

public class simpleTrigger : MonoBehaviour {

        

    void Start()
    {
    }

	void OnTriggerEnter()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        player ply = obj.GetComponent<player>();

        ply.points += 100;
    
        Destroy(gameObject, 1);
    }

}
