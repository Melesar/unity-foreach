using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Foreach : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int number = 0;
        
        var list = new List<int>(Enumerable.Range(0, 200).Select(i => i + Random.Range(-40, 50)));
        // /var hashMap = new HashSet<int>(Enumerable.Range(0, 200).Select(i => i + Random.Range(-40, 50)));

        for (int i = 0; i < list.Count; i++)
        {
            number += list[i];
        }

        foreach (int i in list)
        {
            number += i;
        }

        var ilist = (IList<int>) list;
        foreach (int i in ilist)
        {
            number += i;
        }
        
        Debug.Log(number);
    }
}
