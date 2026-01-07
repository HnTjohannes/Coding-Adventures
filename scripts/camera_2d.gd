extends Camera2D

@export var target: Node2D

func _ready() -> void:
	if not target:
		target = get_parent()


func _process(delta: float) -> void:
	global_position = target.global_position
