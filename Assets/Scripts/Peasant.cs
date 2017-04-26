using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : Enemy {

	new void Start() {
		base.food = 1;
		base.damage = 0;
	}
}
