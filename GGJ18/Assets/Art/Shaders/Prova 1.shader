// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:0,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33808,y:32870,varname:node_4013,prsc:2|emission-2497-OUT,alpha-5964-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:33271,y:32650,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2352941,c2:0.5569979,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:191,x:33014,y:32957,ptovrint:False,ptlb:Pattern1,ptin:_Pattern1,varname:_Pattern1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d2c20fe21b682bd4f965300793af525b,ntxv:0,isnm:False|UVIN-8283-UVOUT,MIP-9083-OUT;n:type:ShaderForge.SFN_Tex2d,id:5387,x:33010,y:33353,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:_Alpha,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4771490e6168d1e4d9f50352740bfe59,ntxv:2,isnm:False|MIP-9083-OUT;n:type:ShaderForge.SFN_Multiply,id:5964,x:33271,y:33127,cmnt:Multiply all alphas,varname:node_5964,prsc:2|A-9830-A,B-191-A,C-7209-A,D-5387-A,E-7508-A;n:type:ShaderForge.SFN_Tex2d,id:7209,x:33010,y:33155,ptovrint:False,ptlb:Pattern2,ptin:_Pattern2,varname:_Pattern2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d2c20fe21b682bd4f965300793af525b,ntxv:0,isnm:False|UVIN-3991-OUT,MIP-9083-OUT;n:type:ShaderForge.SFN_Multiply,id:2497,x:33448,y:32845,cmnt:Decide final color,varname:node_2497,prsc:2|A-1304-RGB,B-645-OUT,C-5964-OUT,D-9830-RGB;n:type:ShaderForge.SFN_ValueProperty,id:645,x:33271,y:32820,ptovrint:False,ptlb:Additive Factor,ptin:_AdditiveFactor,varname:_AdditiveFactor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_VertexColor,id:9830,x:33014,y:32801,varname:node_9830,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:8356,x:32381,y:32976,varname:node_8356,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:9083,x:32798,y:33112,varname:node_9083,prsc:2,v1:1;n:type:ShaderForge.SFN_Time,id:1026,x:32180,y:33205,varname:node_1026,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:8737,x:31929,y:33146,ptovrint:False,ptlb:V Speed,ptin:_VSpeed,varname:node_8737,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:1779,x:31929,y:33055,ptovrint:False,ptlb:U Speed,ptin:_USpeed,varname:node_1779,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Append,id:8026,x:32180,y:33055,varname:node_8026,prsc:2|A-1779-OUT,B-8737-OUT;n:type:ShaderForge.SFN_Multiply,id:1293,x:32381,y:33161,varname:node_1293,prsc:2|A-8026-OUT,B-1026-T;n:type:ShaderForge.SFN_Add,id:3991,x:32707,y:33286,varname:node_3991,prsc:2|A-8356-UVOUT,B-1293-OUT;n:type:ShaderForge.SFN_Panner,id:8283,x:32778,y:32885,varname:node_8283,prsc:2,spu:0,spv:-0.2|UVIN-8356-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7508,x:33014,y:32645,ptovrint:False,ptlb:node_7508,ptin:_node_7508,varname:node_7508,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:4771490e6168d1e4d9f50352740bfe59,ntxv:0,isnm:False|MIP-9083-OUT;proporder:191-7209-5387-1304-645-8737-1779-7508;pass:END;sub:END;*/

Shader "Shader Forge/Prova" {
    Properties {
        _Pattern1 ("Pattern1", 2D) = "white" {}
        _Pattern2 ("Pattern2", 2D) = "white" {}
        _Alpha ("Alpha", 2D) = "black" {}
        _Color ("Color", Color) = (0.2352941,0.5569979,1,1)
        _AdditiveFactor ("Additive Factor", Float ) = 2
        _VSpeed ("V Speed", Float ) = 0.1
        _USpeed ("U Speed", Float ) = 0.1
        [PerRendererData]_node_7508 ("node_7508", 2D) = "white" {}
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
            Blend One OneMinusSrcAlpha
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
            uniform float4 _Color;
            uniform sampler2D _Pattern1; uniform float4 _Pattern1_ST;
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform sampler2D _Pattern2; uniform float4 _Pattern2_ST;
            uniform float _AdditiveFactor;
            uniform float _VSpeed;
            uniform float _USpeed;
            uniform sampler2D _node_7508; uniform float4 _node_7508_ST;
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
                float4 node_3105 = _Time + _TimeEditor;
                float2 node_8283 = (i.uv0+node_3105.g*float2(0,-0.2));
                float node_9083 = 1.0;
                float4 _Pattern1_var = tex2Dlod(_Pattern1,float4(TRANSFORM_TEX(node_8283, _Pattern1),0.0,node_9083));
                float4 node_1026 = _Time + _TimeEditor;
                float2 node_3991 = (i.uv0+(float2(_USpeed,_VSpeed)*node_1026.g));
                float4 _Pattern2_var = tex2Dlod(_Pattern2,float4(TRANSFORM_TEX(node_3991, _Pattern2),0.0,node_9083));
                float4 _Alpha_var = tex2Dlod(_Alpha,float4(TRANSFORM_TEX(i.uv0, _Alpha),0.0,node_9083));
                float4 _node_7508_var = tex2Dlod(_node_7508,float4(TRANSFORM_TEX(i.uv0, _node_7508),0.0,node_9083));
                float node_5964 = (i.vertexColor.a*_Pattern1_var.a*_Pattern2_var.a*_Alpha_var.a*_node_7508_var.a); // Multiply all alphas
                float3 emissive = (_Color.rgb*_AdditiveFactor*node_5964*i.vertexColor.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_5964);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
