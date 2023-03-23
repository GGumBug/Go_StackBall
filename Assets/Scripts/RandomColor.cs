using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomColor : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Color>   onChanged;
    [SerializeField]
    private float               hueMin = 0;
    [SerializeField]
    private float               hueMax = 1;
    [SerializeField]
    private float               saturationMin = 0.7f;
    [SerializeField]
    private float               saturationMax = 1f;
    [SerializeField]
    private float               valueMin = 0.7f;
    [SerializeField]
    private float               valueMax = 1;

    public void ColorHSV()
    {
        Color color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
        // onChanged 이벤트로 등록 된 메소드들을 호출한다.
        onChanged?.Invoke(color);
    }
}
