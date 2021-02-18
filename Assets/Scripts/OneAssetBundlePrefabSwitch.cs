using System;
using System.IO;
using UnityEngine;

public class OneAssetBundlePrefabSwitch : MonoBehaviour {
    int _index;
    GameObject _skybox;
    AssetBundle _skyboxes;

    void Start() {
        _skyboxes = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "skyboxprefabs"));
        if (_skyboxes == null) {
            Debug.Log("Failed to load AssetBundle");
            return;
        }

        InstantiateSkybox();
    }
    
    public void NextSkybox() {
        Destroy(_skybox);
        if (_index < 5) 
            _index++;
        else 
            _index = 0;
        
        InstantiateSkybox();
        Resources.UnloadUnusedAssets();
    }

    void InstantiateSkybox() {
        _skybox = Instantiate(_skyboxes.LoadAsset<GameObject>($"skybox ({_index})"));
    }
}
