using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
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
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        anim.SetTrigger("Destroy");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
