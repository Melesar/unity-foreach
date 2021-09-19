using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class Foreach : MonoBehaviour
{
	void Start()
	{
		Profiler.logFile = "Profile.raw";
		Profiler.enableBinaryLog = true;
		Profiler.enabled = true;
	}

    void Update()
    {
        int number = 0;
        var list = new List<int>(Enumerable.Range(0, 200).Select(i => i + Random.Range(-40, 50)));

		Profiler.BeginSample("For loop", this);
        for (int i = 0; i < list.Count; i++)
        {
            number += list[i];
        }
		Profiler.EndSample();

		Profiler.BeginSample("Foreach on List", this);
        foreach (int i in list)
        {
            number += i;
        }
		Profiler.EndSample();

        var ilist = (IList<int>) list;
		Profiler.BeginSample("Foreach on IList", this);
        foreach (int i in ilist)
        {
            number += i;
        }
		Profiler.EndSample();

		var array = Enumerable.Range(0, 200).ToArray();
		Profiler.BeginSample("Foreach on array", this);
        foreach (int i in array)
        {
            number += i;
        }
		Profiler.EndSample();
        
        Debug.Log(number);
		Debug.Break();
    }
}
