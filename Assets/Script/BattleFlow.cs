using UnityEngine;
using UnityEngine.SceneManagement; 

public class BattleFlow : MonoBehaviour
{
    [Header("Gắn các thành phần vào đây")]
    public Health playerHealth; 
    public GameObject gameOverUI; 
    
    // MỚI THÊM: Ô trống để kéo màn hình Win vào
    public GameObject gameWinUI; 

    // MỚI THÊM: Biến kiểm tra xem game đã kết thúc chưa (để tránh hiện cả Win lẫn Lose)
    private bool isGameEnded = false; 

    private void Start()
    {
        if (gameOverUI != null) gameOverUI.SetActive(false);
        if (gameWinUI != null) gameWinUI.SetActive(false); // Ẩn màn hình Win lúc mới chơi

        if (playerHealth != null)
        {
            playerHealth.onDead += OnGameOver;
        }
    }

    // MỚI THÊM: Liên tục kiểm tra điều kiện thắng
    private void Update()
    {
        // Nếu game CHƯA kết thúc VÀ số kẻ địch <= 0
        if (!isGameEnded && EnemyHealth.livingEnemyCount <= 0)
        {
            OnGameWin();
        }
    }

    private void OnGameOver()
    {
        if (isGameEnded) return; // Nếu game đã kết thúc rồi thì bỏ qua
        isGameEnded = true;      // Đánh dấu game đã kết thúc

        if (gameOverUI != null) gameOverUI.SetActive(true);
    }

    // MỚI THÊM: Hàm xử lý khi người chơi Thắng
    private void OnGameWin()
    {
        if (isGameEnded) return;
        isGameEnded = true;

        if (gameWinUI != null) gameWinUI.SetActive(true);
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.onDead -= OnGameOver;
        }
    }

    public void RestartGame()
    {
        // MỚI THÊM: Phải reset lại số đếm về 0 trước khi chơi lại, nếu không sẽ bị lỗi cộng dồn
        EnemyHealth.livingEnemyCount = 0; 
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}