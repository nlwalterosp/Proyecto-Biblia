using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class BuscarAssets
{
    [MenuItem("Tools/Mover Solo NO Usados (Filtrado)")]
    static void Buscar()
    {
        string[] allAssets = AssetDatabase.GetAllAssetPaths();
        HashSet<string> usados = new HashSet<string>();

        // Escenas
        string[] escenas = AssetDatabase.FindAssets("t:Scene");
        foreach (string guid in escenas)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            foreach (var d in AssetDatabase.GetDependencies(path, true))
            {
                usados.Add(d);
            }
        }

        // Prefabs
        string[] prefabs = AssetDatabase.FindAssets("t:Prefab");
        foreach (string guid in prefabs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            foreach (var d in AssetDatabase.GetDependencies(path, true))
            {
                usados.Add(d);
            }
        }

        string carpetaDestino = "Assets/NO_USADOS";

        if (!AssetDatabase.IsValidFolder(carpetaDestino))
        {
            AssetDatabase.CreateFolder("Assets", "NO_USADOS");
        }

        int contador = 0;

        foreach (var asset in allAssets)
        {
            // ❌ ignorar carpetas
            if (AssetDatabase.IsValidFolder(asset))
                continue;

            // ❌ ignorar carpetas protegidas
            if (asset.StartsWith("Assets/Proyecto_Biblia") ||
                asset.StartsWith("Assets/Scenes") ||
                asset.StartsWith("Assets/Scripts"))
                continue;

            // ❌ ignorar plugins y asmdef
            if (asset.Contains("/Plugins/") ||
                asset.Contains("/Dreamteck/") ||
                asset.Contains(".asmdef"))
                continue;

            // 🔥 SOLO no usados
            if (!usados.Contains(asset) && asset.StartsWith("Assets"))
            {
                if (asset.StartsWith(carpetaDestino)) continue;

                string nombre = Path.GetFileName(asset);
                string destino = carpetaDestino + "/" + nombre;

                string error = AssetDatabase.MoveAsset(asset, destino);

                if (string.IsNullOrEmpty(error))
                {
                    contador++;
                }
                else
                {
                    Debug.LogWarning("No se pudo mover: " + asset);
                }
            }
        }

        AssetDatabase.Refresh();

        Debug.Log("✅ Movidos SOLO no usados: " + contador);
    }
}