using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tiles : MonoBehaviour
{
    private float threshold = -10.0f; // 设置边界阈值
    private TextMeshProUGUI textMeshPro;
    public int number = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        SetNumber(number);
        
        transform.position += new Vector3(0, -GM.instance.speedControl * Time.deltaTime, 0);

        if (transform.position.y < threshold)
        {
            Destroy(gameObject); // 销毁超出边界的游戏对象
        }
    }

    public void SetNumber(int number)
    {
        textMeshPro.text = number.ToString();
    }
}
