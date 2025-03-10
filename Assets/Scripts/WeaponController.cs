using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public Transform FireSpot;
    private int power = 500;
    RaycastHit BulletRay;
    private ToggleGrab toggleGrab;

    public InputActionReference fireAction;

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

            if (Physics.Raycast(FireSpot.position, FireSpot.forward, out BulletRay, Mathf.Infinity))
            {
                if (BulletRay.collider.GetComponent<Damageable>() == null)
                {
                    return;
                }
                BulletRay.collider.GetComponent<ZombieController>().Hit(power);
            }
        }        
    }
}
