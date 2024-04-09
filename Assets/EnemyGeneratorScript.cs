using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject Clown;
    public Vector3 position;
    public Vector3 position2;
    public static bool level1Flag = false;
    
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            position = new Vector3(Random.Range(227, 553), 0, Random.Range(218, 571));
            GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
            enemies.Add(newEnemy);
            position2 = new Vector3(Random.Range(227, 553), 0, Random.Range(218, 571));
            GameObject newClown = Instantiate(Clown, position, Quaternion.identity);
            enemies.Add(newClown);

        }
        FpsControllerScript fcs = FindObjectOfType<FpsControllerScript>();
        fcs.instantiateEnemyFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public List<GameObject> getEnemies() {

        return enemies;
    }
}
