using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth health;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerHealth = collision.GetComponent<PlayerHealth>();
        
        if (playerHealth != null)
        {
            // Trừ máu người chơi
            playerHealth.TakeDamage(damage);
            
            // THÊM KIỂM TRA: Chỉ tự sát nếu biến health không bị rỗng
            if (health != null)
            {
                health.TakeDamage(1000);
            }
        }
    }
}