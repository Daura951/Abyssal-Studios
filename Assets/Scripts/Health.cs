using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth;
    private bool dead;

    [SerializeField] private float iFrames;
    [SerializeField] private int flash;
    private SpriteRenderer sprites;

    private Animator Anim;

    private void Awake()
    {
        currentHealth = startHealth;
        Anim = GetComponent<Animator>();
        sprites = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth =Mathf.Clamp(currentHealth -= _damage, 0, startHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(noTouchie());
        }
        else
        {
            if (gameObject.tag == "Enemy" || gameObject.tag == "Boss")
            {
                Destroy(gameObject); 
                
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

    private IEnumerator noTouchie()
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        Physics2D.IgnoreLayerCollision(3, 13, true);
        for (int i=0; i < flash; i++)
        {
            sprites.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrames / (flash * 2));
            sprites.color = Color.white;
            yield return new WaitForSeconds(iFrames / (flash * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 8, false);
        Physics2D.IgnoreLayerCollision(3, 13, false);

    }
}
