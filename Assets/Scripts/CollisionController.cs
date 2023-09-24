using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameObject science;
    private GameObject math;
    private GameObject english;
    private GameObject socialStudies;
    private void Start()
    {
        science = GameObject.Find("science");
        math = GameObject.Find("math");
        english = GameObject.Find("english");
        socialStudies = GameObject.Find("social studies");
        science.gameObject.SetActive(false);
        math.gameObject.SetActive(false);
        english.gameObject.SetActive(false);
        socialStudies.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "purple planet")
        {
            science.gameObject.SetActive(true);
        }
        if (collision.gameObject.name == "turq planet")
        {
            math.gameObject.SetActive(true);
        }
        if (collision.gameObject.name == "green planet")
        {
            english.gameObject.SetActive(true);
        }
        if (collision.gameObject.name == "blue planet")
        {
            socialStudies.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "purple planet")
        {
            science.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "turq planet")
        {
            math.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "green planet")
        {
            english.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "blue planet")
        {
            socialStudies.gameObject.SetActive(false);
        }
    }


}
