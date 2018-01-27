// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33952,y:32103,varname:node_4795,prsc:2|emission-3491-OUT,alpha-5582-OUT;n:type:ShaderForge.SFN_TexCoord,id:2422,x:31655,y:32398,varname:node_2422,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:2593,x:33082,y:32444,varname:node_2593,prsc:2,tex:f1729166a2f9bbc4084a80c9b211c01a,ntxv:0,isnm:False|UVIN-8503-UVOUT,TEX-4890-TEX;n:type:ShaderForge.SFN_Rotator,id:4278,x:32897,y:32444,varname:node_4278,prsc:2|UVIN-2422-UVOUT,ANG-2290-OUT;n:type:ShaderForge.SFN_Tex2d,id:3062,x:32535,y:32243,varname:node_3062,prsc:2,tex:f1729166a2f9bbc4084a80c9b211c01a,ntxv:0,isnm:False|UVIN-8021-UVOUT,TEX-4890-TEX;n:type:ShaderForge.SFN_Subtract,id:8410,x:31874,y:32483,varname:node_8410,prsc:2|A-2422-UVOUT,B-2783-OUT;n:type:ShaderForge.SFN_Vector1,id:2783,x:31653,y:32880,varname:node_2783,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Divide,id:8299,x:32047,y:32483,varname:node_8299,prsc:2|A-8410-OUT,B-2783-OUT;n:type:ShaderForge.SFN_Abs,id:1911,x:32213,y:32483,varname:node_1911,prsc:2|IN-8299-OUT;n:type:ShaderForge.SFN_Length,id:5194,x:32382,y:32483,varname:node_5194,prsc:2|IN-1911-OUT;n:type:ShaderForge.SFN_OneMinus,id:8768,x:32549,y:32483,varname:node_8768,prsc:2|IN-5194-OUT;n:type:ShaderForge.SFN_Multiply,id:2290,x:32727,y:32483,varname:node_2290,prsc:2|A-8768-OUT,B-5566-OUT,C-3062-A;n:type:ShaderForge.SFN_Panner,id:8021,x:32312,y:32243,varname:node_8021,prsc:2,spu:0,spv:-0.1|UVIN-2422-UVOUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4890,x:32312,y:32070,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_4890,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f1729166a2f9bbc4084a80c9b211c01a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3491,x:33556,y:32132,varname:node_3491,prsc:2|A-1210-RGB,B-2593-A,C-5518-OUT;n:type:ShaderForge.SFN_Vector1,id:5566,x:32576,y:32875,varname:node_5566,prsc:2,v1:3.14;n:type:ShaderForge.SFN_Tex2dAsset,id:1223,x:33204,y:33026,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_1223,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:42408fd0e2c85a142a7664bf1f680a72,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1210,x:33625,y:32955,varname:node_1210,prsc:2,tex:42408fd0e2c85a142a7664bf1f680a72,ntxv:0,isnm:False|UVIN-1389-OUT,TEX-1223-TEX;n:type:ShaderForge.SFN_Append,id:1389,x:33397,y:32807,varname:node_1389,prsc:2|A-2593-R,B-9617-OUT;n:type:ShaderForge.SFN_Vector1,id:9617,x:33224,y:32853,varname:node_9617,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:3390,x:32868,y:32712,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_3390,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:5;n:type:ShaderForge.SFN_Clamp01,id:2923,x:33428,y:32438,varname:node_2923,prsc:2|IN-2593-R;n:type:ShaderForge.SFN_Multiply,id:5582,x:33637,y:32466,varname:node_5582,prsc:2|A-2923-OUT,B-3390-OUT;n:type:ShaderForge.SFN_Slider,id:4073,x:32809,y:32851,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_4073,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.923079,max:4;n:type:ShaderForge.SFN_Multiply,id:5518,x:33237,y:32718,varname:node_5518,prsc:2|A-3390-OUT,B-4073-OUT;n:type:ShaderForge.SFN_Panner,id:8503,x:33002,y:32084,varname:node_8503,prsc:2,spu:0,spv:0.05|UVIN-4278-UVOUT;proporder:4890-1223-3390-4073;pass:END;sub:END;*/

Shader "Shader Forge/Poison" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Ramp ("Ramp", 2D) = "white" {}
        _Alpha ("Alpha", Range(0, 5)) = 5
        _Intensity ("Intensity", Range(0, 4)) = 0.923079
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _Alpha;
            uniform float _Intensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_7805 = _Time + _TimeEditor;
                float node_2783 = 0.5;
                float2 node_8021 = (i.uv0+node_7805.g*float2(0,-0.1));
                float4 node_3062 = tex2D(_MainTexture,TRANSFORM_TEX(node_8021, _MainTexture));
                float node_4278_ang = ((1.0 - length(abs(((i.uv0-node_2783)/node_2783))))*3.14*node_3062.a);
                float node_4278_spd = 1.0;
                float node_4278_cos = cos(node_4278_spd*node_4278_ang);
                float node_4278_sin = sin(node_4278_spd*node_4278_ang);
                float2 node_4278_piv = float2(0.5,0.5);
                float2 node_4278 = (mul(i.uv0-node_4278_piv,float2x2( node_4278_cos, -node_4278_sin, node_4278_sin, node_4278_cos))+node_4278_piv);
                float2 node_8503 = (node_4278+node_7805.g*float2(0,0.05));
                float4 node_2593 = tex2D(_MainTexture,TRANSFORM_TEX(node_8503, _MainTexture));
                float2 node_1389 = float2(node_2593.r,0.0);
                float4 node_1210 = tex2D(_Ramp,TRANSFORM_TEX(node_1389, _Ramp));
                float3 emissive = (node_1210.rgb*node_2593.a*(_Alpha*_Intensity));
                float3 finalColor = emissive;
                return fixed4(finalColor,(saturate(node_2593.r)*_Alpha));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
