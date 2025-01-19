# Spearhead
Spearhead is a framework designed to simplify the implementation and development of turn-based games, especially those with dynamic systems. It's probably overkill for something like Balatro, but should be good for tactics games, etc.

## Usage
This section is a work in progress.s

It is highly recommended that you define your battles, phases, and so forth as extension classes with the type parameters filled out,
i.e. `class MyBattle : Battle<MyContext> {...}`.
