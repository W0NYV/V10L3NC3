Shader "Hidden/Pixelate"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Col ("Color", Color) = (1, 0, 0, 1)
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
            float4 _Col;
            float _BPM;

            fixed4 frag (v2f i) : SV_Target
            {
                float t = _BPM/60.0*_Time.y;
                float t2 = exp(frac(t))-1.0;
                float s = 200.0 * t2;

                float2 grid;
                grid.x = floor(i.uv.x * s) / s;
                grid.y = floor(i.uv.y * s) / s;

                fixed4 col = tex2D(_MainTex, grid);
                return col;
            }
            ENDCG
        }
    }
}
