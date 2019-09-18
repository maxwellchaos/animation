using UnityEngine;
using UnityStandardAssets;

public class Target : MonoBehaviour
{
    private bool fly = false;

    void OnTriggerEnter(Collider other)
    {
        bool is_player = other.gameObject.GetComponent<CharacterControl>() != null;
        if (is_player)
        {
            fly = true;
            transform.parent = other.transform;
            Base = transform.position;
        }
    }

    float scaleX = 3f;
    float i = 0;
    Vector3 Base;
    void Update ()
    {

        if (fly)
        {
            i += Time.deltaTime * scaleX;
            float x = -i;
            float y =  Mathf.Sqrt(i)*2 -i/4;
            float z = -Mathf.Sqrt(i) *2 +i/2;// -Easing.QuadraticEaseIn(i) / 5;
            transform.localPosition = new Vector3(x, y, z);
            //trans
            if (i > scaleX*0.3f)//0,3 секунды живет
            {
                AddScore();
                Destroy(gameObject);
            }
        }
    }

    void AddScore()
    {
        GameObject.FindObjectOfType<ScoreCounter>().Add(1);
    }
}
