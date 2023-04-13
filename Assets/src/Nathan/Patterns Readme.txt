The two main design patterns that my code employs are:
    Prototyes
    Strategies
Both of these pertain to the Entity-Enemy-etc subclass-superclass structure.

The Enemies employ strategies, all enemies have some form of "EnemyAttack" function, 
but depening on which enemy that is, the default attack (do nothing) will be overridden with somne other behavior.

The Prototyesare employed by the clone function. The Ambush prefab demonstrates this function in action. 
It takes an enemy prefab and calls the clone function, which in turn runs its instantiation function.
