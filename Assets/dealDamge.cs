using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamge : MonoBehaviour
{

    public int dmg = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "player"){
            GetComponent<playerTakeHit>().takeHit(dmg);
        }
    }
}
