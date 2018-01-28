// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33361,y:32719,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32589,y:32916,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33077,y:32747,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-2290-RGB,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32855,y:32876,cmnt:A,varname:node_603,prsc:2|A-2290-A,B-5376-A;n:type:ShaderForge.SFN_TexCoord,id:6515,x:32211,y:32567,varname:node_6515,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3086,x:32015,y:32681,varname:node_3086,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5680,x:32211,y:32746,varname:node_5680,prsc:2|A-3086-T,B-9730-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4730,x:31649,y:32696,ptovrint:False,ptlb:ScrollSpeed,ptin:_ScrollSpeed,varname:node_4730,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Add,id:7819,x:32402,y:32652,varname:node_7819,prsc:2|A-6515-UVOUT,B-5680-OUT;n:type:ShaderForge.SFN_Append,id:9730,x:32015,y:32819,varname:node_9730,prsc:2|A-7140-OUT,B-3773-OUT;n:type:ShaderForge.SFN_Vector1,id:3773,x:31834,y:32863,varname:node_3773,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2552,x:32402,y:32807,varname:node_2552,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:7140,x:31834,y:32696,varname:node_7140,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.5|IN-4730-OUT;n:type:ShaderForge.SFN_Tex2d,id:2290,x:32653,y:32695,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_2290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cbf9e3733f65979429ba22315911e386,ntxv:0,isnm:False|UVIN-7819-OUT,MIP-2552-OUT;proporder:2290-4730;pass:END;sub:END;*/

Shader "Shader Forge/Parallax" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _ScrollSpeed ("ScrollSpeed", Float ) = 0.1
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform float _ScrollSpeed;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
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
                float4 node_3086 = _Time + _TimeEditor;
                float2 node_7819 = (i.uv0+(node_3086.g*float2((_ScrollSpeed*0.5+0.0),0.0)));
                float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(node_7819, _MainTex),0.0,1.0));
                float node_603 = (_MainTex_var.a*i.vertexColor.a); // A
                float3 emissive = (_MainTex_var.rgb*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
