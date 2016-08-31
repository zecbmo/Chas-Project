using UnityEngine;
using System.Collections.Generic;

public class MoveItObstacleSpawner : MonoBehaviour {

    public List<MoveItObstacle> spawnableObstacles = new List<MoveItObstacle>();

    private MoveItObstacle currentObstacle = null;
    private MoveItObstacle nextObstacle = null;
    private float totalWeight = 0;

    void Start() {
        totalWeight = GetListTotalWeight();
    }

    // Update is called once per frame
    void Update() {
        if (currentObstacle == null) {
            SpawnObstacle(GetObstacle());
            nextObstacle = GetObstacle();
        } else {
            float distance = transform.position.x - currentObstacle.transform.position.x;
            float requiredDistance = currentObstacle.GetComponent<MoveItObstacle>().SeperationHorizontal + nextObstacle.GetComponent<MoveItObstacle>().SeperationHorizontal;
            if (distance > requiredDistance) {
                SpawnObstacle(nextObstacle);
                nextObstacle = GetObstacle();
            }
        }
    }

    MoveItObstacle GetObstacle() {
        MoveItObstacle newObstacle = null;
        // random number, that lies within one objects weight value.
        float randomNumber = Random.Range(0.0f, totalWeight);

        // find the object with the matching weight
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

    // generate a total weight for all possible objects.
    float GetListTotalWeight() {
        float total = 0.0f;
        foreach (MoveItObstacle obstacle in spawnableObstacles) {
            total += obstacle.Weight;
        }
        return total;
    }
    
    void SpawnObstacle(MoveItObstacle newObstacle) {        
        // add random height offset                
        currentObstacle = Instantiate(newObstacle, transform.position + newObstacle.transform.position, Quaternion.identity) as MoveItObstacle;
    }
    
    void CreateScene() {
        // TODO: instantiate a full scene of objects so doesnt look barren? or just create start scene in editor?
    }
    
}
