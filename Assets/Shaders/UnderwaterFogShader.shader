Shader "Custom/UnderwaterFog"
{
    Properties
    {
        _color("Fog Color", Color) = (0.2, 0.5, 0.6, 1)
        _alpha("Fog Alpha", Range(0, 1)) = 0.5
        _UnderwaterFactor("Underwater Factor", Range(0,1)) = 0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Overlay" }
        Pass
        {
            ZTest Always Cull Off ZWrite Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _color;
            float _alpha;
            float _UnderwaterFactor;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv  : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 fog = _color;
                fog.a = _alpha * _UnderwaterFactor;
                return lerp(col, fog, fog.a);
            }
            ENDHLSL
        }
    }
}
