Future Features (Planned)
These are planned ideas, not promises; details may change as we learn more.
Note: keep this in sync with `ExpeditionsContent/ROADMAP.md`.

- Revamp rainbow quest title coloring.
  Current rainbow text is tied to the "important/challenger" flag rather than a clear difficulty signal. This feels arbitrary and can confuse players about why a quest is highlighted. We want to replace this with a more meaningful visual language (likely based on real difficulty or questline priority), and make the meaning obvious at a glance without needing mod knowledge.
- Revamp slider blip colors and category filter colors/icons.
  The top bar blip colors currently reflect quest rarity/difficulty (and a special daily highlight), while the category filter icons/colors are unrelated. This mismatch makes it hard to interpret what the colors mean. We want a consistent, explainable system that aligns blip colors, category filters, and quest difficulty/importance, with clearer labels or legends so players understand the UI without guessing.

---

## Quest Expansion Roadmap

### Design Philosophy
Our main goal is to help new players have direction without constant wiki consultation. Terraria is inherently open-ended, but new players from quest-driven games often feel lost. We aim to provide guidance while preserving natural exploration opportunities—players should never feel lost, but should always feel free to explore.

### Current Quest Coverage Analysis

**Quest Tier System:**
- **AA-AD**: Early game (pre-boss) - Basic mechanics, exploration, first steps
- **BA-BE**: Pre-hardmode bosses - Major combat encounters
- **CA-CC**: Early hardmode - New world state, initial hardmode challenges
- **DA-DC**: Mechanical bosses & Plantera - Mid-hardmode progression
- **EA-ED**: Post-Plantera & Moon Lord - Endgame content

**Strong Coverage Areas:**
- ✅ Welcome & basic crafting (torches, wood, shelter)
- ✅ Exploration & mapping systems
- ✅ Ore smelting & town building
- ✅ Underground exploration introduction
- ✅ NPC housing basics (Guide, Nurse, Merchant)
- ✅ Mana crystal & life crystal progression
- ✅ Grappling hook introduction
- ✅ All major boss encounters (King Slime through Moon Lord)
- ✅ Evil biome discovery & progression
- ✅ Hardmode transition

### Identified Gaps & Proposed Quests

Based on Terraria wiki progression guides and common player pain points, we've identified critical areas where new players struggle without guidance:

#### Priority Tier 1: Critical Gaps (Fixes Common Pain Points)

**1. "First Defense" (AC tier)**
- **Problem:** Players don't understand armor tier progression or when to upgrade
- **Quest Goals:** Craft a full set of metal armor (copper/iron/silver tier)
- **Teaches:** Defense stat importance, set bonuses exist, gear progression matters
- **Prerequisites:** Smelting Ores quest completed
- **Wiki Evidence:** Players struggle knowing when they're "ready" for challenges

**2. "The Alchemist's Apprentice" (AC tier)**
- **Problem:** No introduction to potion brewing or alchemy stations
- **Quest Goals:** Craft a placed bottle (alchemy station), brew any healing or buff potion
- **Teaches:** Potions are craftable (not just found), alchemy stations unlock recipes
- **Prerequisites:** Underground quest completed
- **Wiki Evidence:** "Players neglect potion crafting" is the #1 beginner mistake

**3. "Battle Preparation" (AD tier)**
- **Problem:** Players fight bosses without buffs or understanding buff stacking
- **Quest Goals:** Use 3 different buff potions simultaneously
- **Teaches:** Buffs stack, preparation makes fights easier, consumables have value
- **Prerequisites:** Before Eye of Cthulhu becomes available
- **Difficulty:** 1 (Important flag)

**4. "Accessorize!" (AC tier)**
- **Problem:** Players miss or don't understand the accessory system
- **Quest Goals:** Equip an accessory in any slot
- **Teaches:** Accessory slots exist, provide passive bonuses, are distinct from armor
- **Prerequisites:** Gearing Up (chest opening) quest
- **Wiki Evidence:** Cloud in a Bottle and Hermes Boots are "game-changers" many players never find

**5. "Preparing the Battlefield" (AD tier)**
- **Problem:** Players fight bosses in natural terrain without arena preparation
- **Quest Goals:** Place 5+ platforms in a row (arena shape), place a campfire
- **Teaches:** Environmental preparation dramatically improves survival, simple arenas work
- **Prerequisites:** Before Eye of Cthulhu, after Life Crystals quest
- **Wiki Evidence:** "Even basic arenas massively help boss fights"

#### Priority Tier 2: Important Gaps (Reduces Wiki Dependency)

**6. "Gone Fishing" (AC tier)**
- **Problem:** Fishing is never introduced despite being a major progression path
- **Quest Goals:** Craft a fishing pole, catch any fish
- **Teaches:** Fishing exists, provides crates with ores/potions, alternative to mining
- **Prerequisites:** Town building completed
- **Note:** Angler introduction could be a follow-up quest

**7. "Merchant's First Customer" (AB-AC tier)**
- **Problem:** No guidance on economy, what to buy, or why money matters
- **Quest Goals:** Earn and spend 50 silver coins at any NPC shop
- **Teaches:** NPCs sell useful items, money has purpose beyond hoarding
- **Prerequisites:** Merchant is housed
- **Reward:** Small gold bonus to encourage further shopping

**8. "Savings Account" (AC tier)**
- **Problem:** Inventory management becomes overwhelming, players don't know about extended storage
- **Quest Goals:** Place a Piggy Bank or Safe, store an item in it
- **Teaches:** Extended personal storage exists, Piggy Banks are portable across instances
- **Prerequisites:** Merchant housed (sells Piggy Bank)
- **Wiki Evidence:** Guides recommend "carry 50 silver to buy Piggy Bank from Merchant"

**9. "Advanced Mobility" (Post-WoF, CA-CB tier)**
- **Problem:** Hardmode movement expectations jump dramatically
- **Quest Goals:** Equip wings (any tier) OR craft Spectre/Lightning Boots
- **Teaches:** Vertical mobility becomes essential in hardmode
- **Prerequisites:** Hardmode begins, altar smashing introduces new ores

#### Priority Tier 3: Completeness (Optional but Valuable)

**10. Biome Exploration Series**
- **Snow/Ice Biome Discovery** (AB-AC tier): Find ice skates, ice blade, or snow-specific items
- **Ocean Exploration** (AC tier): Discover ocean, find water chests
- **Underground Desert** (BD tier): Discover desert biome, find fossils
- **Note:** These should be optional side quests, not critical path blocking

**11. "Tinkerer's Workshop Introduction" (Post-Goblin Army)**
- **Problem:** Players don't understand accessory combining
- **Quest Goals:** Use Tinkerer's Workshop to combine two accessories
- **Teaches:** Accessories can be upgraded, reforging exists
- **Prerequisites:** Goblin Tinkerer rescued and housed

**12. "Herb Garden" (AC-AD tier)**
- **Problem:** Players don't realize herbs can be farmed
- **Quest Goals:** Plant and grow any herb, harvest it
- **Teaches:** Herbs respawn, can be farmed, seeds come from wild herbs
- **Prerequisites:** Alchemy quest completed
- **Extends:** Self-sufficient potion crafting

### Design Considerations for New Quests

**Progressive Unlocking:**
- Continue using prerequisite chains to prevent overwhelming new players
- Gate advanced quests behind relevant completions (no fishing quests before knowing what fishing is)

**Dynamic Descriptions:**
- Follow existing pattern: descriptions change based on player readiness (life, defense, boss defeats)
- Include warnings when undergeared (see Eye of Cthulhu readiness checks)

**Contextual Rewards:**
- Follow "Gearing Up" pattern: rewards give items players likely don't have yet
- Avoid redundant rewards (check inventory before giving mobility accessories)

**Parallel Progression:**
- Allow multiple quest chains to be active (combat path, exploration path, building path)
- Don't force linear progression where player choice should exist

**Teachable Moments:**
- Every major game system should have at least one introductory quest
- Quests should teach "why" not just "what" (why armor matters, why buffs help, why fishing is valuable)

### Implementation Priority

1. **Phase 1 (Highest Impact):** Armor crafting, potion brewing, accessory equipping
2. **Phase 2 (Core Systems):** Boss arena prep, battle buffs, fishing introduction
3. **Phase 3 (Polish):** Economy tutorial, storage systems, biome exploration
4. **Phase 4 (Advanced):** Tinkerer workshop, herb farming, mobility upgrades

### Success Metrics

A quest system succeeds when:
- Players understand game systems without external wiki consultation
- Players feel guided but not railroaded
- Natural exploration remains rewarding
- Quest completion correlates with player readiness for next challenges

### References

Analysis based on:
- Official Terraria Wiki progression guides
- Steam Community pre-hardmode checklists
- Player feedback on common beginner mistakes
- Comparison with existing quest coverage in ExpeditionsContent/Quests/Core/
