using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestingDispatcher : MonoBehaviour
{
    public ComputeShader computeShader;
    public ComputeShader computeShader2;
    public ComputeShader hashTableShader;
    // Start is called before the first frame update
    void Start()
    {
        ComputeBuffer floatsBuffer = new ComputeBuffer(64, 4); // Array de 64 floats (4 bytes por float).
        List<float> floatsData = new List<float>(new float[64]);
        float[] outputFloatsData = new float[64];
        // List<float> floatsData = Enumerable.Range(0, 64).Select(i => 0.0f).ToList();
        //foreach (float f in floatsData)
        //{
        //    Debug.Log(f);
        //}

        floatsBuffer.SetData(floatsData);

        int kernelIndex = computeShader.FindKernel("CSMain");
        int kernelIndex2 = computeShader.FindKernel("CSSecond");
        int kernelIndex3 = computeShader2.FindKernel("CSThird");

        

        computeShader.SetBuffer(kernelIndex, "floatsData", floatsBuffer);
        computeShader.SetBuffer(kernelIndex2, "floatsData", floatsBuffer);
        computeShader2.SetBuffer(kernelIndex3, "floatsData", floatsBuffer);

        computeShader.Dispatch(kernelIndex, 1, 1, 1);
        computeShader.Dispatch(kernelIndex2, 1, 1, 1);
        computeShader2.Dispatch(kernelIndex3, 1, 1, 1);

        floatsBuffer.GetData(outputFloatsData);
        foreach (float f in outputFloatsData)
        {
            Debug.Log(f);
        }

        floatsBuffer.Dispose();
    }

}
