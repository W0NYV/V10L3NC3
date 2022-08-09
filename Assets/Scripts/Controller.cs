using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Controller : MonoBehaviour {

    public GameObject bpmSyncer;
    public GameObject cube;

    // Update is called once per frame
    void Update() {
            
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            GameObject o = Instantiate(cube, Vector3.zero, Quaternion.identity);
            Object3DTransformer.ShakePosition(o);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame) {
            GameObject o = Instantiate(cube, new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateUp(o);
        }

        if (Keyboard.current.sKey.wasPressedThisFrame) {
            GameObject o = Instantiate(cube, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateDown(o);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame) {
            GameObject o = Instantiate(cube, new Vector3(-1.666666f, 0.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateRight(o);
        }

        if (Keyboard.current.fKey.wasPressedThisFrame) {
            GameObject o = Instantiate(cube, new Vector3(1.666666f, 0.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateLeft(o);
        }

        if (Keyboard.current.vKey.wasPressedThisFrame) {
            if(bpmSyncer.activeSelf) {
                BPMSyncer.ResetTime();
            } else {
                bpmSyncer.SetActive(true);
                BPMSyncer.ResetTime();
            }
        }
        
    }

}
