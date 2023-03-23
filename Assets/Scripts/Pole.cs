using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    private void Start()
    {
        // 컬러 그레이를 추가하면 채도가 떨어진다.
        GetComponent<MeshRenderer>().material.color += Color.gray;
    }
}
