// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:0,trmd:1,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34401,y:32487,varname:node_3138,prsc:2|emission-6843-OUT,alpha-2984-OUT;n:type:ShaderForge.SFN_Tex2d,id:6562,x:33639,y:32602,varname:node_6562,prsc:2,tex:70ab475ce896842459aeca85544f8f21,ntxv:2,isnm:False|UVIN-4411-OUT,MIP-7316-OUT,TEX-8924-TEX;n:type:ShaderForge.SFN_TexCoord,id:6207,x:32522,y:32525,varname:node_6207,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:7,x:32954,y:32434,ptovrint:False,ptlb:Pattern,ptin:_Pattern,varname:node_7,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:39ba91724e012544d8edaebf1ceb13a7,ntxv:0,isnm:False|UVIN-8469-OUT;n:type:ShaderForge.SFN_Add,id:4411,x:33311,y:32593,varname:node_4411,prsc:2|A-6207-UVOUT,B-5329-OUT;n:type:ShaderForge.SFN_Vector1,id:7316,x:33075,y:32857,varname:node_7316,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:5329,x:33119,y:32642,varname:node_5329,prsc:2|A-7-R,B-2435-OUT;n:type:ShaderForge.SFN_Slider,id:2435,x:32623,y:32730,ptovrint:False,ptlb:Distortion Intensity,ptin:_DistortionIntensity,varname:node_2435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.08596755,max:0.1;n:type:ShaderForge.SFN_Time,id:9699,x:32308,y:32434,varname:node_9699,prsc:2;n:type:ShaderForge.SFN_Multiply,id:852,x:32522,y:32370,varname:node_852,prsc:2|A-1409-OUT,B-9699-T;n:type:ShaderForge.SFN_Append,id:1409,x:32308,y:32280,varname:node_1409,prsc:2|A-208-OUT,B-9524-OUT;n:type:ShaderForge.SFN_Add,id:8469,x:32788,y:32434,varname:node_8469,prsc:2|A-852-OUT,B-6207-UVOUT;n:type:ShaderForge.SFN_Slider,id:208,x:31918,y:32281,ptovrint:False,ptlb:USpeed,ptin:_USpeed,varname:node_208,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:0,max:0.5;n:type:ShaderForge.SFN_Slider,id:9524,x:31918,y:32378,ptovrint:False,ptlb:VSpeed,ptin:_VSpeed,varname:node_9524,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:0,max:0.5;n:type:ShaderForge.SFN_Color,id:8928,x:33247,y:32157,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_8928,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5147059,c2:0.9799188,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:5084,x:33995,y:32332,varname:node_5084,prsc:2|A-7697-OUT,B-6562-RGB;n:type:ShaderForge.SFN_ComponentMask,id:2827,x:33414,y:32917,varname:node_2827,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-4411-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:7263,x:33667,y:33060,varname:node_7263,prsc:2|IN-2827-OUT,IMIN-570-OUT,IMAX-4765-OUT,OMIN-2690-OUT,OMAX-6432-OUT;n:type:ShaderForge.SFN_Vector1,id:570,x:33414,y:33080,varname:node_570,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:4765,x:33414,y:33145,varname:node_4765,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:6843,x:34206,y:32548,varname:node_6843,prsc:2|A-5084-OUT,B-7038-OUT,C-6562-A;n:type:ShaderForge.SFN_Multiply,id:2984,x:33988,y:32744,varname:node_2984,prsc:2|A-8992-A,B-5414-OUT,C-6562-A;n:type:ShaderForge.SFN_Clamp,id:7038,x:33995,y:32465,varname:node_7038,prsc:2|IN-2984-OUT,MIN-570-OUT,MAX-4765-OUT;n:type:ShaderForge.SFN_Tex2d,id:8992,x:33629,y:32804,varname:node_8992,prsc:2,tex:70ab475ce896842459aeca85544f8f21,ntxv:0,isnm:False|MIP-7316-OUT,TEX-8924-TEX;n:type:ShaderForge.SFN_Slider,id:790,x:32761,y:33346,ptovrint:False,ptlb:Fill Amount,ptin:_FillAmount,varname:node_790,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4965351,max:1;n:type:ShaderForge.SFN_OneMinus,id:8189,x:33193,y:33444,varname:node_8189,prsc:2|IN-790-OUT;n:type:ShaderForge.SFN_OneMinus,id:5414,x:33851,y:33060,varname:node_5414,prsc:2|IN-7263-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:2690,x:33400,y:33283,varname:node_2690,prsc:2,a:0,b:-100|IN-790-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:6432,x:33400,y:33444,varname:node_6432,prsc:2,a:1,b:100|IN-8189-OUT;n:type:ShaderForge.SFN_Multiply,id:7697,x:33609,y:32255,varname:node_7697,prsc:2|A-8928-RGB,B-7-RGB,C-8928-A;n:type:ShaderForge.SFN_Tex2dAsset,id:8924,x:32995,y:33016,ptovrint:False,ptlb:Sprite,ptin:_Sprite,varname:node_8924,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:70ab475ce896842459aeca85544f8f21,ntxv:0,isnm:False;proporder:7-2435-208-9524-8928-790-8924;pass:END;sub:END;*/

Shader "Shader Forge/Distortion" {
    Properties {
        _Pattern ("Pattern", 2D) = "white" {}
        _DistortionIntensity ("Distortion Intensity", Range(0, 0.1)) = 0.08596755
        _USpeed ("USpeed", Range(-0.5, 0.5)) = 0
        _VSpeed ("VSpeed", Range(-0.5, 0.5)) = 0
        _Color ("Color", Color) = (0.5147059,0.9799188,1,1)
        _FillAmount ("Fill Amount", Range(0, 1)) = 0.4965351
        _Sprite ("Sprite", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Pattern; uniform float4 _Pattern_ST;
            uniform float _DistortionIntensity;
            uniform float _USpeed;
            uniform float _VSpeed;
            uniform float4 _Color;
            uniform float _FillAmount;
            uniform sampler2D _Sprite; uniform float4 _Sprite_ST;
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
////// Lighting:
////// Emissive:
                float4 node_9699 = _Time + _TimeEditor;
                float2 node_8469 = ((float2(_USpeed,_VSpeed)*node_9699.g)+i.uv0);
                float4 _Pattern_var = tex2D(_Pattern,TRANSFORM_TEX(node_8469, _Pattern));
                float2 node_4411 = (i.uv0+(_Pattern_var.r*_DistortionIntensity));
                float node_7316 = 1.0;
                float4 node_6562 = tex2Dlod(_Sprite,float4(TRANSFORM_TEX(node_4411, _Sprite),0.0,node_7316));
                float4 node_8992 = tex2Dlod(_Sprite,float4(TRANSFORM_TEX(i.uv0, _Sprite),0.0,node_7316));
                float node_570 = 0.0;
                float node_4765 = 1.0;
                float node_2690 = lerp(0,-100,_FillAmount);
                float node_2984 = (node_8992.a*(1.0 - (node_2690 + ( (node_4411.g - node_570) * (lerp(1,100,(1.0 - _FillAmount)) - node_2690) ) / (node_4765 - node_570)))*node_6562.a);
                float3 emissive = (((_Color.rgb*_Pattern_var.rgb*_Color.a)+node_6562.rgb)*clamp(node_2984,node_570,node_4765)*node_6562.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_2984);
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
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
