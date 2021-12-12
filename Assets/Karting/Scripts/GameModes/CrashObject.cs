using UnityEngine;
using System.Collections;

/// <summary>
/// This class inherits from TargetObject and represents a CrashObject.
/// </summary>
public class CrashObject : TargetObject
{
    [Header("CrashObject")]
    [Tooltip("The VFX prefab spawned when the object is collected")]
    public ParticleSystem CollectVFX;

    [Tooltip("The position of the centerOfMass of this rigidbody")]
    public Vector3 centerOfMass;

    [Tooltip("Apply a force to the crash object to make it fly up onTrigger")]
    public float forceUpOnCollide;

    Rigidbody m_rigid;
    public AudioClip audioExplosion;
    public AudioSource audioExplosionSource;
    public GameObject playerObj = null;
    public TimeManager timeManager;

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_rigid.centerOfMass = centerOfMass;
        Register();
        audioExplosionSource.clip = audioExplosion;
        timeManager = FindObjectOfType<TimeManager>();

		if (playerObj == null)
			playerObj = GameObject.FindGameObjectWithTag("Player");

    }

    void OnCollect(Collider other)
    {
        active = false;
        if (CollectVFX)
            CollectVFX.Play();

        if (audioExplosionSource)
            audioExplosionSource.Play ();
               
        if (m_rigid) m_rigid.AddForce(forceUpOnCollide*Vector3.up, ForceMode.Impulse);

		// if(GetComponent<Collider>().tag == "Player") 
        //     playerObj.GetComponent<Rigidbody>().velocity = (transform.up * 100f);
        
        Objective.OnUnregisterPickup(this);

        timeManager.zeroTime();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;
        
        if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player"))
            OnCollect(other);
    }
    
}
