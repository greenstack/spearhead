# Spearhead
Spearhead is a framework designed to simplify the implementation and development of turn-based games, especially those with dynamic systems. It's probably overkill for something like Balatro, but should be good for tactics games, etc.

## Table of Contents
- [Getting Started](#getting-started)
    - [Installation](#installation)
    - [Your First Battle](#your-first-battle)
- [Battles](#battles)
    - [Contexts](#contexts)
    - [Action Management](#action-management)
    - [Phase Management](#phase-management)
- [Games Using Spearhead](#games-using-spearhead)
- [Roadmap](#roadmap)

## Getting Started
Right now, Spearhead is only available directly from code. As the API becomes more mature, Nuget packages may be released in the future. Until then though, you'll want to include Spearhead as a git submodule.

### Installation
1. Add Spearhead as a submodule: `git submodule add git@github.com:greenstack/spearhead.git`
2. Add a reference to Spearhead to your main project: `dotnet add reference <path-to-Spearhead>/src/Spearhead.csproj`

### Your First Battle
1. To set up a battle, you will first need to create a simple `Phase`: 
```csharp
using Spearhead;

public class MyPhase : PhaseBase
{
    public override void BeginPhase(IPhaseManager phaseManager) {}

    public override void EndPhase(IPhaseManager phaseManager) {}

    public override void Update(IPhaseManager phaseManager){}
}
```
For more information on Phase Management, see below.

2. Create your context object. This can be anything, but for this example, we'll call it `MyContext`.
3. Create your Phase Manager:
```csharp
using Spearhead;

public MyPhaseManager : RoundRobinPhaseManager<MyContext, MyPhase>
{
    public MyPhaseManager() : base(null, [new MyPhase()], null) {}
}
```
4. Create your battle class:
```csharp
using Spearhead;

// A continuous battle is one that's evaluated each frame.
public MyBattle : ContinuousBattle<MyContext>
{
    public MyBattle(MyContext context) : base(context, new MyPhaseManager(), new EventManager())
}
```
To make constructing a battle easier on you, it's highly recommended that you do this step, as you'll only need to provide the context whenever you create a new battle instead of having to create a new phase manager and event manager each time you do this.

5. Create a battle instance and update it in your game loop.
6. Run the game!

From here you can start extending the phases, phase manager, and the battle itself to begin handling the logic you want.

## Battles
Much of Spearhead's utility comes from its `Battle` classes. Battles are built upon three concepts: Contexts, Action Management, and Phase Management.

### Contexts
A `Context` is the "space" in which a battle takes place. A context should store all information relavant to the area of a battle, such as battlefield layout, teams, entities, and so forth.

### Action Management
 - Action Management refers to how actions are processed and evaluated. Are they continuously evaluated? Are they evaluated as soon as they're requested, providing the result for the developer do with as they please? Spearhead comes with these two primary action management schemes built-in, but the APIs are exposed so you can create your own scheme if necessary.

### Phase Management
Phase Management is how action requests are handled, as well as how the flow of battle is managed, managing turns and pre- and post-event processing. Phases are the backbone of all battles, and Spearhead grants you total control over these phases - how phases transition between each other, what happens during a phase, and so forth.

#### Built-in Phase Managers
Spearhead does supply some built-in phase managers for some common turn structures found in games: 
- `Round Robin`: Each player gets their turn in order, e.g. Player A makes their moves which are then evaluated, then Player B makes their moves, which are evaluated, then control passes back to Player A. Many SRPGs, such as [Fire Emblem](https://en.wikipedia.org/wiki/Fire_Emblem), make use of this type of turn scheme.

## Games Using Spearhead
- **[Flight to Soleigarde](https://greenstack.itch.io/spingrid)**: A submission to [Magical Girl Game Jam 11](https://itch.io/jam/magical-girl-game-jam-11). This was the first game to use Spearhead, and the jam proved a valuable experience in refining this library.

## Roadmap
- Implement Discrete Battles
- Implement Event Manager
- Publish Nuget package
- Implement more built-in phase management schema
- Implement a fluent battle builder so developers don't need to learn so many classes
