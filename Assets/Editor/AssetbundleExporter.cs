using UnityEngine;
using System.IO;
using UnityEditor;

public class AssetbundleExporter
{
    //Unityメニューにコマンドを追加
    [MenuItem("Assetbundle/Export")]
    static void Exporter()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath);
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath);
    }
}