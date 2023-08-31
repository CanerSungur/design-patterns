Singleton ensures that a class has only one instance and provides a global point of access to that instance.

It's useful for managing resources or services that should exist only once in your game. It persists across scenes, and adresses potential race issues using a lock.

BENEFITS;
- Maintain a single instance of a class throughout the game lifescycle
- Easily access shared resources or services
- Reduce the need for passing references between scripts

WARNING;
It can lead to tight coupling and make your code harder to maintain if overused. Apply it only when a single instance is truly necessary.
