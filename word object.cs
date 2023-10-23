using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordobject : MonoBehaviour
{
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ball Robot"){
            BallRobot player = other.GetComponent<BallRobot>();
            player.wordCount++;
            gameObject.SetActive(false);
        }
    }
}
