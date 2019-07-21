using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour {

    public float WF_speed = 0.75f;

    public Renderer WF_renderer;

    void Start() {
        WF_renderer = GetComponent<Renderer>();
    }

    void Update() {

        float TextureOffset = Time.time * WF_speed;
        WF_renderer.material.SetTextureOffset("_MainTex", new Vector2(0, TextureOffset));
    }
}

