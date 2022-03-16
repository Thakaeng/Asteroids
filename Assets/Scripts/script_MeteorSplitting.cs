using UnityEngine;

public class script_MeteorSplitting : MonoBehaviour
{
    [SerializeField] private GameObject smallerMeteor;
    [SerializeField] private int smallerMeteorSpawnCount = 2;

    private int[] spawnIndexes;
    private Vector2[] spawnPositions = new[]
    {
        new Vector2(-1f, 1f), 
        new Vector2(0f, 1f), 
        new Vector2(1f, 1f), 
        new Vector2(1f, 0f), 
        new Vector2(1f, -1f), 
        new Vector2(0f, -1f), 
        new Vector2(-1f, -1f), 
        new Vector2(-1f, 0f)
    };

    private void Start()
    {
        spawnIndexes = new int[smallerMeteorSpawnCount];
    }
    
    public void Split()
    {
        // Particles or something
        Destroy(gameObject);
        if (smallerMeteor == null) return;
        
        for (int i = 0; i < spawnIndexes.Length; i++)
        {
            int spawnIndex = GetSpawnIndex(i);
            var newMeteor = Instantiate(smallerMeteor, transform.position + (Vector3)spawnPositions[i], Quaternion.identity);
            newMeteor.GetComponent<script_MeteorMovement>().Setup(spawnPositions[spawnIndex]);

            spawnIndexes[i] = spawnIndex;
        }
    }

    private int GetSpawnIndex(int i)
    {
        int spawnIndex = Random.Range(0, spawnPositions.Length);
        if (spawnIndexes[i] > 0) spawnIndex = GetSpawnIndex(i);
        
        return spawnIndex;
    }
}
