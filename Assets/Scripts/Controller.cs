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
    
    private CameraFilter[] cameraFilter;

    private Material m_pixelate;
    private CameraFilter c_pixelate;

    private Material m_reflectTile;
    private CameraFilter c_reflectTile;

    private Material m_rgbScale;
    private CameraFilter c_rgbScale;

    private void Awake() {

        TryGetComponent(out _input);
        
    }

    private void Start() {

        cameraFilter = camera.GetComponents<CameraFilter>();

        c_pixelate = cameraFilter[0];
        m_pixelate = c_pixelate.mat;

        c_reflectTile = cameraFilter[1];
        m_reflectTile = c_reflectTile.mat;

        c_rgbScale = cameraFilter[2];
        m_rgbScale = c_rgbScale.mat;
    }
  
    private void OnEnable() {
        _input.actions["BPMSync"].performed += onBPMSync;

        _input.actions["TranslateUp"].performed += onTranslateUp;
        _input.actions["TranslateDown"].performed += onTranslateDown;
        _input.actions["TranslateRight"].performed += onTranslateRight;
        _input.actions["TranslateLeft"].performed += onTranslateLeft;
        _input.actions["RotateY"].performed += onRotateY;

        _input.actions["ShakePosition"].performed += onShakePosition;
        _input.actions["ScaleRotate4"].performed += onScaleRotate4;
        _input.actions["ShakeSize"].performed += onShakeSize;

        _input.actions["PPPixelate"].performed += onPPPixelate;
        _input.actions["PPReflectTile"].performed += onPPReflectTile;
        _input.actions["PPRGBScale"].performed += onPPRGBScale;

        _input.actions["CameraShake"].performed += onCameraShake;
    }

    private void OnDisable() {
        _input.actions["BPMSync"].performed -= onBPMSync;
        
        _input.actions["TranslateUp"].performed -= onTranslateUp;
        _input.actions["TranslateDown"].performed -= onTranslateDown;
        _input.actions["TranslateRight"].performed -= onTranslateRight;
        _input.actions["TranslateLeft"].performed -= onTranslateLeft;
        _input.actions["RotateY"].performed -= onRotateY;

        _input.actions["ShakePosition"].performed -= onShakePosition;
        _input.actions["ScaleRotate4"].performed -= onScaleRotate4;
        _input.actions["ShakeSize"].performed -= onShakeSize;

        _input.actions["PPPixelate"].performed -= onPPPixelate;
        _input.actions["PPReflectTile"].performed -= onPPReflectTile;
        _input.actions["PPRGBScale"].performed -= onPPRGBScale;

        _input.actions["CameraShake"].performed -= onCameraShake;
    }

    //-----------------------------------------------------------------
    //-----------------------------------------------------------------
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


    private void onShakePosition(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, Vector3.zero, Quaternion.identity);
            Object3DTransformer.ShakePosition(o);
        }
    }

    private void onScaleRotate4(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, new Vector3(1.5f, 0, 0), Quaternion.identity);
            o.transform.localScale = Vector3.zero;
            Object3DTransformer.ScaleRotate4(o);
        }
    }

    private void onShakeSize(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, new Vector3(0, 0, 1.5f), Quaternion.identity);
            Object3DTransformer.ShakeSize(o);
        }
    }

    private void onRotateY(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            GameObject o = Instantiate(cube, new Vector3(0, 0, 1.5f), Quaternion.identity);
            Object3DTransformer.RotateY(o);        
        }
    }


    private void onPPPixelate(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            c_pixelate.enabled = !c_pixelate.isActiveAndEnabled;
            if(c_pixelate.isActiveAndEnabled) m_pixelate.SetFloat("_BPM", BPMSyncer.BPM);
        }
    }

    private void onPPReflectTile(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            c_reflectTile.enabled = !c_reflectTile.isActiveAndEnabled;
        }
    }

    private void onPPRGBScale(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            c_rgbScale.enabled = !c_rgbScale.isActiveAndEnabled;
            if(c_rgbScale.isActiveAndEnabled) m_rgbScale.SetFloat("_BPM", BPMSyncer.BPM);
        }
    }


    private void onCameraShake(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() == 1) {
            Object3DTransformer.ShakeCamera(camera);
        }
    }

}
