using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource bulletSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()   
    {
        if (Input.GetMouseButtonDown(0)) {
            bulletSound.Play();
            Instantiate(bullet, transform.position, transform.rotation);
        }
        
    }
}
