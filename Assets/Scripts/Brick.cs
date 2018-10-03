using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int health = 0;
    public Material[] healthMaterials = new Material[4];
    public Renderer m_CurrentRenderer = null;

    private void OnCollisionEnter(Collision iCollision)
    {
        if(iCollision.gameObject.CompareTag("Ball"))
        {
            health--;
        }
    }

    private void TakeDamage(int iNbDamage = 1)
    {
        health -= iNbDamage;
        if(health == 0)
        {
            Destroy(gameObject);
        }

        m_CurrentRenderer.material = healthMaterials[health - 1];
    }
}
