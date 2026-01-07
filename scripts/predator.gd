extends Node2D
class_name Predator

@export var visual_range := 175.0
@export var min_distance := 2.0
@export var speed_limit := 150.0
@export var avoid_factor := 50.0
@export var center_factor := 0.01
@export var match_factor := 0.001
@export var bounds_margin := 50.0
@export var bounds_force := 100.0

var velocity := Vector2.ZERO
var all_boids := []

func _ready():
	# Start with a random direction
	velocity = Vector2(randf_range(-1, 1), randf_range(-1, 1)).normalized() * speed_limit

func _process(delta):
	if all_boids.is_empty():
		return

	var center = Vector2.ZERO
	var avoid = Vector2.ZERO
	var avg_velocity = Vector2.ZERO
	var count = 0

	for other in all_boids:
		if !is_instance_valid(other):
			all_boids.erase(other)
			continue
		
		if other == self:
			continue
		var dist = position.distance_to(other.position)
		if dist < visual_range:
			center += other.position
			avg_velocity += other.velocity
			count += 1
			if dist < min_distance:
				avoid += (position - other.position).normalized()

	if count > 0:
		center = center / count
		avg_velocity = avg_velocity / count
		velocity += (center - position) * center_factor
		velocity += avoid * avoid_factor
		velocity += (avg_velocity - velocity) * match_factor

	_keep_within_bounds()
	_limit_speed()

	position += velocity * delta
	rotation = velocity.angle()

func _keep_within_bounds():
	var screen_size = get_viewport_rect().size
	if position.x < bounds_margin:
		velocity.x += bounds_force
	elif position.x > screen_size.x - bounds_margin:
		velocity.x -= bounds_force
	if position.y < bounds_margin:
		velocity.y += bounds_force
	elif position.y > screen_size.y - bounds_margin:
		velocity.y -= bounds_force

func _limit_speed():
	if velocity.length() > speed_limit:
		velocity = velocity.normalized() * speed_limit



func _on_area_2d_area_entered(area: Area2D) -> void:
	if !area.get_parent() == Predator:
		area.get_parent().queue_free()
