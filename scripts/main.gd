extends Node2D

@export var boid_scene: PackedScene = preload("res://scenes/boid.tscn")
@export var num_boids := 100
@onready var predator: Predator = $predator


var boids := []

func _ready():
	boids.append(predator)
	for i in num_boids:
		var boid = boid_scene.instantiate()
		add_child(boid)
		boid.position = Vector2(randf() * get_viewport_rect().size.x, randf() * get_viewport_rect().size.y)
		boids.append(boid)

	for boid in boids:
		boid.all_boids = boids
