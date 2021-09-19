using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class Foreach : MonoBehaviour
{
	private void Start()
	{
		Profiler.logFile = "Profile.raw";
		Profiler.enableBinaryLog = true;
		Profiler.enabled = true;
	}

    private void Update()
    {
        int number = 0;

        var list = new List<int>(Enumerable.Range(0, 200).Select(i => i + Random.Range(-40, 50)));
        
		Profiler.BeginSample("Foreach on List", this);
        foreach (int i in list)
        {
            number += i;
        }
		Profiler.EndSample();
		
		int[] array = Enumerable.Range(0, 200).ToArray();
		Profiler.BeginSample("Foreach on array", this);
        foreach (int i in array)
        {
            number += i;
        }
		Profiler.EndSample();

        var ilist = (IList<int>) list;
		// Profiler.BeginSample("Foreach on IList", this);
        foreach (int i in ilist)
        {
            number += i;
        }
		// Profiler.EndSample();

		var dictionary = new Dictionary<int, int>();
		for (int i = 0; i < 200; i++)
		{
			dictionary.Add(i, Random.Range(-50, 50));
		}

		Profiler.BeginSample("Foreach on Dictionary", this);
		foreach (KeyValuePair<int,int> keyValuePair in dictionary)
		{
			number += keyValuePair.Value;
		}
		Profiler.EndSample();

		var hashMap = new HashSet<int>(Enumerable.Range(0, 200));
		Profiler.BeginSample("Foreach on HashSet", this);
		foreach (int i in hashMap)
		{
			number += i;
		}
		Profiler.EndSample();
		
        Debug.Log(number);
    }
}
