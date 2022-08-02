using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrenadeScript : MonoBehaviour
{
    public float delay = 3f;
    float countdown = 0f;
    public GameObject explosionPrefab;
    public bool hasExploded = false;
    public float blastRadius = 2f;
    public float bombDamage = 10f;
    private void Start()
    {
        countdown = delay;
    }
    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
    public void Explode()
    {
        PhotonNetwork.Instantiate(explosionPrefab.name, this.transform.position, Quaternion.identity);
        AudioManager.instance.ExplosionSound();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);
        
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.tag == "Player1")
            {
                collider.gameObject.GetComponent<PlayerCombat>().TakeDamage(bombDamage);
            } 
            if(collider.gameObject.tag == "Player2")
            {
                collider.gameObject.GetComponent<PlayerCombat>().TakeDamage(bombDamage);
            }
        }
        Destroy(this.gameObject);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, blastRadius);
    //}
}
