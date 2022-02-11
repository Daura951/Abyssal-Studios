using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    private float currentHealth;
    private bool dead;

    private void Awake()
    {
        currentHealth = startHealth; 
    }

    public void TakeDamage(float _damage)
    {
        currentHealth =Mathf.Clamp(currentHealth -= _damage, 0, startHealth);
        if (currentHealth > 0)
        {

        }
        else
        {
            //Replace with player respawn later -V
            if (gameObject.tag == "Enemy")
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            

           
        }
    }
}
