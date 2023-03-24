using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private PlatformPartController[]    parts;
    [SerializeField]
    private float                       removeDuration = 1;

    public bool                        IsCollision { private set; get; } = false;

    public void BreakAllParts()
    {
        if (IsCollision == false)
        {
            IsCollision = true;
        }

        if (transform != null)
        {
            transform.parent = null;
        }

        parts = transform.GetComponentsInChildren<PlatformPartController>();

        foreach (PlatformPartController part in parts)
        {
            part.BreakingPart();
        }

        StartCoroutine(nameof(RemoveParts));
    }

    private IEnumerator RemoveParts()
    {
        yield return new WaitForSeconds(removeDuration);

        gameObject.SetActive(false);
    }
}
