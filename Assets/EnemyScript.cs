using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fps;
    public AudioSource bulletHit;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isDEad", false);
        
    }  
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(fps.transform);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Sphere")) {
            anim.SetBool("isDEad", true);
        }
        bulletHit.Play();

        //Destroy(collision.gameObject);
    }

    public void die (){
        bulletHit.Play();
        anim.SetBool("isDEad", true);
        gunScript gs = FindObjectOfType<gunScript>();
        gs.scoreIcreser();
    }
}
