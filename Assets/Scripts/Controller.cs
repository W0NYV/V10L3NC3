using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Controller : MonoBehaviour {

    PlayerInput _input;

    public GameObject bpmSyncer;
    public GameObject cube;
    public GameObject camera;
    
    private Material mat;

    private void Awake() {

        TryGetComponent(out _input);
        
    }

    private void Start() {

        mat = camera.GetComponent<CameraFilter>().mat;
        mat.SetColor("_Col", new Color(0.0f, 0.0f, 1.0f, 1.0f));
    }
  
    private void OnEnable() {
        _input.actions["BPMSync"].performed += onBPMSync;

        _input.actions["ShakePosition"].performed += onShakePosition;
        _input.actions["TranslateUp"].performed += onTranslateUp;
        _input.actions["TranslateDown"].performed += onTranslateDown;
        _input.actions["TranslateRight"].performed += onTranslateRight;
        _input.actions["TranslateLeft"].performed += onTranslateLeft;

    }

    private void OnDisable() {
        _input.actions["BPMSync"].performed -= onBPMSync;
        
        _input.actions["ShakePosition"].performed -= onShakePosition;
        _input.actions["TranslateUp"].performed -= onTranslateUp;
        _input.actions["TranslateDown"].performed -= onTranslateDown;
        _input.actions["TranslateRight"].performed -= onTranslateRight;
        _input.actions["TranslateLeft"].performed -= onTranslateLeft;

    }

    //-----------------------------------------------------------------
    //-----------------------------------------------------------------
    private void onShakePosition(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, Vector3.zero, Quaternion.identity);
            Object3DTransformer.ShakePosition(o);
        };
    }

    private void onBPMSync(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            if(bpmSyncer.activeSelf) {
                BPMSyncer.ResetTime();
            } else {
                bpmSyncer.SetActive(true);
                BPMSyncer.ResetTime();
            }
        }
    }

    private void onTranslateUp(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateUp(o);
        }
    }

    private void onTranslateDown(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateDown(o);
        }
    }

    private void onTranslateRight(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, new Vector3(-1.666666f, 0.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateRight(o);
        }
    }
    
    private void onTranslateLeft(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, new Vector3(1.666666f, 0.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateLeft(o);
        }
    }

}
