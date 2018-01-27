// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33080,y:32686,varname:node_4795,prsc:2|emission-2393-OUT,alpha-798-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32080,y:32412,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cfa42eb391095134ba78dd00451c149d,ntxv:0,isnm:False|MIP-2859-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32851,y:32609,varname:node_2393,prsc:2|A-797-RGB,B-2053-RGB,C-797-RGB,D-7901-OUT,E-798-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32395,y:32487,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32627,y:32329,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.7426471,c3:0.7426471,c4:1;n:type:ShaderForge.SFN_Multiply,id:798,x:32744,y:33048,varname:node_798,prsc:2|A-6074-A,B-6486-A;n:type:ShaderForge.SFN_ValueProperty,id:7901,x:32366,y:32408,ptovrint:False,ptlb:Additive Factor,ptin:_AdditiveFactor,varname:node_7901,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_TexCoord,id:7087,x:31471,y:32745,varname:node_7087,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:6486,x:32190,y:32888,ptovrint:False,ptlb:RotatingTexture,ptin:_RotatingTexture,varname:node_6486,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c33fa018ad6566441ae68015d80952f7,ntxv:0,isnm:False|UVIN-873-UVOUT,MIP-2859-OUT;n:type:ShaderForge.SFN_Vector1,id:2859,x:31842,y:32786,varname:node_2859,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:2621,x:31524,y:33031,ptovrint:False,ptlb:Rotation Speed,ptin:_RotationSpeed,varname:node_2621,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Rotator,id:873,x:31842,y:32909,varname:node_873,prsc:2|UVIN-7087-UVOUT,SPD-2621-OUT;proporder:797-7901-6074-6486-2621;pass:END;sub:END;*/

Shader "Shader Forge/RotateAndPan" {
    Properties {
        _TintColor ("Color", Color) = (1,0.7426471,0.7426471,1)
        _AdditiveFactor ("Additive Factor", Float ) = 2
        _Alpha ("Alpha", 2D) = "white" {}
        _RotatingTexture ("RotatingTexture", 2D) = "white" {}
        _RotationSpeed ("Rotation Speed", Float ) = 0.5
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
            Blend One OneMinusSrcAlpha
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
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform float4 _TintColor;
            uniform float _AdditiveFactor;
            uniform sampler2D _RotatingTexture; uniform float4 _RotatingTexture_ST;
            uniform float _RotationSpeed;
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
                float node_2859 = 1.0;
                float4 _Alpha_var = tex2Dlod(_Alpha,float4(TRANSFORM_TEX(i.uv0, _Alpha),0.0,node_2859));
                float4 node_721 = _Time + _TimeEditor;
                float node_873_ang = node_721.g;
                float node_873_spd = _RotationSpeed;
                float node_873_cos = cos(node_873_spd*node_873_ang);
                float node_873_sin = sin(node_873_spd*node_873_ang);
                float2 node_873_piv = float2(0.5,0.5);
                float2 node_873 = (mul(i.uv0-node_873_piv,float2x2( node_873_cos, -node_873_sin, node_873_sin, node_873_cos))+node_873_piv);
                float4 _RotatingTexture_var = tex2Dlod(_RotatingTexture,float4(TRANSFORM_TEX(node_873, _RotatingTexture),0.0,node_2859));
                float node_798 = (_Alpha_var.a*_RotatingTexture_var.a);
                float3 emissive = (_TintColor.rgb*i.vertexColor.rgb*_TintColor.rgb*_AdditiveFactor*node_798);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_798);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
