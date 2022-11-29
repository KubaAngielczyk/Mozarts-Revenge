using UnityEngine;
public class PlayerBullet : MonoBehaviour
    
{
    
    public float speed = 7.5f;
    public Rigidbody2D theRB;
    public int damageToGive = 15;
    public GameObject impactEffect;

    void Start()
    {

    }


    void Update()
    {
        theRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
