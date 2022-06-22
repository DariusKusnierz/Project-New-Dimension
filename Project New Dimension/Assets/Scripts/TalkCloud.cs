using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCloud : MonoBehaviour
{
    #region Singleton
    public static TalkCloud instance;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
    }

    #endregion

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void showCloud(Transform place, Transform playerRotation)
    {
        gameObject.SetActive(true);
        transform.position = place.position;
        transform.rotation = Quaternion.Euler(0, playerRotation.rotation.eulerAngles.y + 90, 0);
    }

    public void hideCloud()
    {
        gameObject.SetActive(false);
    }
}
