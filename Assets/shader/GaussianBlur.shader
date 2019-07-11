﻿//高斯模糊
Shader "Custom/GaussianBlur"
{

	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Test("Albedo (RGB)", 2D) = "white" {}
		_sepiaConvert("_sepiaConvert", Vector) = (0,0,0,0) 
	}
		//通过CGINCLUDE我们可以预定义一些下面在Pass中用到的struct以及函数，
		//这样在pass中只需要设置渲染状态以及调用函数,shader更加简洁明了
		CGINCLUDE
#include "UnityCG.cginc"

		//blur结构体，从blur的vert函数传递到frag函数的参数
		struct v2f_blur
	{
		float4 pos : SV_POSITION;   //顶点位置
		float2 uv  : TEXCOORD0;     //纹理坐标
		float4 uv01 : TEXCOORD1;    //一个vector4存储两个纹理坐标
		float4 uv23 : TEXCOORD2;    //一个vector4存储两个纹理坐标
		float4 uv45 : TEXCOORD3;    //一个vector4存储两个纹理坐标
	};

	//shader中用到的参数
	sampler2D _MainTex;
	sampler2D _Test;
	float4 _sepiaConvert;
	//XX_TexelSize，XX纹理的像素相关大小width，height对应纹理的分辨率，x = 1/width, y = 1/height, z = width, w = height
	float4 _MainTex_TexelSize;
	//给一个offset，这个offset可以在外面设置，是我们设置横向和竖向blur的关键参数
	float4 _offsets;

	//vertex shader
	v2f_blur vert_blur(appdata_img v)
	{
		v2f_blur o;
		o.pos = UnityObjectToClipPos(v.vertex);
		//uv坐标
		o.uv = v.texcoord.xy;
		//计算一个偏移值，offset可能是（0，1，0，0）也可能是（1，0，0，0）这样就表示了横向或者竖向取像素周围的点
		_offsets *= _MainTex_TexelSize.xyxy;

		//由于uv可以存储4个值，所以一个uv保存两个vector坐标，_offsets.xyxy * float4(1,1,-1,-1)可能表示(0,1,0-1)，表示像素上下两个
		//坐标，也可能是(1,0,-1,0)，表示像素左右两个像素点的坐标，下面*2.0，*3.0同理
		o.uv01 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1);
		o.uv23 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1) * 2.0;
		o.uv45 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1) * 3.0;

		return o;
	}

	float SmoothLight(float bp, float mp) {
		float res = 0;
		if (mp > 0.5) {
			res = (bp + mp + mp - 1)*(sqrt(bp) - (bp));
		}
		else {
			res = (bp + mp + mp - 1)*(bp - bp * bp);
		}
		res = clamp(res, 0, 1);
		return res;
	}

    //fragment shader
    fixed4 frag_blur(v2f_blur i) : SV_Target
    {
        fixed4 color = fixed4(0,0,0,0);
		fixed4 baseColor = fixed4(0, 0, 0, 0);
		fixed4 maskColor = fixed4(0, 0, 0, 0);
        //将像素本身以及像素左右（或者上下，取决于vertex shader传进来的uv坐标）像素值的加权平均
        baseColor =  tex2D(_MainTex, i.uv);
        maskColor =  tex2D(_Test, i.uv);
		color = baseColor;
		float gray = (color.r + color.g + color.b) / 3;
		float r, g, b;
		fixed Y = dot (fixed3(0.299, 0.587, 0.114), baseColor.rgb);
		fixed _value = dot (fixed3(0.299, 0.587, 0.114), maskColor.rgb);
	   // Convert to Sepia Tone by adding constant
		//This can Change as base Color
	   //fixed4 sepiaConvert = _sepiaConvert;
	   fixed4 sepiaConvert = float4(0.191, -0.054, -0.221, 0.0);
	   fixed4 output = sepiaConvert + Y;
	   output.a = baseColor.a;
	   output = lerp(output, baseColor, _value);
	   return output;
    }
 
    ENDCG
 
    //开始SubShader
    SubShader
    {
        //开始一个Pass
        Pass
        {
            //后处理效果一般都是这几个状态
            ZTest Always
            Cull Off
            ZWrite Off
 
            //使用上面定义的vertex和fragment shader
            CGPROGRAM
            #pragma vertex vert_blur
            #pragma fragment frag_blur
            ENDCG
        }
 
    }
//后处理效果一般不给fallback，如果不支持，不显示后处理即可
}