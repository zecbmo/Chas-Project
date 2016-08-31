using System;
using UnityEngine;

[Serializable]
public class WaterInfo : MonoBehaviour {
    [SerializeField]
    private Transform waterLevel;
    [SerializeField]
    private Transform waterBed;
    [SerializeField]
    private float waterHeight;

    public void Awake() {
        waterHeight = (waterBed.transform.position - waterLevel.transform.position).magnitude;
    }
#if UNITY_EDITOR
    public void Update() {
        waterHeight = (waterBed.transform.position - waterLevel.transform.position).magnitude;

    }
#endif
}
