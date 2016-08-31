using UnityEngine;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(RectTransform))]
public class StageSetup : MonoBehaviour {
    [Header("Stage Borders")]
    [SerializeField]
    private GameObject topTrim;
    [SerializeField]
    private GameObject stageFloor;
    [SerializeField]
    private GameObject curtainSide;    

    [SerializeField]
    int tileDuplication = 2;

    private GameObject parentTopTrim;
    private GameObject parentStageFloor;
    private GameObject curtainLeft;
    private GameObject curtainRight;

    bool stageCreated = false;
    void Awake() {
        AlignStage();
    }

    public void OnRectTransformDimensionsChange() {
        AlignStage();
    }
    // Create the stage if its doesnt exist, otherwise realigns it to correct coordinates.
    void AlignStage() {
        if (!stageCreated) {
            CreateStage();
        } else {
            ReAlignStage();
        }
    }

    void CreateStage() {
        if (topTrim != null) {
            parentTopTrim = Instantiate(topTrim, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            DuplicateSpriteHorz(parentTopTrim, tileDuplication);
        }
        if (stageFloor != null) {
            parentStageFloor = Instantiate(stageFloor, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            DuplicateSpriteHorz(parentStageFloor, tileDuplication);
        }
        if (curtainSide != null) {
            curtainLeft = Instantiate(curtainSide, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
        if (curtainSide != null) {
            curtainRight = Instantiate(curtainSide, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            curtainRight.GetComponent<SpriteRenderer>().flipX = true;
        }
        stageCreated = true;
        ReAlignStage();
    }

    void DuplicateSpriteHorz(GameObject parent, int duplicates) {
        GameObject child = parent;
        for (int i = 0; i < duplicates; i++) {
            child = Instantiate(child, child.transform.position, Quaternion.identity) as GameObject;
            Vector3 alignedPoint = child.transform.position;
            alignedPoint.x += child.GetComponent<SpriteRenderer>().bounds.size.x;
            child.transform.position = alignedPoint;
            child.transform.parent = parent.transform;
        }
    }

    void ReAlignStage() {
        if (Camera.main) {
            if (parentTopTrim) {
                Vector3 alignedPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 1));
                alignedPoint.y -= parentTopTrim.GetComponent<SpriteRenderer>().bounds.size.y / 2;
                alignedPoint.x += parentTopTrim.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                parentTopTrim.transform.position = alignedPoint;
            }
            if (parentStageFloor) {
                Vector3 alignedPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1));
                alignedPoint.y += parentStageFloor.GetComponent<SpriteRenderer>().bounds.size.y / 2;
                alignedPoint.x += parentStageFloor.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                parentStageFloor.transform.position = alignedPoint;
            }
            if (curtainLeft) {
                Vector3 alignedPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 1));
                alignedPoint.x += curtainLeft.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                curtainLeft.transform.position = alignedPoint;
            }
            if (curtainRight) {
                Vector3 alignedPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 1));
                alignedPoint.x -= curtainRight.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                curtainRight.transform.position = alignedPoint;
            }
        }
    }

    public void OnValidate() {
        //GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;        
    }
}
