using UnityEngine;
using System; 

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    private int healthPoint;

    // 1. Khai báo sự kiện báo tử
    public event Action onDead;

    private void Start() => healthPoint = defaultHealthPoint;

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;
        healthPoint -= damage;
        if (healthPoint <= 0) Die();
    }

    protected virtual void Die()
    {
        // 2. Kích hoạt sự kiện ngay trước khi nổ. 
        // Dấu "?" để kiểm tra xem có ai đang "lắng nghe" sự kiện này không, nếu có thì mới gọi.
        onDead?.Invoke();

        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        
        // 3. Phá hủy Object
        Destroy(gameObject);
    }
}