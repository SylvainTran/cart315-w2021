using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
* Explode is a behaviour component of Trap. It should not contain
* its data but rather apply an effect in the game based on these.
*/
public class Explode : MonoBehaviour
{
    /**
    * Reference to the trap component data to use. Scriptable object.
    */
    [SerializeField] private Trap trap;
    public Trap Trap { get { return trap; } set { trap = value; } }

    /**
    * Gets the reference to the trap component data.
    */
    public void Start() 
    {

    }
    /**
    * ApplyExplode: To be refactored in inheritance chain of the Trap class.
    */
    public void ApplyExplode()
    {
        Debug.Log("Exploding trap.");
        GetComponent<AudioSource>().Play();
        GameObject explosion = Instantiate(trap.explosionPrefab);
        explosion.transform.SetParent(this.transform);
        explosion.transform.position = this.transform.position;
        StartCoroutine(RemoveExplosion(1.5f));
    }
    /**
    * Removes the trap object after exploding.
    */
    private IEnumerator RemoveExplosion(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
    /**
    * To be refactored with UI event showing text damage.
    */
    public void ShowTextDamage(GameObject m)
    {
        Debug.Log(trap.textDamage + " " + trap.TrapDamage + " !");
        GameObject t = Instantiate(trap.textDamagePrefab);
        t.transform.SetParent(m.transform);
        t.transform.position = m.transform.position;
        t.GetComponent<TextMesh>().text = trap.textDamage + " " + trap.TrapDamage + " damage inflicted.";
    }
    /**
    * Disable the AI components that use a navmesh agent
    * because the object will be physically blown up apart from it so it will 
    * throw an error if we keep the navmesh agent.
    */
    public void InfluenceEnemyRigidbody(GameObject m)
    {
        if(m.GetComponent<MonsterAI>())
        {
            m.GetComponent<MonsterAI>().enabled = false;
        } else if(m.GetComponent<FollowerAI>())
        {
            m.GetComponent<FollowerAI>().enabled = false;
        }
        m.GetComponent<NavMeshAgent>().enabled = false;
        m.GetComponent<Rigidbody>().useGravity = false;
        m.GetComponent<Rigidbody>().isKinematic = false;
        // Debug.Log("Boom");
        m.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * trap.TrapEffectRadius);
    }
    /**
    * Restores the AI component after a while if 
    * the combatant has survived the trap's effects.
    */
    private IEnumerator RestoreAIComponent(GameObject m, float delay) 
    {
        yield return new WaitForSeconds(delay);
        if(m == null || !m.GetComponent<Combatant>().Alive) {
            yield break;
        }
        Debug.Log("Falling back down with gravity");
        m.GetComponent<Rigidbody>().useGravity = true;
        m.GetComponent<NavMeshAgent>().enabled = true;
        if(m.GetComponent<MonsterAI>())
        {
            m.GetComponent<MonsterAI>().enabled = true;
        } else if(m.GetComponent<FollowerAI>())
        {
            m.GetComponent<FollowerAI>().enabled = true;
        }
    }

    /**
    * Damage the enemy according to their combatant
    * stats.
    */
    public void DamageEnemy(GameObject m)
    {
        m.GetComponent<Combatant>().TakeDamage(trap.TrapDamage);
    }
    /**
    * Handles collider events to trigger the explosion
    * sequence for accepted gameobject tag owners.
    */
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Monster") || collider.CompareTag("Follower"))
        {
            // Blow-up
            ApplyExplode();
            InfluenceEnemyRigidbody(collider.gameObject);
            StartCoroutine(RestoreAIComponent(collider.gameObject, 1.5f));
            DamageEnemy(collider.gameObject);
            ShowTextDamage(collider.gameObject); // To be refactored into ui events
        }
    }
}
