﻿using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Gemini.Modules.MainMenu.Models
{
	public class MenuModel : BindableCollection<MenuItemBase>, IMenu
	{
		public IEnumerable<MenuItemBase> All
		{
			get
			{
				var queue = new Queue<MenuItemBase>(this);
				while (queue.Count > 0)
				{
					var current = queue.Dequeue();
					foreach (var item in current)
						queue.Enqueue(item);
					yield return current;
				}
			}
		}

		public void Add(params MenuItemBase[] items)
		{
			items.Apply(Add);
		}

	    public MenuItemBase Find(string name)
	    {
	        return Items.FirstOrDefault(x => x.Name == name);
	    }

	    public bool Remove(string name)
		{
			return Items.Remove(Find(name));
		}
	}
}