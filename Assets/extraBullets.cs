using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class extraBullets : MonoBehaviour
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
        if (collision.gameObject.name.StartsWith("FPSController") || collision.gameObject.name.StartsWith("FirstPersonCharacter") || collision.gameObject.name.StartsWith("MP7") || collision.gameObject.name.StartsWith("Aim")) {
            
            
            gunScript gs = FindObjectOfType<gunScript>();
            int bullets;
            bullets = gs.bulletCounter;
            bullets = 30 - bullets;
            if (bullets >= 5)
            {
                gs.bulletIncreaser(5);
            }
            else if(bullets<5) {
                gs.bulletIncreaser(bullets);
            }
              
            
           

                
        }
    }
}
