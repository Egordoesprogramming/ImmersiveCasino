using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Utilities
{
    static public bool AllSame<T>(T v0, params T[] vn)
    {
        //return ((v0 == vn) && ...);
        foreach (var vi in vn)
        {
            if (!EqualityComparer<T>.Default.Equals(v0, vi))
                return false;
        }

        return true;
    }
    static public bool AllSame<T>(List<T> ls)
    {
        //return ((v0 == vn) && ...);
        var count = ls.Count;
        for (int i = 0; i < count; ++i)
        {
            if (!EqualityComparer<T>.Default.Equals(ls[0], ls[i]))
                return false;
        }

        return true;
    }
}
