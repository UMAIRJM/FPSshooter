using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gunScript : MonoBehaviour
{
    public GameObject fpscam;
    private float range = 5000;
    public GameObject explosions;
    public AudioSource bulletSound;
    public int bulletCounter = 30;
    public Text bullets;
    public Text outOfAmmo;
    public bool outofBullets = false;
    public Text health;
    public int healthCounter = 100;
    public Text yourScore;
    public int scoreCounter;
    public int extraBulletCounter;
    public Text checkpointText;
    public Text level;
    public int levelCounter = 1;
    public Text levelInstruction;
    public bool checkpointerFlag = false;
    //public GameObject extraBulletsObject;
    public GameObject extraBulletsObject;



    void Start()
    {
        level.text = "level : " + levelCounter.ToString();
        explosions.SetActive(false);
        bullets.text = "Bullets :" + bulletCounter.ToString();
        health.text = "Your health : " + healthCounter.ToString();
        yourScore.text = "Your Score : " + scoreCounter.ToString();



    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Your health : " + healthCounter.ToString();
        explosions.SetActive(false);
        if (bulletCounter == 0 || bulletCounter < 0) {
            outOfAmmo.text = "You are out  of Ammo";
            outofBullets = true;
         }

        if (outofBullets == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bulletCounter--;
                bullets.text = "Bullets :" + bulletCounter.ToString();
                explosions.SetActive(true);
                Instantiate(explosions, transform.position, transform.rotation);
                bulletSound.Play();
                shoot();
            }
        }
        if (healthCounter <= 0) {
            SceneManager.LoadScene("GameOverScene");
        }
        if (scoreCounter == 10) {
            checkpointerFlag = true;
            checkpointText.text = "You have completed level 1 go to checkpoint to reach level 2";
            
        }
    }


    public void shoot() {
        RaycastHit hit;
        
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range)) {
            
            if (hit.transform.tag == "enemy") {
                if (extraBulletCounter < 3) {
                    extraBulletCounter++;
                    Instantiate(extraBulletsObject, hit.transform.position, Quaternion.identity);

                }
                EnemyScript enem = hit.transform.GetComponent<EnemyScript>();
                enem.die();
                




            }
        }
    
    }

    public void scoreIcreser() {
        scoreCounter++;
        yourScore.text = "Your Score : " + scoreCounter.ToString();
        

    }


    public void bulletIncreaser(int incrementer) {
        outofBullets = false;
        bulletCounter = bulletCounter + incrementer;
        bullets.text = "Bullets :" + bulletCounter.ToString();
        outOfAmmo.text = "";


    }
    public void respawnFuntion() {
        levelInstruction.text = "Kill 15 enemies to complete level 2";
        levelCounter++;
        level.text = "level : " + levelCounter.ToString();
        bulletCounter = 30;
        bullets.text = "Bullets :" + bulletCounter.ToString();
        healthCounter = 100;
        health.text = "Your health : " + healthCounter.ToString();

    }



}
