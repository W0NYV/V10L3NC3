using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using B83.Win32;

public class TextureLoader : MonoBehaviour {

    public Material mat;
    public Texture2D defaultTex;
    public RawImage rawimage;

    string str;

    private void OnEnable() {
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnDroppedFiles;
    }

    private void OnDisable() {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnDroppedFiles(List<string> aFiles, POINT aPos) {
        str = aFiles[0];
        str.Replace(@"\", @"\\");
        var imageBytes = File.ReadAllBytes(str);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        
        rawimage.texture = tex;
        mat.SetTexture("_MainTex", tex);
    }

    // private void OnGUI() {
    //     GUI.skin.label.fontSize = 50;

    //     GUILayout.Label($"file: {str}");

    // }

    // Start is called before the first frame update
    void Start() {
        mat.SetTexture("_MainTex", defaultTex);
        rawimage.texture = defaultTex;
    }

}
