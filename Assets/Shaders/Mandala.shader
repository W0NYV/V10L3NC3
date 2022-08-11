Shader "Hidden/Mandala"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

            float2x2 rot(float r) {
                return float2x2(cos(r), -sin(r), sin(r), cos(r));
            } 

            float2 pmod(float2 p, float r) {
                float a = atan2(p.x, p.y) + acos(-1.0)/r;
                float n = acos(-1.0)*2.0 / r;
                a = floor(a/n)*n;
                float2 result = mul(p, rot(-a));
                return result;
            }

            float2 kaleido(float2 p) {
                float th = atan2(p.y, p.x);
                float r = pow(length(p), 0.9);
                float f = acos(-1.0) / 3.5;

                th = abs(abs(fmod(th + f/4.0, f)) - f/2.0) / (1.0+f);

                return float2(cos(th), sin(th)) * r * 0.1;
            }

            fixed4 frag (v2f i) : SV_Target
            {

                float2 p = i.uv;
                p.x = lerp(-1.0, 1.0, p.x);
                p.y = lerp(-1.0, 1.0, p.y);
                p.y *= _ScreenParams.y / _ScreenParams.x;

                p = kaleido(p);

                p.y += 0.75;
                // p.x += 0.5;
                p.y += _Time.y/20.0;
                p = frac(p*10.0);

                fixed4 col = tex2D(_MainTex, p);
                
                return col;
            }
            ENDCG
        }
    }
}
