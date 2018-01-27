// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33318,y:32747,varname:node_3138,prsc:2|emission-3066-OUT,alpha-4234-OUT;n:type:ShaderForge.SFN_TexCoord,id:5890,x:31592,y:32976,varname:node_5890,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:1943,x:31924,y:32836,varname:node_1943,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5890-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:5139,x:31924,y:33013,varname:node_5139,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-5890-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:8811,x:32424,y:32945,varname:node_8811,prsc:2|IN-3894-OUT;n:type:ShaderForge.SFN_Min,id:3066,x:32606,y:32710,varname:node_3066,prsc:2|A-9993-OUT,B-8811-OUT;n:type:ShaderForge.SFN_OneMinus,id:5266,x:32773,y:32860,varname:node_5266,prsc:2|IN-3066-OUT;n:type:ShaderForge.SFN_RemapRange,id:4234,x:33010,y:32942,varname:node_4234,prsc:2,frmn:0,frmx:1,tomn:-7,tomx:1|IN-5266-OUT;n:type:ShaderForge.SFN_Max,id:3894,x:32217,y:33050,varname:node_3894,prsc:2|A-1943-OUT,B-5139-OUT;n:type:ShaderForge.SFN_Min,id:9993,x:32217,y:32803,varname:node_9993,prsc:2|A-1943-OUT,B-5139-OUT;pass:END;sub:END;*/

Shader "Shader Forge/GradientBackground" {
    Properties {
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
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
                float node_1943 = i.uv0.r;
                float node_5139 = i.uv0.g;
                float node_3066 = min(min(node_1943,node_5139),(1.0 - max(node_1943,node_5139)));
                float3 emissive = float3(node_3066,node_3066,node_3066);
                float3 finalColor = emissive;
                return fixed4(finalColor,((1.0 - node_3066)*8.0+-7.0));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
