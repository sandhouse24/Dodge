using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed; //게임 오브젝트의 앞쪽 방향으로 speed만큼의 속도
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();//충돓한 상대 오브젝트에서 PlayerController 컴포넌트 가져오기

            if (playerController != null)//PlayerController 컴포넌트를 가져오는데 성공했다면
                playerController.Die();
        }

        if (other.tag == "Wall")
            gameObject.SetActive(false);
    }
}
