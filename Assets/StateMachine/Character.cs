using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Character : MonoBehaviour
{

    private IState<Character> currentState;
    [SerializeField] private Animator animator;
    [SerializeField] ColorType charColor;
    [SerializeField] ColorData colorData;
    private string currentAnim;
    private void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    private void OnInit()
    {
        ChangeState(new IdleState());

    }
    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.ResetTrigger(animName);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }

    public void ChangeColor(int Index)
    {
        //Kiểm tra số lượng phần tử của colorMaterials có lơn hơn hoặc bằng số lượng các giá trị của enum ColorType không
        if (colorData != null && colorData.colorMaterials.Count >= System.Enum.GetValues(typeof(ColorType)).Length)
        {
            Material selectedMaterial = null;
            switch (charColor)
            {
                case ColorType.Red:
                    selectedMaterial = colorData.colorMaterials[0];
                    break;
                case ColorType.Green:
                    selectedMaterial = colorData.colorMaterials[1];
                    break;
                case ColorType.Blue:
                    selectedMaterial = colorData.colorMaterials[2];
                    break;
                case ColorType.Yellow:
                    selectedMaterial = colorData.colorMaterials[3];
                    break;
                case ColorType.Pink:
                    selectedMaterial = colorData.colorMaterials[4];
                    break;
                case ColorType.Orange:
                    selectedMaterial = colorData.colorMaterials[5];
                    break;
            }
            if (selectedMaterial != null)
            {
                GetComponent<Renderer>().material = selectedMaterial;
            }
        }
    }

}
