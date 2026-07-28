shader_type spatial;
render_mode unshaded;

uniform vec3 p1 = vec3(0.0, 0.0, 0.0);
uniform vec3 p2 = vec3(2.0, 0.0, 0.0);

void vertex()
{
    float half_width = 0.05;

    float along = VERTEX.x + 0.5;
    float across = VERTEX.y;

    vec3 center = mix(p1, p2, along);
    vec3 offset = vec3(0.0, across * half_width * 2.0, 0.0);

    VERTEX = center + offset;
}

void fragment()
{
    ALBEDO = vec3(1.0, 0.0, 0.0);
}