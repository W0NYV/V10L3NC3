using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Controller : MonoBehaviour {

    public GameObject cube;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
            
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            GameObject o = Instantiate(cube, Vector3.zero, Quaternion.identity);
            Object3DTransformer o3d = o.GetComponent<Object3DTransformer>();
            o3d.action = () => o3d.ShakePosition();
            o.SetActive(true);
        }

        if (Keyboard.current.vKey.wasPressedThisFrame) {
            BPMSyncer.ResetTime();
        }
        
    }
}
