Shader "Hidden/RGBScale"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BPM ("BPM", float) = 120.0
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

            sampler2D _MainTex;
            float _BPM;

            fixed4 frag (v2f i) : SV_Target
            {

                float t = _BPM/60.0*_Time.y*4.0;
                float t2 = abs(sin(-t));
                float t3 = abs(sin(-t+0.3));
                float t4 = abs(sin(-t+0.6));

                float2 p = i.uv;
                float2 p2 = i.uv;
                float2 p3 = i.uv;


                p *= (0.5 + 0.5*t2);
                p += 0.25 - 0.25*t2;

                p2 *= (0.5 + 0.5*t3);
                p2 += 0.25 - 0.25*t3;

                p3 *= (0.5 + 0.5*t4);
                p3 += 0.25 - 0.25*t4;

                fixed4 col = tex2D(_MainTex, p);
                fixed4 col2 = tex2D(_MainTex, p2);
                fixed4 col3 = tex2D(_MainTex, p3);

                fixed4 dest = fixed4(col.r, col2.g, col3.b, 1.0);

                return dest;
            }
            ENDCG
        }
    }
}
