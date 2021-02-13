using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* The definition of traps down the inheritance chain do not contain
* behaviours, only data specifics. Explode() is a component class with behaviour
* that uses trap data. Uses the scriptable object interface for Monobehaviour access.
*/
[CreateAssetMenu(fileName = "Trap", menuName = "Gameplay/Trap", order = 1)]
public class Trap : ScriptableObject  
{
    /**
    * Used for equality checks by consumers like
    * PlaceTrap(). We need to know if a certain trap type exists
    * in the inventory. The trap ID is defined for each trap type to
    * allow checking its type.
    */
    private int trapID = 1;
    public int TrapID { get { return trapID; } }

    [Header("Gameplay Design Parameters")]
    [SerializeField] private float trapDamage = 10.0f;
    public float TrapDamage { get { return trapDamage; } set { trapDamage = value; } }
    [SerializeField] private float trapEffectRadius = 10.0f;
    public float TrapEffectRadius { get { return trapEffectRadius; } set { trapEffectRadius = value; } }
    [SerializeField] private int sizeInInventory = 1;
    public int SizeInInventory { get { return sizeInInventory; } }

    /**
    * Explosion force settings if applicable.
    */ 
    [Header("Physics Parameters")]
    [SerializeField] private Vector3 explosionForceVector;
    public Vector3 ExplosionForceVector { get { return explosionForceVector;} set {explosionForceVector = value; } }

    /**
    * Instantiation related.
    */
    [Header("Prefabs for Instantiation and FX")]
    public GameObject explosionPrefab;
    public AudioClip explosionSoundFX;
    public GameObject textDamagePrefab;
    public string textDamage;

    /**
    * Default constructor. Initialization is done via
    * the inspector since this is a scriptable object,
    * but can be used for private details later.
    */
    public Trap() 
    {

    }

    public override bool Equals(System.Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Trap p = (Trap)obj;
            return (TrapID == p.TrapID);
        }
    }
}
