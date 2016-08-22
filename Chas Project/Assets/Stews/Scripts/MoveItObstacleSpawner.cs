using UnityEngine;
using System.Collections.Generic;

public class MoveItObstacleSpawner : MonoBehaviour {

    [Tooltip("Speed obstacles move at.")]
    public float ObstacleSpeed = 20.0f;
    [Tooltip("Maximum height difference of leading obstacle")]
    public float MaxVariation = 1;

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

    // position new obstacle in random position, based off obstacle parrameters, and previous obstacle parameters.
    // Instanstiate the object.
    void SpawnObstacle(MoveItObstacle newObstacle) {
        Vector3 newPos = transform.position;
        // add random height offset
        newPos.y += Random.Range(newObstacle.MinHeightVariation, newObstacle.MaxHeightVariation);
        if (currentObstacle) {
            if (newPos.y + MaxVariation > currentObstacle.transform.position.y) {
                // to big of difference between heights so cap it
                newPos.y = currentObstacle.transform.position.y + MaxVariation;
            }
        }
        currentObstacle = Instantiate(newObstacle, newPos, Quaternion.identity) as MoveItObstacle;
    }
    
    void CreateScene() {
        // TODO: instantiate a full scene of objects so doesnt look barren? or just create start scene in editor?
    }
    
}
