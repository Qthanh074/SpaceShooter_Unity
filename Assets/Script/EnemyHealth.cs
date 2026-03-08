using UnityEngine;

public class EnemyHealth : Health // Bắt buộc phải kế thừa từ Health
{
    // MỚI THÊM: Biến static (tĩnh) dùng chung cho TẤT CẢ kẻ địch để đếm tổng số lượng
    public static int livingEnemyCount = 0;

    // MỚI THÊM: Hàm này tự động chạy khi kẻ địch được sinh ra / bật lên trong game
    private void OnEnable()
    {
        livingEnemyCount++; // Cộng 1 vào tổng số kẻ địch
    }

    // MỚI THÊM: Ghi đè (override) hàm Die() của script Health gốc
    protected override void Die()
    {
        livingEnemyCount--; // Trừ 1 khi kẻ địch chết
        
        // Vẫn phải gọi base.Die() để mượn hiệu ứng nổ và xóa object của script Health cũ
        base.Die(); 
    }
}