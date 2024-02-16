using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using System.Threading;
using C2M2.NeuronalDynamics.Interaction;
using System.Threading.Tasks;

public class Placed : MonoBehaviour
{
    // public static HashSet<string> neuron = new HashSet<string>();

    public static int Page;
    private static GameObject cellPreviewerObj;
    private static CellPreviewer cellPreviewer;
    private static GameObject[] array;
    public static int cellSize;





    public void shout()
    {
        UnityEngine.Debug.Log("SHOUT");

    }

    public void removeNeuroPreview()
    {
        array = GameObject.FindGameObjectsWithTag("Neuron");
        foreach (GameObject game in array)
        {
            Destroy(game);

        }
        cellPreviewer.generateNeuron();


    }
    public void downward()
    {
        Stopwatch sw = Stopwatch.StartNew();
        try
        {
            if (array.Length == cellSize)
            {
                Page += cellSize;
                removeNeuroPreview();

            }
        }
        finally
        {
            sw.Stop();
           UnityEngine.Debug.Log(sw.ElapsedMilliseconds);
        }

    }
    public void upward()
    {
        if (Page - cellSize >= 0)
        {
            Page -= cellSize;
            removeNeuroPreview();

        }
    }
    IEnumerable behavior()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.Debug.Log("Started courtine");
        File.Move("/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes/108-2_7_2_CA1_R1_N2_CG.CNG.mesh.vrn", "/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/StreamingAssets/NeuronalDynamics/Geometries/108-2_7_2_CA1_R1_N2_CG.CNG.CNG.mesh.vrn");
        removeNeuroPreview();
    }
    void Start()
    {
    
    cellPreviewerObj= GameObject.FindGameObjectWithTag("CellPreviewer");
    cellPreviewer = cellPreviewerObj.GetComponent<CellPreviewer>();
    cellSize = (int)Math.Pow(cellPreviewer.positionsNorm.Length, 2);
    UnityEngine.Debug.Log(cellSize);
    array = GameObject.FindGameObjectsWithTag("Neuron");

    }



    public async void Generate()
    {

        await Task.Run(() =>
        {
            Process p = new Process();
            p.StartInfo.FileName = "wsl.exe";
            p.StartInfo.Arguments = "cd /mnt/c/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes; python3 New_Generate_meshes.py -i cells/108-2_7_2_CA1_R1_N2_CG.CNG.swc";
            //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //removes WSL popup comment out for testing
            p.Start();
            p.WaitForExit();
        }
       );
        try
        {
            File.Move("/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes/108-2_7_2_CA1_R1_N2_CG.CNG.mesh.vrn", "/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/StreamingAssets/NeuronalDynamics/Geometries/108-2_7_2_CA1_R1_N2_CG.CNG.CNG.mesh.vrn");
            removeNeuroPreview();

        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log("Generated Neuron Already exists in geometries folder");
        }
        //WIP Bellow (File Move executes immediately after button press resulting in file not found error)
        /* String directory = Application.dataPath.Replace("\\", "/").Replace("C:/", "/mnt/c/");
         directory = Path.Combine(directory, "PythonNeuronMeshes").Replace("\\", "/");
         string inputDir = Path.Combine("cells", "108-2_7_2_CA1_R1_N2_CG.CNG.swc").Replace("\\", "/");
         UnityEngine.Debug.Log(directory);
         UnityEngine.Debug.Log(inputDir);
         await Task.Run(() =>
         {
             Process p = new Process();
             p.StartInfo.FileName = "wsl.exe";
             p.StartInfo.Arguments = $"cd {Path.GetDirectoryName(directory)}; python3 New_Generate_Meshes.py -i {inputDir}";
             //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
             p.Start();
             p.WaitForExit();
             File.Move("/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes/108-2_7_2_CA1_R1_N2_CG.CNG.mesh.vrn", "/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/StreamingAssets/NeuronalDynamics/Geometries/108-2_7_2_CA1_R1_N2_CG.CNG.CNG.mesh.vrn");

         }
        );
         contain();

     }
        */
    }

}

