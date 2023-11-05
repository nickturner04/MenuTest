shader_type spatial;
render_mode blend_mix,depth_draw_opaque,cull_back,diffuse_burley,specular_schlick_ggx;
uniform float transparency : hint_range(0.0, 1.0);
uniform sampler2D texture_albedo : source_color,repeat_enable;

float DitherFloat(float In, int x, int y)
{
    float DITHER_THRESHOLDS[16] =
    {
        1.0 / 17.0,  9.0 / 17.0,  3.0 / 17.0, 11.0 / 17.0,
        13.0 / 17.0,  5.0 / 17.0, 15.0 / 17.0,  7.0 / 17.0,
        4.0 / 17.0, 12.0 / 17.0,  2.0 / 17.0, 10.0 / 17.0,
        16.0 / 17.0,  8.0 / 17.0, 14.0 / 17.0,  6.0 / 17.0
    };
    uint index = (uint(x) % 4u) * 4u + uint(y) % 4u;
    return In - DITHER_THRESHOLDS[index];
}

void fragment() {
	vec2 base_uv = UV;
	vec4 albedo_tex = texture(texture_albedo,base_uv);
	ALBEDO = albedo_tex.rgb;
	
	float limit = DitherFloat(1,int(FRAGCOORD.x),int(FRAGCOORD.y));
	if(limit > transparency){
		discard;
	}
}
