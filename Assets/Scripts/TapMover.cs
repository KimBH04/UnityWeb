using UnityEngine;
using UnityEngine.EventSystems;

public class TapMover : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform player;

    [SerializeField] private float speed = 5f;

    private Vector3 target;

    public void OnPointerDown(PointerEventData eventData)
    {
        target = Camera.main.ScreenToWorldPoint(eventData.position);
        target.z = player.position.z;
    }

    private void Start()
    {
        target = player.position;
    }

    private void Update()
    {
        player.position = Vector3.MoveTowards(player.position, target, speed * Time.deltaTime);
    }
}
