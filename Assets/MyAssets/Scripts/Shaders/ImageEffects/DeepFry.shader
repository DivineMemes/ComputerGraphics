Shader "Hidden/DeepFry"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Pixelate("Pixelation", float) = 64
		_Color("Color", Color) = (1,1,1,1)
		_Brightness("Bright", float) = 1
		/*_Columns ("PixelColumns", float) = 64
		_Rows("PixelRows", float) = 64*/
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			//float _Columns;
			//float _Rows;
			float _Pixelate;
			float4 _Color;
			float _Brightness;
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = i.uv;
				uv.x *= _Pixelate;
				uv.y *= _Pixelate;
				uv.x = round(uv.x);
				uv.y = round(uv.y);
				uv.x /= _Pixelate;
				uv.y /= _Pixelate;
				fixed4 col = tex2D(_MainTex, uv);
				/*col.r *= _Brightness;
				col.g *= _Brightness;
				col.b *= _Brightness;*/
				col.rgb *= _Brightness;
				return col;
			}
			ENDCG
		}
	}
}
