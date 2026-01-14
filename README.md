🚋** Trolley Problem:** Resource Manager, a narrative strategy game branch of Coding Adventures. Instead of a physics simulation, this project gamifies ethical dilemmas. Players must navigate a series of scenarios (the "Trolley Deck"), making difficult choices that balance critical resources to ensure survival.

📂** Project Logic**: This branch implements a UI-driven framework where choices have quantitative consequences. The core logic revolves around:
**Resource Management**: Tracking the state of Food, People, and Fuel. Deck System: A randomized list of questions (TrolleyDeck) that serves scenarios to the player.Branching Choices: Support for scenarios with 2 or 3 distinct options, each carrying different resource penalties or gains.

🎮 **Gameplay Mechanics**: The Deck: The game initializes a deck of ethical questions.The Choice: The QuestionManager presents a scenario (e.g., "Divert track?").The Cost: Every decision (TrolleyOption) applies an immediate arithmetic change to your resources:People: Population count (can be sacrificed or saved).Food: Sustenance levels.Fuel: Energy required to keep the trolley/train moving.Game Over/End: When the deck is exhausted, or resources hit a critical state, the GameManager triggers the End Game or Game Over sequence.

📜 **Script Architecture **
**QuestionManager**. cs: The core controller. It shuffles the "Deck," instantiates the correct UI (2-button or 3-button layouts), and applies the resource changes based on player input.
**GameManager**. cs: The singleton state machine. It handles the game flow, including Start, EndGame (deck empty), and GameOver states. It also manages the global reset functionality.Resource.csA ScriptableObject that defines the data structure for a specific stat (Food, People, Fuel), tracking its current, starting, and maximum amounts.
**ResourceDisplaySystem**. cs: A lightweight UI observer that updates on-screen text to match the underlying Resource data values.ButtonHolder.csA utility class that references the dynamic buttons and text fields on the question prefabs, allowing the Manager to re-bind listeners at runtime.

🛠️** Data StructuresNote**: While the logic handles these, the definitions are likely in separate files not yet analyzed.

**TrolleyDeck:** A collection/list of questions.
**TrolleyQuestion:** Holds the prompt text and array of options.
**TrolleyOption**: Contains the specific integer values (foodAmountAlter, peopleAmountAlter, fuelAmountAlter) applied when chosen.
