using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsControllerScript : MonoBehaviour
{
    public Vector3 fpsPosition;
    public float distance;
    public List<GameObject> enemies = new List<GameObject>();
    public Text distanceRepresenter;
    public bool instantiateEnemyFlag = false;

    void Start()
    {
        if (instantiateEnemyFlag)
        {
            EnemyGeneratorScript enem = FindObjectOfType<EnemyGeneratorScript>();
            enemies = enem.getEnemies();
        }
    }

    void Update()
    {
        fpsPosition = transform.position;
        bool anyEnemyClose = false;

        foreach (GameObject enemy in enemies)
        {
            distance = Vector3.Distance(enemy.transform.position, fpsPosition);

            if (distance < 5)
            {
                anyEnemyClose = true;
                
            }
        }

        if (anyEnemyClose)
        {
            distanceRepresenter.text = "Your distance from enemy is less. Your health is draining.";
            gunScript gs = FindObjectOfType<gunScript>();
            gs.healthCounter--;
        }
        else
        {
            distanceRepresenter.text = "Your distance is normal";
        }
    }


    
}
