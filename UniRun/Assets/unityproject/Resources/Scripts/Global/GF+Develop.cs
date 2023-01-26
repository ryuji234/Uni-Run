using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static partial class GF
{
    #region Print log func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif

    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message, UnityEngine.Object context)
    {
#if DEBUG_MODE
        Debug.Log(message, context);
#endif
    }
#endregion

#region Assert for debug
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition, object message)
    {
#if DEBUG_MODE
        Debug.Assert(condition, message);
#endif
    }
    #endregion      //Assert for debug

    #region Vaild Func
    public static bool IsValid<T>(this T component_)
    {
        bool isValid = component_.Equals(null) == false;
        
        return isValid;
    }
    #endregion
}
