extends ConditionLeaf

func tick(actor: Node, blackboard: Blackboard):
	for boid in actor.all_boids:
		if !is_instance_valid(boid):
			actor.all_boids.erase(boid)
			continue
		if boid.name == "predator":
			#print(actor.position.distance_to(boid.position))
			if actor.position.distance_to(boid.position) < actor.visual_range:
				return SUCCESS
	return FAILURE
