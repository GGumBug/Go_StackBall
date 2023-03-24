using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEffect : MonoBehaviour
{
    // 이벤트에서 매개변수를 받아서 사용하는 함수를 만들었다.
    public void ChangeColor(Color color)
    {
        var module = GetComponent<ParticleSystem>().main;

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[]
            {
                // 색상, 위치(time)
                new GradientColorKey(Color.white, 0),
                new GradientColorKey(color, 0.5f),
                new GradientColorKey(Color.black, 1)
            },
            new GradientAlphaKey[]
            {
                new GradientAlphaKey(1, 0),
                new GradientAlphaKey(1, 0.5f),
                new GradientAlphaKey(1, 1)
            }
        );

        module.startColor = gradient;
    }
}
