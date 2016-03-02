using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace ElementSelection
{
	partial class Tableviewcontioler : UITableView
	{
		static NSString MyCellId = new NSString ("MyCellId");
		string[] tableItems;
		string[] keys;
		Dictionary<string, List<string>> indexedTableItems;

		public Tableviewcontioler (IntPtr handle) : base (handle)
		{
			tableItems = new string[] { 
				"H, Hydrogen", "He, Helium", "Li, Lithium", "Be, Beryllium", "B, Boron",
				"C, Carbon", "N, Nitrogen", "O, Oxygen", "F, Fluorine", "Ne, Neon",
				"Na, Sodium", "Mg, Magnesium", "Al, Aluminum", "Si, Silicon", "P, Phosphorus",
				"S, Sulfur", "Cl, Chlorine", "Ar, Argon", "K, Potassium", "Ca, Calcium", "Sc, Scandium",
				"Ti, Titanium", "V, Vanadium", "Cr, Chromium", "Mn, Manganese", "Fe, Iron", "Co, Cobalt",
				"Ni, Nickel", "Cu, Copper", "Zn, Zinc", "Ga, Gallium", "Ge, Germanium", "As, Arsenic",
				"Se, Selenium", "Br, Bromine", "Kr, Krypton", "Rb, Rubidium", "Sr, Strontium", "Y, Yttrium",
				"Zr, Zirconium", "Nb, Niobium", "Mo, Molybdenum", "Tc, Technetium", "Ru, Ruthenium", "Rh, Rhodium",
				"Pd, Palladium", "Ag, Silver", "Cd, Cadmium", "In, Indium", "Sn, Tin", "Sb, Antimony", "Te, Tellurium",
				"I, Iodine", "Xe, Xenon", "Cs, Cesium", "Ba, Barium", "La, Lanthanum", "Ce, Cerium", "Pr, Praseodymium",
				"Nd, Neodymium", "Pm, Promethium", "Sm, Samarium", "Eu, Europium", "Gd, Gadolinium", "Tb, Terbium", 
				"Dy, Dysprosium", "Ho, Holmium", "Er, Erbium", "Tm, Thulium", "Yb, Ytterbium", "Lu, Lutetium",
				"Hf, Hafnium", "Ta, Tantalum", "W, Tungsten", "Re, Rhenium", "Os, Osmium", "Ir, Iridium",
				"Pt, Platinum", "Au, Gold", "Hg, Mercury", "Tl, Thallium", "Pb, Lead", "Bi, Bismuth",
				"Po, Polonium", "At, Astatine", "Rn, Radon", "Fr, Francium", "Ra, Radium", "Ac, Actinium",
				"Th, Thorium", "Pa, Protactinium", "U, Uranium", "Np, Neptunium", "Pu, Plutonium",
				"Am, Americium", "Cm, Curium", "Bk, Berkelium", "Cf, Californium", "Es, Einsteinium",
				"Fm, Fermium", "Md, Mendelevium", "No, Nobelium", "Lr, Lawrencium", "Rf, Rutherfordium",
				"Db, Dubnium", "Sg, Seaborgium", "Bh, Bohrium", "Hs, Hassium", "Mt, Meitnerium", "Ds, Darmstadtium",
				"Rg, Roentgenium", "Cn, Copernicium", "Uut, Ununtrium", "Fl, Flerovium", "Uup, Ununpentium",
				"Lv, Livermorium", "Uus, Ununseptium", "Uuo, Ununoctium"
			};

			//tableItems = new string[] 
			//{ "Batman", "Superman", "Wonder Woman", "Flash", "Cyborg", "Aquaman", "Green Lantern", "Matian Manhunter", "Atom", "Element Woman", "Firestorm", "Shazam", "Lex Luthor", "Captian Cold", "Power Ring"};
			TableView.RegisterClassForCellReuse (typeof(MyCell), MyCellId);
			//create a dictionary of table sections
			//key = section name, value = list os strings
			indexedTableItems = new Dictionary<string, List<string>>();
			foreach (var t in tableItems) {
				if (indexedTableItems.ContainsKey (t [0].ToString ())) {
					indexedTableItems [t [0].ToString ()].Add (t);
				} else {
					indexedTableItems.Add (t [0].ToString (), new List<string> (){ t });
				}
			}

			keys = indexedTableItems.Keys.ToArray ();

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return keys.Length;		
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			//return tableItems.Length;
			return indexedTableItems[keys[section]].Count;
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{
			return keys;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			string item = indexedTableItems[keys[indexPath.Section]][indexPath.Row];
			var cell = (MyCell)tableView.DequeueReusableCell (MyCellId, indexPath);
			cell.TextLabel.Text = item;

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UIAlertController okAlertController = UIAlertController.Create ("You Have Picked ", indexedTableItems[keys[indexPath.Section]][indexPath.Row], UIAlertControllerStyle.Alert);
			okAlertController.AddAction (UIAlertAction.Create ("Well Duh", UIAlertActionStyle.Default, null));
			this.PresentViewController (okAlertController, true, null);
			tableView.DeselectRow (indexPath, true);
		}
	}
}
