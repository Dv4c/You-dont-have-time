using System;
using Unity.VisualScripting;
using UnityEngine;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 spawnPos;

    private void Start()
    {
        player.transform.position = spawnPos;
    }

    public void OnTimerElapsed()
    {
        Respawn();
    }

    private void Respawn()
    {
        player.transform.position = spawnPos;
    }
}
