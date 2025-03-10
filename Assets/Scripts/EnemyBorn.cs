using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorn : MonoBehaviour
{
    private int power = 500;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Hitting = GameObject.FindGameObjectsWithTag("enemy");
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instantiate(zombie);
            zombie.transform.position = this.transform.position;
        }

        foreach (GameObject target in Hitting)
        {            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                target.GetComponent<ZombieController>().Hit(power);
            }
        }        
    }
}
