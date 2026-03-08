using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [Tooltip("Tốc độ cuộn của nền. Số dương là cuộn lên, số âm là cuộn xuống")]
    public float scrollSpeed = 0.5f; 
    
    private Material bgMaterial;

    void Start()
    {
        // Lấy chất liệu (Material) của tấm nền
        bgMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Tính toán độ lệch (Offset) trượt theo trục Y (dọc)
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        
        // Áp dụng độ lệch này vào ảnh nền
        bgMaterial.mainTextureOffset = offset;
    }
}