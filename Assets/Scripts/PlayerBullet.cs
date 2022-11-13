using UnityEngine;
public class PlayerBullet : MonoBehaviour
    
{
    
    public float speed = 7.5f;
    public Rigidbody2D theRB;
    public int damageToGive = 15;

    void Start()
    {

    }


    void Update()
    {
        theRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
            Destroy(gameObject);
        }
        
    }
}
