# Barrow-King's Oath

Nine weapons and a shield for the swamp, all with their own models and a bit of spirit damage.

This used to be called Barrow-King's Arsenal. I renamed it in 1.2.0 so it matches my other sets (First Thunder's Oath for the Meadows, Pinewarden's Oath for the Black Forest). Nothing else changed about the old items, so updating is safe.

This started as a single mace because I wanted something better than the iron mace for Bonemass. Then it got out of hand and turned into a full set, and in 1.2.0 it finally got a dagger, a spear and a bow.

**Heads up:** this mod was made with AI tools. The code was written with Claude Code, the concept art came from an AI image generator, and the 3D models were generated with Tripo from that art.

## What you get

Everything is crafted at a level 2 forge. Each item needs iron, ancient bark and one Draugr Elite trophy. Upgrades only cost iron and bark.

- Barrow-King's Maul - mace, 55 blunt
- Drowned Jarl's Oathblade - sword, 55 slash
- Grave-Tithe Axe - 35 slash + 26 blunt. Chops trees exactly like the iron axe, so you can keep it as your main axe.
- Barrow-King's Reach - one-handed war pike, 55 pierce (see the note below)
- Barrow-King's Knell - sledge, 55 blunt
- Barrow-King's Atgeir - 65 pierce
- Barrow-Ward - round shield, 48 block
- Last-Oath - dagger, 20 slash + 20 pierce
- Mire-Oath Spear - spear, 55 pierce. Throw it and it flies as the real model, not the vanilla spear.
- Stillwater String - bow, same pierce as the Huntsman bow

Every weapon also does 8 spirit damage, +2 per upgrade level. Spirit works as damage over a few seconds, so you won't see it in the hit number, but it adds up fast on Bonemass and draugr.

Animations, sounds, durability and so on are the same as the vanilla weapon each one is based on (iron weapons, the Abyssal Razor for the dagger, the Elderbark spear and the Huntsman bow). The weapon heads glow a little.

## The war pike

The pike is built on the war pike from Therzie's Warfare, so if you have Warfare installed you get that moveset (one-handed, uses the Spears skill). Without Warfare it still works, it just behaves like an atgeir instead.

## Install

Use a mod manager, or copy the `plugins` folder contents into `BepInEx/plugins/BarrowKingsArsenal`. The `assets` folder has to stay next to the DLL.

Needs Jotunn.

## Multiplayer

It adds items, so everyone on the server needs it, and so does a dedicated server.

## Good to know

- If you uninstall the mod, the items disappear from your inventory and chests. That's how modded items work.
- Spawn names if you want to try them first: `MaceBarrowKing_claude`, `SwordBarrowKing_claude`, `AxeBarrowKing_claude`, `PikeBarrowKing_claude`, `SledgeBarrowKing_claude`, `AtgeirBarrowKing_claude`, `ShieldBarrowKing_claude`, `KnifeBarrowKing_claude`, `SpearBarrowKing_claude`, `BowBarrowKing_claude`.
- No config file yet. The stats are what they are.
- I've only played this in my own modpack, so tell me if something looks off in yours.

## Source

https://github.com/JellyDOTexe/BarrowKingsOath (MIT)

## Bugs

Found a bug? Open an issue on [GitHub](https://github.com/JellyDOTexe/BarrowKingsOath/issues) and I'll take a look.
