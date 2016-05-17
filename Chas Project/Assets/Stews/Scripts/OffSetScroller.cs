using UnityEngine;
using System.Collections;

public class OffSetScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;

    private Renderer ownedRenderer;
	// Use this for initialization
	void Start () {
        ownedRenderer = GetComponent<Renderer>();
        savedOffset = ownedRenderer.sharedMaterial.GetTextureOffset("_MainTex");
    }
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, 0);
        ownedRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);	
	}
    void OnDisable() {
        ownedRenderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
