// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33886,y:32571,varname:node_3138,prsc:2|emission-3646-OUT,clip-7856-OUT;n:type:ShaderForge.SFN_Tex2d,id:9641,x:32515,y:32654,ptovrint:False,ptlb:Dissolve Pattern,ptin:_DissolvePattern,cmnt:dissolve pattern,varname:node_9641,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|MIP-7002-OUT;n:type:ShaderForge.SFN_Slider,id:2468,x:32368,y:32848,ptovrint:False,ptlb:Clip Amount,ptin:_ClipAmount,varname:node_2468,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5826238,max:1;n:type:ShaderForge.SFN_RemapRange,id:8164,x:32696,y:32904,varname:node_8164,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:0.8|IN-2468-OUT;n:type:ShaderForge.SFN_Add,id:7856,x:32868,y:32824,varname:node_7856,prsc:2|A-9641-R,B-8164-OUT;n:type:ShaderForge.SFN_Append,id:7684,x:33205,y:32533,varname:node_7684,prsc:2|A-6010-OUT,B-3753-OUT;n:type:ShaderForge.SFN_Clamp01,id:9420,x:32890,y:32371,varname:node_9420,prsc:2|IN-4657-OUT;n:type:ShaderForge.SFN_RemapRange,id:4657,x:32724,y:32371,varname:node_4657,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-7856-OUT;n:type:ShaderForge.SFN_Tex2d,id:2646,x:33307,y:32321,ptovrint:False,ptlb:Sprite,ptin:_Sprite,varname:node_2646,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b1df9f37a5da0234d95f76168cfaed91,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:6010,x:33066,y:32371,varname:node_6010,prsc:2|IN-9420-OUT;n:type:ShaderForge.SFN_Add,id:3646,x:33565,y:32421,varname:node_3646,prsc:2|A-2646-RGB,B-220-RGB;n:type:ShaderForge.SFN_Vector1,id:3753,x:33021,y:32567,varname:node_3753,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:5428,x:33148,y:32721,ptovrint:False,ptlb:Color Ramp,ptin:_ColorRamp,varname:node_5428,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:42408fd0e2c85a142a7664bf1f680a72,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:220,x:33373,y:32624,varname:node_220,prsc:2,tex:42408fd0e2c85a142a7664bf1f680a72,ntxv:0,isnm:False|UVIN-7684-OUT,TEX-5428-TEX;n:type:ShaderForge.SFN_Vector1,id:7002,x:32279,y:32732,varname:node_7002,prsc:2,v1:1;proporder:2646-9641-5428-2468;pass:END;sub:END;*/

Shader "Shader Forge/Dissolve" {
    Properties {
        _Sprite ("Sprite", 2D) = "white" {}
        _DissolvePattern ("Dissolve Pattern", 2D) = "white" {}
        _ColorRamp ("Color Ramp", 2D) = "white" {}
        _ClipAmount ("Clip Amount", Range(0, 1)) = 0.5826238
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform sampler2D _DissolvePattern; uniform float4 _DissolvePattern_ST;
            uniform float _ClipAmount;
            uniform sampler2D _Sprite; uniform float4 _Sprite_ST;
            uniform sampler2D _ColorRamp; uniform float4 _ColorRamp_ST;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _DissolvePattern_var = tex2Dlod(_DissolvePattern,float4(TRANSFORM_TEX(i.uv0, _DissolvePattern),0.0,1.0)); // dissolve pattern
                float node_7856 = (_DissolvePattern_var.r+(_ClipAmount*1.4+-0.6));
                clip(node_7856 - 0.5);
////// Lighting:
////// Emissive:
                float4 _Sprite_var = tex2D(_Sprite,TRANSFORM_TEX(i.uv0, _Sprite));
                float2 node_7684 = float2((1.0 - saturate((node_7856*8.0+-4.0))),0.0);
                float4 node_220 = tex2D(_ColorRamp,TRANSFORM_TEX(node_7684, _ColorRamp));
                float3 emissive = (_Sprite_var.rgb+node_220.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform sampler2D _DissolvePattern; uniform float4 _DissolvePattern_ST;
            uniform float _ClipAmount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _DissolvePattern_var = tex2Dlod(_DissolvePattern,float4(TRANSFORM_TEX(i.uv0, _DissolvePattern),0.0,1.0)); // dissolve pattern
                float node_7856 = (_DissolvePattern_var.r+(_ClipAmount*1.4+-0.6));
                clip(node_7856 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
