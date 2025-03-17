using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public Transform FireSpot;
    private int power = 100;
    RaycastHit BulletRay;
    private ToggleGrab toggleGrab;

    public InputActionReference fireAction;
    [SerializeField]
    private GameObject m_FireEffect;
    [SerializeField]
    private GameObject m_HurtEffect;

    // Start is called before the first frame update
    void Start()
    {
        fireAction.action.performed += Shoot;
        toggleGrab = GetComponent<ToggleGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Shoot();
            //Debug.Log(test);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (toggleGrab != null && toggleGrab.m_CurrentGrabState == true)
        {
            //Debug.DrawRay(FireSpot.position, FireSpot.forward, Color.red, 2);
            Debug.Log("shooting");
            ShowEffectGun();

            if (Physics.Raycast(FireSpot.position, FireSpot.forward, out BulletRay, Mathf.Infinity))
            {
                if (BulletRay.collider.GetComponent<Damageable>() == null)
                {
                    return;
                }
                BulletRay.collider.GetComponent<ZombieController>().Hit(power);
                GameObject blood = Instantiate(m_HurtEffect);
                blood.transform.position = BulletRay.point;
                Destroy(blood, 0.5f);
            }
        }        
    }

    private void ShowEffectGun()
    {
        m_FireEffect.transform.position = FireSpot.position;
        m_FireEffect.transform.rotation = FireSpot.rotation;  // 改变朝向的话需要四元数和欧拉角之间的转换
        GameObject Fire = Instantiate(m_FireEffect);
        Destroy(Fire, 1.5f);
    }
}
