using System;
using Unity.Behavior;

[BlackboardEnum]
public enum State
{
	Patrol,
	SeekLeak,
	Escaping,
	Escaped
}
