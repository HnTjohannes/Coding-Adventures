extends ActionLeaf

func tick(actor: Node, blackboard: Blackboard):
	actor.flocking()
	return SUCCESS
