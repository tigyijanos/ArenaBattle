# Task Description

In the arena, N heroes fight, who can be archers, cavalry, and swordsmen. Each hero has an identifier and health, and they attack and defend according to the following rules:

## Attack and Defense Rules

- **Archer attacks:**
  - Cavalry: 40% chance the cavalry dies, 60% chance they defend successfully
  - Swordsman: swordsman dies
  - Archer: defending archer dies

- **Swordsman attacks:**
  - Cavalry: nothing happens
  - Swordsman: defending swordsman dies
  - Archer: archer dies

- **Cavalry attacks:**
  - Cavalry: defending cavalry dies
  - Swordsman: cavalry dies
  - Archer: archer dies

## Battle Mechanics

The battle is divided into rounds. In each round, an attacker and a defender are randomly selected. The remaining heroes rest and their health increases by 10, but it cannot exceed the maximum. The health of the participating heroes is halved. If this is less than a quarter of the initial health, they die. Initial health values are as follows:
- Archer: 100
- Cavalry: 150
- Swordsman: 120

The battle continues until a maximum of 1 hero remains alive.

## Task

Create a web API that pits heroes against each other according to the above rules and is equipped with unit tests. The following endpoints need to be implemented:

1. **Random Hero Generator**
   - **Input:** number of warriors
   - **Return:** arena identifier

2. **Battle**
   - **Input:** arena identifier
   - **Return:** History, which describes the number of rounds, who attacked whom in each round, and how their health changed.
