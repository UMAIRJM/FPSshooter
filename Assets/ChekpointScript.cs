using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekpointScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("FPSController") || collision.gameObject.name.StartsWith("FirstPersonCharacter") || collision.gameObject.name.StartsWith("MP7") || collision.gameObject.name.StartsWith("Aim"))
        {
            gunScript gs = FindObjectOfType<gunScript>();
            if (gs.checkpointerFlag == true)
            {
                gs.respawnFuntion();
                gs.checkpointerFlag = false;    
            }
        }
    }
}
