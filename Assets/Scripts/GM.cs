using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM instance; // 创建一个静态实例，以便在其他脚本中访问
    public GameObject tilesPrefab; // 方块预制体

    // 方块生成
    public float speedControl = 1.0f; //方块的下落速度 
    public float spawnInterval = 1.0f; //生成间隔
    private float timeSinceLastSpawn; // 跟踪上次生成时间
    public Vector2[] spawnPositions; // 生成位置

    // 方块不同属性
    public int maxNum = 10; // 可以设置的最大数字
    private int index2;



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

    void Start()
    {
        timeSinceLastSpawn = 0;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // 当达到间隔时间时生成方块
        if (timeSinceLastSpawn >= spawnInterval)
        {
            List<int> numbers = GenerateNumbers();
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

    public List<int> GenerateNumbers()
    {
        int num1 = UnityEngine.Random.Range(1, maxNum + 1);
        int num2 = UnityEngine.Random.Range(1, maxNum + 1);
        while (num1 == num2)
        {
            num2 = UnityEngine.Random.Range(1, maxNum + 1);
        }

        index2 = UnityEngine.Random.Range(0, 4);
        List<int> nums = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            nums.Add(i != index2 ? num1 : num2);
        }
        
        // check
        // string numsString = string.Join(", ", nums);
        // Debug.Log(numsString);

        return nums;
    }


}
