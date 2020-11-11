using UnityEngine;

public class gamemanager : MonoBehaviour
{
    [Header("水槍")]
    public Transform water;
    [Header("咪嚕")]
    public Transform mi;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("旋轉速度")]
    [Range(0.1f,20f)]
    public float turn = 1.5f;
    [Header("縮放")]
    [Range(0f, 5f)]
    public float size = 0.3f;
    [Header("水槍動畫元件")]
    public Animator aniwater;
    [Header("咪嚕動畫元件")]
    public Animator animi;

    private void Start()
    {
        print("開始事件");
    }

    //public float test = 1;
    //public float test2 = 1;

    private void Update()
    {
        print("更新事件");
        print(joystick.Vertical);

        water.Rotate(0, joystick.Horizontal*turn, 0);
        mi.Rotate(0, joystick.Horizontal * turn, 0);

        water.localScale += new Vector3(1, 1, 1) * joystick.Vertical*size;
        water.localScale = new Vector3(1, 1, 1)*Mathf.Clamp(water.localScale.x, 0.5f, 3.5f);
        mi.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        mi.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(mi.localScale.x, 0.5f, 3.5f);

        //test = Mathf.Clamp(test, 0.5f, 9.9f);

        //print(Mathf.Clamp(test2, 0, 10));
    }

    public void Attack()
    {
        print("攻擊");
        aniwater.SetTrigger("attack觸發");
        animi.SetTrigger("attack觸發");
    }

    public void playanimation(string aniName)
    {
        aniwater.SetTrigger(aniName);
        animi.SetTrigger(aniName);
    }
    

}
