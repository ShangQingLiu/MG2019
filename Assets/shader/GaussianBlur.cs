using UnityEngine;
using System.Collections;

//编辑状态下也运行
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class GaussianBlur : MonoBehaviour
{

    public Material _Material;
    public Material _Picture;
    public Color BaseColor ;
    //模糊半径
    public float BlurRadius = 1.0f;
    //降分辨率
    public int downSample = 2;
    //迭代次数
    public int iteration = 1;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_Material)
        {
            //申请RenderTexture
            RenderTexture rt = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);

            //_Material.SetTexture("_MainTex", source);
            _Material.SetTexture("_Test", _Picture.GetTexture("_MainTex"));

            //Vector4 refColor = new Vector4(0.191f, -0.054f, 0.221f, 0.0f);
            //if (BaseColor != new Color(0, 0, 0, 0))
            //{
            //    refColor = BaseColor;
            //}
            //Debug.Log(refColor);
            _Material.SetVector("_sepiaConvert", BaseColor);

            //Graphics.Blit(source,rt );
            Graphics.Blit(source, rt,_Material);
                
            //将结果输出
            Graphics.Blit(rt, destination);

            //释放申请的两块RenderBuffer内容
            RenderTexture.ReleaseTemporary(rt);
        }
    }
}
