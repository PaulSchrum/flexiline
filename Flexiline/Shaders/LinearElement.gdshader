shader_type spatial;
render_mode unshaded, cull_disabled;

uniform vec3 p1 = vec3(0.0, 0.0, 0.0);
uniform vec3 p2 = vec3(2.0, 0.0, 0.0);

uniform vec4 line_color : source_color = vec4(1.0, 0.0, 0.0, 1.0);
uniform float line_width_pixels = 1.0;

varying vec2 capsule_position;
varying float capsule_length;
varying float capsule_radius;

void vertex()
{
    float along = VERTEX.x + 0.5;
    float across = VERTEX.y;

    vec4 p1_clip =
        PROJECTION_MATRIX * MODELVIEW_MATRIX * vec4(p1, 1.0);
    vec4 p2_clip =
        PROJECTION_MATRIX * MODELVIEW_MATRIX * vec4(p2, 1.0);

    vec2 p1_ndc = p1_clip.xy / p1_clip.w;
    vec2 p2_ndc = p2_clip.xy / p2_clip.w;

    vec2 p1_pixels = (p1_ndc * 0.5 + 0.5) * VIEWPORT_SIZE;
    vec2 p2_pixels = (p2_ndc * 0.5 + 0.5) * VIEWPORT_SIZE;

    vec2 projected_vector = p2_pixels - p1_pixels;
    float projected_length = length(projected_vector);
    vec2 line_direction = vec2(1.0, 0.0);

    if (projected_length > 0.000001)
    { line_direction = projected_vector / projected_length; }

    vec2 perpendicular = vec2(-line_direction.y, line_direction.x);
    float radius = line_width_pixels * 0.5;

    vec2 center_pixels = mix(p1_pixels, p2_pixels, along);
    center_pixels += line_direction * ((along * 2.0 - 1.0) * radius);
    center_pixels += perpendicular * across * line_width_pixels;

    vec2 center_ndc =
        center_pixels * 2.0 / VIEWPORT_SIZE - vec2(1.0);

    vec4 center_clip = mix(p1_clip, p2_clip, along);
    center_clip.xy = center_ndc * center_clip.w;

    capsule_position = vec2(
        mix(-radius, projected_length + radius, along),
        across * line_width_pixels
    );

    capsule_length = projected_length;
    capsule_radius = radius;

    POSITION = center_clip;
}

void fragment()
{
    float x = clamp(
        capsule_position.x,
        0.0,
        capsule_length
    );

    vec2 nearest = vec2(x, 0.0);
    float distance_to_segment =
        length(capsule_position - nearest);

    if (distance_to_segment > capsule_radius)
    { discard; }

    ALBEDO = line_color.rgb;
}
