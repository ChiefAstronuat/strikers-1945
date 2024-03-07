using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private Transform shootTransform;
    [SerializeField]
    private float shootInterval = 0.05f;
    private float LastShootTime = 0;

    // Update is called once per frame
    void Update()
    {
        float horizontalinput = Input.GetAxisRaw("Horizontal");
        float verticlainput = Input.GetAxisRaw("Vertical");
        Vector3 moveTo = new Vector3(horizontalinput, verticlainput, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;

        /*Vector3 moveTo2 = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveTo2;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
             transform .position += moveTo2;
        }*/

        //마우스 컨트롤러
        /*Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        Debug.Log(mousePos);*/

        //무기 기능
        Shoot();
    }
    void Shoot()
    {
        if (Time.time - LastShootTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            LastShootTime = Time.time;
        }
    }
}
