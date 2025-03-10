using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class ToggleGrab : XRGrabInteractable
{
    public bool m_CurrentGrabState { get; private set; } = false;  //外部只读，内部可读可写
    private IXRSelectInteractor m_CurrentController;
    private Transform m_OriginalParent;
    private Rigidbody m_Rigidbody2;
    [SerializeField]
    private bool m_DelayedBoom = false;
    [SerializeField]
    private float m_DelayedBoomTime = 2.0f;
    private AudioSource m_AudioSource;

    protected override void Awake()
    {
        base.Awake();
        m_OriginalParent = transform.parent;
        m_Rigidbody2 = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        m_CurrentGrabState = !m_CurrentGrabState;
        m_CurrentController = args.interactorObject;
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        if (m_CurrentGrabState)
        {
            AttachToController();
        }
        else
        {
            DetachFromController();
        }
    }

    private void AttachToController()
    {
        transform.SetParent(m_CurrentController.transform);
        if (m_Rigidbody2 != null)
        {
            m_Rigidbody2.isKinematic = true;
        }
    }

    private void DetachFromController()
    {
        transform.SetParent(m_OriginalParent);
        if (m_Rigidbody2 != null)
        {
            m_Rigidbody2.isKinematic = false;
        }
        if (m_DelayedBoom)
        {
            StartCoroutine(Boom());
        }
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(m_DelayedBoomTime);  // 等待一段时间再执行接下来的操作
        Debug.Log("boom!!!");
        m_AudioSource.Play();
    }
}
