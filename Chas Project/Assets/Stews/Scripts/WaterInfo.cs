using System;
using UnityEngine;

[Serializable]
public class WaterInfo : MonoBehaviour {
    [SerializeField]
    private Transform waterLevel;
    [SerializeField]
    private Transform waterBed;
    
    private float waterHeight;

    public float WaterLevel { get { return waterLevel.transform.position.y; } }
    public float WaterHeight { get { return waterHeight; } }

    public void CalculateWaterHeight() {
        waterHeight = (waterBed.transform.position - waterLevel.transform.position).magnitude;
    }
    public void Awake() {
        CalculateWaterHeight();
    }
#if UNITY_EDITOR
    public void Update() {
        CalculateWaterHeight();
    }

    public void OnValidate() {
        CalculateWaterHeight();
    }
#endif

}
