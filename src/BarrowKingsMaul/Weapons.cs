using System;
using System.Collections.Generic;

namespace BarrowKingsMaul
{
    // The Barrow-King set. Each item clones its iron-tier counterpart (animations, sounds, chop/tool tier)
    // and changes only the listed combat damage. Spirit damage burns over a few seconds and stacks per hit.
    internal sealed class WeaponDef
    {
        public string Prefab, CloneFrom, Fallback, Asset, Name, Description;
        public float HeadFraction = 0.3f;           // top part of the model that gets the spirit motes and the swing trail
        public bool FlipBlade;                      // rotate 180 degrees around the haft if the blade faces the wrong way (shield: turn it right side up)
        public bool IsShield;                       // round shield: fitted to the vanilla shield by size and facing, no haft
        public string WarfareJuggernaut;            // register with Therzie Warfare's Juggernaut (Piercer) effect, like its own war pikes
        public bool FlipHead;                       // the head goes on the end nearer the hand (vanilla spears are held near the middle)
        public bool ThrownModel;                    // the thrown projectile (spear) shows our model too
        public Action<ItemDrop.ItemData.SharedData> Stats;
        public (string item, int amount, int perLevel)[] Recipe;
        public int StationLevel = 2;
    }

    internal static class Weapons
    {
        private static (string, int, int)[] Std(int iron, int ironPerLevel) =>
            new[] { ("Iron", iron, ironPerLevel), ("ElderBark", 10, 5), ("TrophyDraugrElite", 1, 0) };

        internal static readonly List<WeaponDef> All = new List<WeaponDef>
        {
            new WeaponDef
            {
                Prefab = "MaceBarrowKing_claude", CloneFrom = "MaceIron", Asset = "maul", HeadFraction = 0.34f,
                Name = "Barrow-King's Maul",
                Description = "Forged for a jarl who drowned with his barrow. The runes still remember what killed him.",
                Stats = s => { s.m_damages.m_blunt = 55; s.m_damages.m_spirit = 8; s.m_damagesPerLevel.m_blunt = 6; s.m_damagesPerLevel.m_spirit = 2; },
                Recipe = Std(20, 10),
            },
            new WeaponDef
            {
                Prefab = "SwordBarrowKing_claude", CloneFrom = "SwordIron", Asset = "sword", HeadFraction = 0.6f,
                Name = "Drowned Jarl's Oathblade",
                Description = "Drawn from the barrow, it remembers the hand that ruled.",
                Stats = s => { s.m_damages.m_slash = 55; s.m_damages.m_spirit = 8; s.m_damagesPerLevel.m_slash = 6; s.m_damagesPerLevel.m_spirit = 2; },
                Recipe = Std(20, 10),
            },
            new WeaponDef
            {
                // chop damage and tool tier stay exactly as the Iron Axe's, so trees fall just as fast
                Prefab = "AxeBarrowKing_claude", CloneFrom = "AxeIron", Asset = "axe", HeadFraction = 0.32f, FlipBlade = true,
                Name = "Grave-Tithe Axe",
                Description = "Half axe, half hammer. Every fallen oath leaves a notch upon its beard.",
                Stats = s => { s.m_damages.m_slash = 35; s.m_damages.m_blunt = 26; s.m_damages.m_spirit = 8;
                               s.m_damagesPerLevel.m_slash = 2; s.m_damagesPerLevel.m_blunt = 2; s.m_damagesPerLevel.m_spirit = 2; },
                Recipe = Std(20, 10),
            },
            new WeaponDef
            {
                // Therzie Warfare's swamp-tier War Pike gives the real war pike moveset (thrust + jump attack).
                // Without Warfare installed it falls back to the Iron Atgeir.
                Prefab = "PikeBarrowKing_claude", CloneFrom = "WarpikeChitin_TW", Fallback = "AtgeirIron", WarfareJuggernaut = "yes", Asset = "pike", HeadFraction = 0.2f,
                Name = "Barrow-King's Reach",
                Description = "From the drowned jarl's shield wall, its cold point still holds the living at bay.",
                Stats = s => { s.m_damages.m_pierce = 55; s.m_damages.m_spirit = 8; s.m_damagesPerLevel.m_spirit = 2; },   // base per-level pierce kept
                Recipe = Std(30, 15),
            },
            new WeaponDef
            {
                Prefab = "SledgeBarrowKing_claude", CloneFrom = "SledgeIron", Asset = "sledge", HeadFraction = 0.22f,
                Name = "Barrow-King's Knell",
                Description = "Its iron toll wakes the drowned beneath the peat.",
                Stats = s => { s.m_damages.m_blunt = 55; s.m_damages.m_spirit = 8; s.m_damagesPerLevel.m_blunt = 6; s.m_damagesPerLevel.m_spirit = 2; },
                Recipe = Std(30, 15),
            },
            new WeaponDef
            {
                Prefab = "AtgeirBarrowKing_claude", CloneFrom = "AtgeirIron", Asset = "atgeir", HeadFraction = 0.24f,
                Name = "Barrow-King's Atgeir",
                Description = "Bound within its silver socket, a drowned oathkeeper's soul lights the iron that once guarded his jarl's barrow.",
                Stats = s => { s.m_damages.m_pierce = 65; s.m_damages.m_spirit = 8; s.m_damagesPerLevel.m_pierce = 6; s.m_damagesPerLevel.m_spirit = 2; },
                Recipe = Std(30, 15),
            },
            new WeaponDef
            {
                Prefab = "ShieldBarrowKing_claude", CloneFrom = "ShieldBanded", Asset = "shield", IsShield = true, FlipBlade = true,
                Name = "Barrow-Ward",
                Description = "The king's last circle holds against the living tide.",
                Stats = s => { s.m_blockPower = 48; s.m_blockPowerPerLevel = 6; },   // Banded: 42 (+6); parry, deflection, armor kept
                Recipe = new[] { ("Iron", 10, 5), ("ElderBark", 10, 5), ("TrophyDraugrElite", 1, 0) },
            },
            new WeaponDef
            {
                // Abyssal Razor moveset; between Pinewarden's dagger (14/14) and the Black Metal Knife
                Prefab = "KnifeBarrowKing_claude", CloneFrom = "KnifeChitin", Fallback = "KnifeCopper", Asset = "dagger", HeadFraction = 0.55f,
                Name = "Last-Oath",
                Description = "The drowned king kept one final oath close to his heart.",
                Stats = s => { s.m_damages.m_slash = 20; s.m_damages.m_pierce = 20; s.m_damages.m_chop = 0; s.m_damages.m_spirit = 8;
                               s.m_damagesPerLevel.m_spirit = 2; },
                Recipe = Std(10, 5),
            },
            new WeaponDef
            {
                Prefab = "SpearBarrowKing_claude", CloneFrom = "SpearElderbark", Asset = "spear", HeadFraction = 0.2f, ThrownModel = true, FlipHead = true,
                Name = "Mire-Oath Spear",
                Description = "The jarl's last oath still waits beneath its cold edge.",
                Stats = s => { s.m_damages.m_pierce = 55; s.m_damages.m_spirit = 8; s.m_damagesPerLevel.m_spirit = 2; },
                Recipe = Std(10, 5),
            },
            new WeaponDef
            {
                // the Huntsman Bow is a rigid mesh like the other vanilla bows, so ours swaps in like any other weapon
                Prefab = "BowBarrowKing_claude", CloneFrom = "BowHuntsman", Asset = "bow", HeadFraction = 0.5f, FlipBlade = true,
                Name = "Stillwater String",
                Description = "Its cord remembers the hush before the barrow doors closed.",
                Stats = s => { s.m_damages.m_spirit = 8; s.m_damagesPerLevel.m_spirit = 2; },   // Huntsman pierce kept
                Recipe = Std(10, 5),
            },
        };
    }
}
