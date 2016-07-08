using UnityEngine;
using System.Collections;

class LoadAssetBundleNetNonCache : MonoBehaviour
{
    public string AssetBundleURL = "http://133.130.96.139/cube";
    public string AssetName = "cube";

    IEnumerator Start()
    {
        // アセットバンドルのDLアドレスへ接続
        using (WWW www = new WWW(AssetBundleURL))
        {
            yield return www;

            AssetBundle bundle = www.assetBundle;
            Instantiate(bundle.LoadAsset(AssetName));
            // アセットバンドルのコンテンツをアンロード
            bundle.Unload(false);
        }
    }
}