using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Explode : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explosionSoundFX;
    public GameObject textDamagePrefab;
    public string textDamage;
    public float explosionForce = 10.0f;
    public float trapDamage = 10.0f;
    public Vector3 explosionForceVector;

    public void ApplyExplode()
    {
        Debug.Log("Exploding trap.");
        GetComponent<AudioSource>().Play();
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.SetParent(this.transform);
        explosion.transform.position = this.transform.position;
        StartCoroutine(RemoveExplosion(1.5f));
    }

    private IEnumerator RemoveExplosion(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }

    public void ShowTextDamage(GameObject m)
    {
        Debug.Log("Showing text damage: " + textDamage + " " + trapDamage + " !");
        GameObject t = Instantiate(textDamagePrefab);
        t.transform.SetParent(m.transform);
        t.transform.position = m.transform.position;
        t.GetComponent<TextMesh>().text = textDamage + " " + trapDamage + " !";
    }

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
        m.GetComponent<Rigidbody>().AddRelativeForce(explosionForceVector * explosionForce);
    }

    public void DamageEnemy(GameObject m)
    {
        m.GetComponent<Combatant>().TakeDamage(explosionForce * trapDamage);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Monster") || collider.CompareTag("Follower"))
        {
            // Blow-up
            ApplyExplode();
            InfluenceEnemyRigidbody(collider.gameObject);
            DamageEnemy(collider.gameObject);
            ShowTextDamage(collider.gameObject);
        }
    }
}
