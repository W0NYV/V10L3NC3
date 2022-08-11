using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Controller : MonoBehaviour {

    PlayerInput _input;

    public GameObject bpmSyncer;

    // public GameObject cube;
    // public GameObject quad;
    // public GameObject sphere;
    public GameObject[] objs;
    private GameObject currentObj;
    static public int objNum;

    public GameObject camera;
    
    private CameraFilter[] cameraFilter;

    private Material m_pixelate;
    private CameraFilter c_pixelate;

    private Material m_reflectTile;
    private CameraFilter c_reflectTile;

    private Material m_rgbScale;
    private CameraFilter c_rgbScale;

    private Material m_mandala;
    private CameraFilter c_mandala;

    private Material m_strobe;
    private CameraFilter c_strobe;

    private void Awake() {

        TryGetComponent(out _input);
        
    }

    private void Start() {

        currentObj = objs[0];

        cameraFilter = camera.GetComponents<CameraFilter>();

        c_pixelate = cameraFilter[0];
        m_pixelate = c_pixelate.mat;

        c_reflectTile = cameraFilter[1];
        m_reflectTile = c_reflectTile.mat;

        c_rgbScale = cameraFilter[2];
        m_rgbScale = c_rgbScale.mat;

        c_mandala = cameraFilter[3];
        m_mandala = c_mandala.mat;

        c_strobe = cameraFilter[4];
        m_strobe = c_strobe.mat;
    }
  
    private void OnEnable() {
        _input.actions["BPMSync"].performed += onBPMSync;
        _input.actions["SwitchObj"].performed += onSwitchObj;

        _input.actions["TranslateUp"].performed += onTranslateUp;
        _input.actions["TranslateDown"].performed += onTranslateDown;
        _input.actions["TranslateRight"].performed += onTranslateRight;
        _input.actions["TranslateLeft"].performed += onTranslateLeft;
        _input.actions["RotateY"].performed += onRotateY;
        _input.actions["TranslateZ"].performed += onTranslateZ;

        _input.actions["ShakePosition"].performed += onShakePosition;
        _input.actions["ScaleRotate4"].performed += onScaleRotate4;
        _input.actions["ScaleRotate42"].performed += onScaleRotate42;
        _input.actions["ShakeSize"].performed += onShakeSize;
        _input.actions["Atsumaru8"].performed += onAtsumaru8;

        _input.actions["PPPixelate"].performed += onPPPixelate;
        _input.actions["PPReflectTile"].performed += onPPReflectTile;
        _input.actions["PPRGBScale"].performed += onPPRGBScale;
        _input.actions["PPMandala"].performed += onPPMandala;
        _input.actions["PPStrobe"].performed += onPPStrobe;

        _input.actions["CameraShake"].performed += onCameraShake;
    }

    private void OnDisable() {
        _input.actions["BPMSync"].performed -= onBPMSync;
        _input.actions["SwitchObj"].performed -= onSwitchObj;
        
        _input.actions["TranslateUp"].performed -= onTranslateUp;
        _input.actions["TranslateDown"].performed -= onTranslateDown;
        _input.actions["TranslateRight"].performed -= onTranslateRight;
        _input.actions["TranslateLeft"].performed -= onTranslateLeft;
        _input.actions["RotateY"].performed -= onRotateY;
        _input.actions["TranslateZ"].performed -= onTranslateZ;

        _input.actions["ShakePosition"].performed -= onShakePosition;
        _input.actions["ScaleRotate4"].performed -= onScaleRotate4;
        _input.actions["ScaleRotate42"].performed -= onScaleRotate42;
        _input.actions["ShakeSize"].performed -= onShakeSize;
        _input.actions["Atsumaru8"].performed -= onAtsumaru8;

        _input.actions["PPPixelate"].performed -= onPPPixelate;
        _input.actions["PPReflectTile"].performed -= onPPReflectTile;
        _input.actions["PPRGBScale"].performed -= onPPRGBScale;
        _input.actions["PPMandala"].performed -= onPPMandala;
        _input.actions["PPStrobe"].performed -= onPPStrobe;

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

    private void onSwitchObj(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            objNum++;
            if(objNum >= objs.Length) objNum = 0;
            currentObj = objs[objNum];
        }
    }


    private void onTranslateUp(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateUp(o);
        }
    }

    private void onTranslateDown(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateDown(o);
        }
    }

    private void onTranslateRight(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(-1.666666f, 0.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateRight(o);
        }
    }
    
    private void onTranslateLeft(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(1.666666f, 0.0f, 0.0f), Quaternion.identity);
            Object3DTransformer.TranslateLeft(o);
        }
    }

    private void onTranslateZ(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(0.0f, 0.0f, -10.0f), Quaternion.identity);
            Object3DTransformer.TranslateZ(o);
        }
    }

    private void onShakePosition(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, Vector3.zero, Quaternion.identity);
            Object3DTransformer.ShakePosition(o);
        }
    }

    private void onScaleRotate4(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(1.5f, 0, 0), Quaternion.identity);
            o.transform.localScale = Vector3.zero;
            Object3DTransformer.ScaleRotate4(o);
        }
    }

    private void onScaleRotate42(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(1.5f, 1.0f, 0), Quaternion.identity);
            Object3DTransformer.ScaleRotate42(o);
        }
    }

    private void onShakeSize(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(0, 0, 1.5f), Quaternion.identity);
            Object3DTransformer.ShakeSize(o);
        }
    }

    private void onRotateY(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(0, 0, 1.5f), Quaternion.identity);
            Object3DTransformer.RotateY(o);        
        }
    }

    private void onAtsumaru8(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            GameObject o = Instantiate(currentObj, new Vector3(2.5f, 2.0f, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);

            o = Instantiate(currentObj, new Vector3(2.5f, -2.0f, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);

            o = Instantiate(currentObj, new Vector3(-2.5f, 2.0f, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);

            o = Instantiate(currentObj, new Vector3(-2.5f, -2.0f, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);

            o = Instantiate(currentObj, new Vector3(-2.5f, 0, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);
            
            o = Instantiate(currentObj, new Vector3(2.5f, 0, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);

            o = Instantiate(currentObj, new Vector3(0, 2.0f, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);
            
            o = Instantiate(currentObj, new Vector3(0, -2.0f, 0), Quaternion.identity);
            Object3DTransformer.Translate0(o);
        }
    }


    private void onPPPixelate(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            c_pixelate.enabled = !c_pixelate.isActiveAndEnabled;
            if(c_pixelate.isActiveAndEnabled) m_pixelate.SetFloat("_BPM", BPMSyncer.BPM);
        }
    }

    private void onPPReflectTile(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            c_reflectTile.enabled = !c_reflectTile.isActiveAndEnabled;
        }
    }

    private void onPPRGBScale(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            c_rgbScale.enabled = !c_rgbScale.isActiveAndEnabled;
            if(c_rgbScale.isActiveAndEnabled) m_rgbScale.SetFloat("_BPM", BPMSyncer.BPM);
        }
    }

    private void onPPMandala(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            c_mandala.enabled = !c_mandala.isActiveAndEnabled;
        }
    }

    private void onPPStrobe(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            c_strobe.enabled = !c_strobe.isActiveAndEnabled;
        }
    }


    private void onCameraShake(InputAction.CallbackContext obj) {
        if(obj.ReadValue<float>() != 0) {
            Object3DTransformer.ShakeCamera(camera);
        }
    }

}
