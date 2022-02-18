using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (gameObject.tag == "Enemy")
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                if (gameObject.tag == "Player")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            

           
        }
    }
}
