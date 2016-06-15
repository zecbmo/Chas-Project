using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveItObstacleSpawner : MonoBehaviour {

    [Tooltip("Speed obstacles move at.")]
    public float ObstacleSpeed = 20.0f;

    public List<MoveItObstacle> spawnableObstacles = new List<MoveItObstacle>();

    private MoveItObstacle currentObstacle = null;
    private MoveItObstacle nextObstacle = null;
    private float totalWeight = 0;
    // Use this for initialization
    void Start() {
        totalWeight = GetListTotalWeight();
    }

    // Update is called once per frame
    void Update() {
        if (currentObstacle == null) {
            SpawnObstacle(GetObstacle());
            nextObstacle = GetObstacle();
        } else {
            float distance = Vector3.Distance(currentObstacle.transform.position, transform.position);
            float requiredDistance = currentObstacle.GetComponent<MoveItObstacle>().SeperationHorizontal + nextObstacle.GetComponent<MoveItObstacle>().SeperationHorizontal;
            if (distance > requiredDistance) {
                SpawnObstacle(nextObstacle);
                nextObstacle = GetObstacle();
            }
        }
    }

    MoveItObstacle GetObstacle() {
        MoveItObstacle newObstacle = null;
        float randomNumber = Random.Range(0.0f, totalWeight);

        foreach (MoveItObstacle obstacle in spawnableObstacles) {
            // find the 
            if (randomNumber < obstacle.Weight) {
                newObstacle = obstacle;
                break;
            }
            randomNumber -= obstacle.Weight;

        }
        return newObstacle;
    }

    float GetListTotalWeight() {
        float total = 0.0f;
        foreach (MoveItObstacle obstacle in spawnableObstacles) {
            total += obstacle.Weight;
        }
        return total;
    }

    void SpawnObstacle(MoveItObstacle newObstacle) {        
        currentObstacle = Instantiate(newObstacle, transform.position, Quaternion.identity) as MoveItObstacle;        
    }
}
