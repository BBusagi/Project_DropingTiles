using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM instance; // 创建一个静态实例，以便在其他脚本中访问
    public GameObject tilesPrefab; // 方块预制体

    public float speedControl = 1.0f; //方块的下落速度 
    public float spawnInterval = 1.0f; //生成间隔
    private float timeSinceLastSpawn; // 跟踪上次生成时间
    public Vector2[] spawnPositions; // 生成位置



    void Awake()
    {
        // 确保只有一个GM实例
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // DontDestroyOnLoad(gameObject); // 可选：确保切换场景时不销毁GM
    }

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // 当达到间隔时间时生成方块
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnBlock();
            timeSinceLastSpawn = 0;
        }
    }

    void SpawnBlock()
    {
        // 实例化方块预制体
        foreach (Vector2 pos in spawnPositions)
        {
            Instantiate(tilesPrefab, pos, Quaternion.identity);
        }
    }

}
