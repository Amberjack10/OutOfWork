using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private Animator anim;

    public AudioClip clip;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        transform.localPosition = new Vector3(-25f, -2f, 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyUnit"))
        {
            SoundManager.instance.PlaySFX(clip);
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
