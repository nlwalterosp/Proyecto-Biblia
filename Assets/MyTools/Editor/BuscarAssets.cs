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
        // 🔥 SOLO MainScene (escena activa)


        var objetos = GameObject.FindObjectsOfType<GameObject>(true);

        foreach (var obj in objetos)
        {
            var deps = EditorUtility.CollectDependencies(new Object[] { obj });

            foreach (var d in deps)
            {
                string path = AssetDatabase.GetAssetPath(d);

                if (!string.IsNullOrEmpty(path))
                {
                    usados.Add(path);
                }
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

            // ❌ SOLO trabajar dentro de Assets
            if (!asset.StartsWith("Assets"))
                continue;

            // 🔴 PROTEGER CARPETAS IMPORTANTES
            if (
                asset.StartsWith("Assets/Proyecto_Biblia") ||
                asset.StartsWith("Assets/Scenes") ||
                asset.StartsWith("Assets/Editor") ||
                asset.StartsWith("Assets/Settings") ||
                asset.StartsWith("Assets/XR") ||
                asset.StartsWith("Assets/XRI") ||
                asset.StartsWith("Assets/Resources") ||
                asset.Contains("/Plugins/") ||
                asset.Contains("Dreamteck") ||
                asset.Contains("ARCore") ||
                asset.Contains("OpenXR") ||
                asset.Contains("XR") ||
                asset.EndsWith(".asmdef") ||
                asset.EndsWith(".cs")
            )
                continue;

            // 🟡 SOLO NO usados
            if (!usados.Contains(asset))
            {
                if (asset.StartsWith(carpetaDestino))
                    continue;

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

    [MenuItem("Tools/Preview NO Usados (MainScene)")]
    static void Preview()
    {
        var objetos = GameObject.FindObjectsOfType<GameObject>(true);

        HashSet<string> usados = new HashSet<string>();

        foreach (var obj in objetos)
        {
            var deps = EditorUtility.CollectDependencies(new Object[] { obj });

            foreach (var d in deps)
            {
                string path = AssetDatabase.GetAssetPath(d);

                if (!string.IsNullOrEmpty(path))
                {
                    usados.Add(path);
                }
            }
        }

        string[] allAssets = AssetDatabase.GetAllAssetPaths();

        int contador = 0;

        foreach (var asset in allAssets)
        {
            if (AssetDatabase.IsValidFolder(asset)) continue;
            if (!asset.StartsWith("Assets")) continue;

            if (
                asset.StartsWith("Assets/Editor") ||
                asset.StartsWith("Assets/Settings") ||
                asset.StartsWith("Assets/XR") ||
                asset.StartsWith("Assets/XRI") ||
                asset.Contains("/Plugins/") ||
                asset.EndsWith(".cs") ||
                asset.EndsWith(".dll") ||
                asset.EndsWith(".asmdef")
            )
                continue;

            if (!usados.Contains(asset))
            {
                Debug.Log("❌ NO USADO: " + asset);
                contador++;
            }
        }

        Debug.Log("🔍 Total NO usados: " + contador);
    }
}

