using UnityEngine;

public class CreeperHealth : MonoBehaviour
{

    public int radius;
    public int damage;
    
    public void Explode()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            if (col.CompareTag("Player"))
            {
                if (col.TryGetComponent(out Health health)) {
                    health.OnBulletHit(damage);
                }
            } 
        }
        
        Destroy(gameObject);
        
    }
    
}