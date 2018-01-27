// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32940,y:32615,varname:node_4795,prsc:2|emission-7292-OUT,alpha-8529-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32601,ptovrint:False,ptlb:OverlayTexture,ptin:_OverlayTexture,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9c46c81f94babf24fafc2a975e1061f9,ntxv:0,isnm:False|UVIN-1480-OUT,MIP-9248-OUT;n:type:ShaderForge.SFN_Vector1,id:9248,x:32006,y:32505,varname:node_9248,prsc:2,v1:1;n:type:ShaderForge.SFN_Time,id:7226,x:31549,y:32364,varname:node_7226,prsc:2;n:type:ShaderForge.SFN_Append,id:2676,x:31549,y:32496,varname:node_2676,prsc:2|A-3526-OUT,B-8194-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3526,x:31358,y:32441,ptovrint:False,ptlb:USpeed,ptin:_USpeed,varname:node_3526,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-2;n:type:ShaderForge.SFN_ValueProperty,id:8194,x:31358,y:32559,ptovrint:False,ptlb:VSpeed,ptin:_VSpeed,varname:node_8194,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_TexCoord,id:7789,x:31764,y:32605,varname:node_7789,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:7292,x:32628,y:32482,varname:node_7292,prsc:2|A-1204-RGB,B-2780-OUT;n:type:ShaderForge.SFN_Multiply,id:2780,x:32424,y:32694,varname:node_2780,prsc:2|A-6074-RGB,B-6074-A;n:type:ShaderForge.SFN_Multiply,id:9698,x:31764,y:32471,varname:node_9698,prsc:2|A-7226-T,B-2676-OUT;n:type:ShaderForge.SFN_Add,id:1480,x:32006,y:32570,varname:node_1480,prsc:2|A-9698-OUT,B-7789-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1204,x:32235,y:32394,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_1204,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8f70e9551c0a35242917e9ec7f9a2565,ntxv:0,isnm:False|MIP-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:3348,x:32401,y:32219,varname:node_3348,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8529,x:32656,y:32285,varname:node_8529,prsc:2|A-3348-A,B-1204-A;proporder:1204-6074-3526-8194;pass:END;sub:END;*/

Shader "Shader Forge/SlidingEffectOverlay" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _OverlayTexture ("OverlayTexture", 2D) = "white" {}
        _USpeed ("USpeed", Float ) = -2
        _VSpeed ("VSpeed", Float ) = 0
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
            uniform sampler2D _OverlayTexture; uniform float4 _OverlayTexture_ST;
            uniform float _USpeed;
            uniform float _VSpeed;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
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
                float node_9248 = 1.0;
                float4 _MainTexture_var = tex2Dlod(_MainTexture,float4(TRANSFORM_TEX(i.uv0, _MainTexture),0.0,node_9248));
                float4 node_7226 = _Time + _TimeEditor;
                float2 node_1480 = ((node_7226.g*float2(_USpeed,_VSpeed))+i.uv0);
                float4 _OverlayTexture_var = tex2Dlod(_OverlayTexture,float4(TRANSFORM_TEX(node_1480, _OverlayTexture),0.0,node_9248));
                float3 emissive = (_MainTexture_var.rgb+(_OverlayTexture_var.rgb*_OverlayTexture_var.a));
                float3 finalColor = emissive;
                return fixed4(finalColor,(i.vertexColor.a*_MainTexture_var.a));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
