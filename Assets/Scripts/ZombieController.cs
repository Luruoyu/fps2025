using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Dead();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hurt"></param>
    public void Hit(int hurt)
    {
        HP -= hurt;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Dead()
    {
        Destroy(this.gameObject);
    }
}
