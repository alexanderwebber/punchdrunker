using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Result : MonoBehaviour
{
    public enum RESULT_TYPE
    {
        BOOLEAN,
        INTEGER
    }

    public RESULT_TYPE type;
    public bool BooleanResult;
    public int IntegerResult;

    public Result(bool booleanResult)
    {
        type = RESULT_TYPE.BOOLEAN;
        this.BooleanResult = booleanResult;
    }

    public Result(int integerResult)
    {
        type = RESULT_TYPE.INTEGER;
        this.IntegerResult = integerResult;
    }
}
