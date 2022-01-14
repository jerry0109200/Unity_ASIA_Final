using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 10);
        //����
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-transform.up * Time.deltaTime * 2);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("��e�B�I����G" + collision.gameObject);
        var hit = collision.gameObject;
        var health = hit.GetComponent<HurtSystem>();
        if (health != null)
        {
            health.Hurt(30);
        }
        Destroy(gameObject);
    }
}
