using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform destination; // Перетащите сюда объект, куда телепортировать

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destination.position;
        }
    }
}
