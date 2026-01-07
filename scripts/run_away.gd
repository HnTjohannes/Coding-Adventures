extends ActionLeaf

func tick(actor: Node, blackboard: Blackboard):
	for boid in actor.all_boids:
		if boid.name == "predator":
			if actor.position.distance_to(boid.position) < actor.visual_range:
				var direction = -(actor.global_position.direction_to(boid.global_position))
				actor.rotation = direction.angle()
				actor.position += direction * actor.speed_limit * get_physics_process_delta_time()
				return SUCCESS
	return FAILURE
