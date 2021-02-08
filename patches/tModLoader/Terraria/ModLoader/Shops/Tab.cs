﻿using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.ModLoader.Shops
{
	public class Tab
	{
		public string Name { get; internal set; }
		public readonly ModTranslation DisplayName;
		
		// todo: tab ID
		
		public Mod Mod { get; internal set; }

		public readonly List<Entry> Entries = new List<Entry>();

		public Tab() {
			DisplayName = Mod == null ? new ModTranslation($"ShopTab.{Name}") : Mod.GetOrCreateTranslation($"Mods.{Mod.Name}.ShopTab.{Name}");
		}

		public EntryItem AddEntry(int type) {
			Item item = new Item(type) { isAShopItem = true };
			EntryItem entry = new EntryItem(item);
			Entries.Add(entry);
			return entry;
		}

		public EntryItem AddEntry<T>() where T : ModItem => AddEntry(ModContent.ItemType<T>());

		public T AddEntry<T>(T entry) where T : Entry {
			Entries.Add(entry);
			return entry;
		}
	}
}