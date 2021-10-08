using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class RemoveURPTextures : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        Debug.Log("MyCustomBuildProcessor.OnPreprocessBuild for target " + report.summary.platform + " at path " + report.summary.outputPath);

        string packagesPath = Application.dataPath.Replace("/Assets", "") + "/Library/PackageCache";
        Debug.Log($"packagesPath: {packagesPath}");
        string[] directories = Directory.GetDirectories(packagesPath);

        foreach (string directory in directories)
        {
            Debug.Log($"directory: {directory}");
            if (directory.Contains("com.unity.render-pipelines.universal"))
            {
                Debug.Log($"Modifying entries in: {directory}");
                string texturesPath = Path.Combine(directory, "Textures/FilmGrain");
                string[] files = Directory.GetFiles(texturesPath, "*.meta");
                foreach (string filename in files)
                {
                    Debug.Log($"Modifying entry: {filename}");
                    string[] lines = File.ReadAllLines(filename);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = lines[i].Replace("maxTextureSize: 2048", "maxTextureSize: 32");
                    }

                    File.WriteAllLines(filename, lines);
                }
            }
        }
        //throw new BuildFailedException("aa");
    }
}