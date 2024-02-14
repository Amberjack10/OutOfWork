using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(-25f, -2.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyUnit"))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(SkillManager.instance.atk);
            Destroy(gameObject);
        }
    }
}
