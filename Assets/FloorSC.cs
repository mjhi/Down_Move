using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y-GameManager.instance.Player.transform.position.y>=4.5)
        {
            GameManager.instance.FloorSpawn();
            Destroy(gameObject);
        }   
    }
}
