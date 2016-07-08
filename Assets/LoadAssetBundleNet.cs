using System;
using UnityEngine;
using System.Collections;

public class LoadAssetBundleNet : MonoBehaviour
{
    public string AssetBundleURL = "http://133.130.96.139/cube";
    public string AssetName = "cube";

    IEnumerator Start()
    {
        //毎回強制的にキャッシュを消したい時使用
        //Caching.CleanCache();

        // キャッシュシステム完了待ち
        while (!Caching.ready)
        {
            yield return null;
        }

        // 「バージョン違いorキャッシュに存在しない場合」はDLアドレスへ接続
        using (WWW www = WWW.LoadFromCacheOrDownload(AssetBundleURL, 1))
        {
            yield return www;
            if (www.error != null)
            {
                throw new Exception("ダウンロードエラー:" + www.error);
            }

            AssetBundle bundle = www.assetBundle;
            if (AssetName == "")
            {
                Instantiate(bundle.mainAsset);
            }
            else {
                Instantiate(bundle.LoadAsset(AssetName));
            }

            // アセットバンドルのコンテンツをアンロード
            bundle.Unload(false);
        }
    }
}
