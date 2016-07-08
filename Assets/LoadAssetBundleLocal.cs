using UnityEngine;
using System.Collections;

public class LoadAssetBundleLocal : MonoBehaviour
{
    public string AssetName = "cube";

    IEnumerator Start()
    {
        // Application.dataPathはAssetsの直下のフォルダの事
        string path = Application.dataPath + "/StreamingAssets/cube";
        WWW www = new WWW("file://" + path);
        yield return www;

        AssetBundle bundle = www.assetBundle;
        Instantiate(bundle.LoadAsset(AssetName));

        // アセットバンドルのコンテンツをアンロード
        bundle.Unload(false);
    }
}