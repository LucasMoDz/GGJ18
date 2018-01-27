// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33696,y:32530,varname:node_3138,prsc:2|emission-8054-OUT,alpha-7041-OUT;n:type:ShaderForge.SFN_Tex2d,id:6467,x:33043,y:32669,ptovrint:False,ptlb:AdditiveAlpha,ptin:_AdditiveAlpha,varname:node_6467,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:48f11275abd6c914b8948127c52c7a65,ntxv:0,isnm:False|UVIN-36-OUT,MIP-7539-OUT;n:type:ShaderForge.SFN_Tex2d,id:1164,x:33043,y:32489,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_1164,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28b32f7c2117bb84e9a566bad904caa9,ntxv:0,isnm:False|MIP-7539-OUT;n:type:ShaderForge.SFN_Add,id:8054,x:33491,y:32633,varname:node_8054,prsc:2|A-1164-RGB,B-2660-OUT;n:type:ShaderForge.SFN_TexCoord,id:7164,x:32652,y:32621,varname:node_7164,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:7539,x:32852,y:32582,varname:node_7539,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:2660,x:33249,y:32769,varname:node_2660,prsc:2|A-6467-A,B-1164-RGB,C-5337-RGB;n:type:ShaderForge.SFN_Time,id:1072,x:32431,y:32699,varname:node_1072,prsc:2;n:type:ShaderForge.SFN_Append,id:333,x:32431,y:32829,varname:node_333,prsc:2|A-1901-OUT,B-7147-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1901,x:32202,y:32802,ptovrint:False,ptlb:SpeedX,ptin:_SpeedX,varname:node_1901,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.1;n:type:ShaderForge.SFN_ValueProperty,id:7147,x:32202,y:32900,ptovrint:False,ptlb:SpeedY,ptin:_SpeedY,varname:node_7147,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:5269,x:32652,y:32775,varname:node_5269,prsc:2|A-1072-T,B-333-OUT;n:type:ShaderForge.SFN_Add,id:36,x:32852,y:32672,varname:node_36,prsc:2|A-7164-UVOUT,B-5269-OUT;n:type:ShaderForge.SFN_VertexColor,id:5337,x:33043,y:32331,varname:node_5337,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7041,x:33491,y:32758,varname:node_7041,prsc:2|A-5337-A,B-1164-A;proporder:1164-6467-1901-7147;pass:END;sub:END;*/

Shader "Shader Forge/AnimatedTextureAdded" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _AdditiveAlpha ("AdditiveAlpha", 2D) = "white" {}
        _SpeedX ("SpeedX", Float ) = -0.1
        _SpeedY ("SpeedY", Float ) = 0
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
            uniform sampler2D _AdditiveAlpha; uniform float4 _AdditiveAlpha_ST;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _SpeedX;
            uniform float _SpeedY;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float node_7539 = 1.0;
                float4 _MainTexture_var = tex2Dlod(_MainTexture,float4(TRANSFORM_TEX(i.uv0, _MainTexture),0.0,node_7539));
                float4 node_1072 = _Time + _TimeEditor;
                float2 node_36 = (i.uv0+(node_1072.g*float2(_SpeedX,_SpeedY)));
                float4 _AdditiveAlpha_var = tex2Dlod(_AdditiveAlpha,float4(TRANSFORM_TEX(node_36, _AdditiveAlpha),0.0,node_7539));
                float3 emissive = (_MainTexture_var.rgb+(_AdditiveAlpha_var.a*_MainTexture_var.rgb*i.vertexColor.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,(i.vertexColor.a*_MainTexture_var.a));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
