// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:5,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33358,y:32455,varname:node_4795,prsc:2|emission-8936-OUT,alpha-4603-A,clip-8857-OUT;n:type:ShaderForge.SFN_Add,id:2602,x:33068,y:32563,varname:node_2602,prsc:2|A-8784-RGB,B-9629-OUT,C-4148-OUT;n:type:ShaderForge.SFN_TexCoord,id:3594,x:31712,y:32552,varname:node_3594,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:8784,x:32608,y:32288,ptovrint:False,ptlb:Sprite,ptin:_Sprite,varname:node_8784,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:22736529c28cc744ca489d8074bb0d1b,ntxv:0,isnm:False|MIP-8255-OUT;n:type:ShaderForge.SFN_Tex2d,id:7039,x:32464,y:32673,ptovrint:False,ptlb:Pattern,ptin:_Pattern,varname:node_7039,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d9abdea87b09c87489f3e2ab25b1ba68,ntxv:0,isnm:False|UVIN-7174-UVOUT,MIP-8255-OUT;n:type:ShaderForge.SFN_Panner,id:7174,x:32135,y:32568,varname:node_7174,prsc:2,spu:0,spv:-0.05|UVIN-3594-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9654,x:32479,y:32473,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_9654,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:263465f3c7d94cf478962f4df62c9510,ntxv:0,isnm:False|MIP-8255-OUT;n:type:ShaderForge.SFN_Multiply,id:9629,x:32788,y:32602,varname:node_9629,prsc:2|A-9654-RGB,B-7039-RGB,C-1541-RGB;n:type:ShaderForge.SFN_ComponentMask,id:5319,x:32043,y:32925,varname:node_5319,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-3594-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:4064,x:32043,y:33068,varname:node_4064,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-3594-UVOUT;n:type:ShaderForge.SFN_Blend,id:5316,x:32239,y:33021,varname:node_5316,prsc:2,blmd:17,clmp:True|SRC-5319-OUT,DST-4064-OUT;n:type:ShaderForge.SFN_OneMinus,id:5945,x:32412,y:33021,varname:node_5945,prsc:2|IN-5316-OUT;n:type:ShaderForge.SFN_Hue,id:5336,x:32590,y:33001,varname:node_5336,prsc:2|IN-5945-OUT;n:type:ShaderForge.SFN_Multiply,id:4148,x:32813,y:32812,varname:node_4148,prsc:2|A-9654-RGB,B-681-OUT,C-9814-OUT;n:type:ShaderForge.SFN_Vector1,id:9814,x:32628,y:33116,varname:node_9814,prsc:2,v1:0.199;n:type:ShaderForge.SFN_VertexColor,id:4603,x:33005,y:32295,varname:node_4603,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:824,x:32043,y:33259,ptovrint:False,ptlb:Dissolve Pattern,ptin:_DissolvePattern,varname:node_824,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:9111,x:31690,y:33427,ptovrint:False,ptlb:Clip Amount,ptin:_ClipAmount,varname:node_9111,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8299895,max:1;n:type:ShaderForge.SFN_RemapRange,id:6089,x:32043,y:33438,varname:node_6089,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:0.8|IN-9111-OUT;n:type:ShaderForge.SFN_Add,id:8857,x:32270,y:33376,varname:node_8857,prsc:2|A-824-R,B-6089-OUT;n:type:ShaderForge.SFN_RemapRange,id:946,x:32512,y:33358,varname:node_946,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-8857-OUT;n:type:ShaderForge.SFN_Clamp01,id:8357,x:32696,y:33358,varname:node_8357,prsc:2|IN-946-OUT;n:type:ShaderForge.SFN_OneMinus,id:925,x:32878,y:33346,varname:node_925,prsc:2|IN-8357-OUT;n:type:ShaderForge.SFN_Vector1,id:1473,x:32696,y:33537,varname:node_1473,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:6340,x:33058,y:33401,varname:node_6340,prsc:2|A-925-OUT,B-1473-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:5472,x:32950,y:33575,ptovrint:False,ptlb:Color Ramp,ptin:_ColorRamp,varname:node_5472,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6cf04b685304a99458bb2e0f6be0288c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5421,x:33239,y:33401,varname:node_5421,prsc:2,tex:6cf04b685304a99458bb2e0f6be0288c,ntxv:0,isnm:False|UVIN-6340-OUT,MIP-8255-OUT,TEX-5472-TEX;n:type:ShaderForge.SFN_Add,id:8936,x:33180,y:32973,varname:node_8936,prsc:2|A-2602-OUT,B-5421-RGB;n:type:ShaderForge.SFN_Vector1,id:8255,x:31566,y:33107,varname:node_8255,prsc:2,v1:1;n:type:ShaderForge.SFN_Color,id:9572,x:32412,y:32867,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9572,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.6689656,c4:1;n:type:ShaderForge.SFN_Multiply,id:681,x:32628,y:32855,varname:node_681,prsc:2|A-9572-RGB,B-5336-OUT,C-9572-A;n:type:ShaderForge.SFN_Tex2d,id:1541,x:32393,y:32148,ptovrint:False,ptlb:Second Pattern,ptin:_SecondPattern,varname:node_1541,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9171-UVOUT,MIP-8255-OUT;n:type:ShaderForge.SFN_Panner,id:9171,x:32018,y:32177,varname:node_9171,prsc:2,spu:-0.05,spv:0.03|UVIN-3594-UVOUT;proporder:8784-9654-7039-9572-824-9111-5472-1541;pass:END;sub:END;*/

Shader "Shader Forge/HeroicFrame" {
    Properties {
        _Sprite ("Sprite", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Pattern ("Pattern", 2D) = "white" {}
        _Color ("Color", Color) = (0,1,0.6689656,1)
        _DissolvePattern ("Dissolve Pattern", 2D) = "white" {}
        _ClipAmount ("Clip Amount", Range(0, 1)) = 0.8299895
        _ColorRamp ("Color Ramp", 2D) = "white" {}
        _SecondPattern ("Second Pattern", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Sprite; uniform float4 _Sprite_ST;
            uniform sampler2D _Pattern; uniform float4 _Pattern_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _DissolvePattern; uniform float4 _DissolvePattern_ST;
            uniform float _ClipAmount;
            uniform sampler2D _ColorRamp; uniform float4 _ColorRamp_ST;
            uniform float4 _Color;
            uniform sampler2D _SecondPattern; uniform float4 _SecondPattern_ST;
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
                float4 _DissolvePattern_var = tex2D(_DissolvePattern,TRANSFORM_TEX(i.uv0, _DissolvePattern));
                float node_8857 = (_DissolvePattern_var.r+(_ClipAmount*1.4+-0.6));
                clip(node_8857 - 0.5);
////// Lighting:
////// Emissive:
                float node_8255 = 1.0;
                float4 _Sprite_var = tex2Dlod(_Sprite,float4(TRANSFORM_TEX(i.uv0, _Sprite),0.0,node_8255));
                float4 _Mask_var = tex2Dlod(_Mask,float4(TRANSFORM_TEX(i.uv0, _Mask),0.0,node_8255));
                float4 node_2116 = _Time + _TimeEditor;
                float2 node_7174 = (i.uv0+node_2116.g*float2(0,-0.05));
                float4 _Pattern_var = tex2Dlod(_Pattern,float4(TRANSFORM_TEX(node_7174, _Pattern),0.0,node_8255));
                float2 node_9171 = (i.uv0+node_2116.g*float2(-0.05,0.03));
                float4 _SecondPattern_var = tex2Dlod(_SecondPattern,float4(TRANSFORM_TEX(node_9171, _SecondPattern),0.0,node_8255));
                float2 node_6340 = float2((1.0 - saturate((node_8857*8.0+-4.0))),0.0);
                float4 node_5421 = tex2Dlod(_ColorRamp,float4(TRANSFORM_TEX(node_6340, _ColorRamp),0.0,node_8255));
                float3 emissive = ((_Sprite_var.rgb+(_Mask_var.rgb*_Pattern_var.rgb*_SecondPattern_var.rgb)+(_Mask_var.rgb*(_Color.rgb*saturate(3.0*abs(1.0-2.0*frac((1.0 - saturate(abs(i.uv0.r-i.uv0.g)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1)*_Color.a)*0.199))+node_5421.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,i.vertexColor.a);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
