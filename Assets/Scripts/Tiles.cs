using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public float threshold = -10.0f; // 设置边界阈值

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -GM.instance.speedControl * Time.deltaTime, 0);

        if (transform.position.y < threshold)
        {
            Destroy(gameObject); // 销毁超出边界的游戏对象
        }
    }
}
