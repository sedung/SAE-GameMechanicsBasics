using UnityEngine;
using System.Collections;

public class hpBar : MonoBehaviour {

    GameObject obj;
    player ply;

    // Use this for initialization
    void Start()
    {
        // Get Player object and player script component
        obj = GameObject.Find("Player");
        ply = obj.GetComponent<player>();
        calcHp(20);
    }

    // Update is called once per frame
    void LateUpdate () {
        
	}

    public void calcHp (int dmg)
    {
        ply.curHp -= dmg;
        Debug.Log("BaseHp " + ply.curHp);
        Debug.Log("MaxHp " + ply.maxHp);
        float Hp = (float)ply.curHp / (float)ply.maxHp; // Example 80 / 100 = 0.8
        Debug.Log("CalcHP " + Hp);
        setHpBar(Hp);
    }

    public void setHpBar (float Hp)
    {
        // Change object scale based on calculated HealthPoints (Hp) and clamp the values between 0.0 and 1.0
        transform.localScale = new Vector3(Mathf.Clamp(Hp, 0f, 1f),transform.localScale.y, transform.localScale.z);
    }
}
