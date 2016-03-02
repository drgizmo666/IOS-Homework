using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace ElementSelection2
{
	partial class MasterTableView : UITableViewController
	{
		const string CELL_IDENTIFIER = "ElementCell";
		private List<string> elementNames = new List<string>() 
		{ 
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

		private List<string> elementInfo = new List<string>()
		{
			"1 H, Hydrogen composed of the Greek elements hydro- and -gen meaning 'water-forming", "2 He, Helium the Greek helios, sun", 
			"3    Li    Lithium    the Greek lithos, stone", "4    Be    Beryllium    beryl, a mineral", "5    B    Boron    borax, a mineral",
			"6    C    Carbon    the Latin carbo, charcoal", "7    N    Nitrogen    the Greek nitron and -gen meaning niter-forming", 
			"8    O    Oxygen    from the Greek oxy-, both sharp and acid, and -gen, meaning acid-forming", "9    F    Fluorine    the Latin fluere, to flow", 
			"10    Ne    Neon    the Greek neos, meaning new", "11    Na    Sodium    the English word soda (natrium in Latin)", 
			"12    Mg    Magnesium    Magnesia, a district of Eastern Thessaly in Greece", "13    Al    Aluminium    from alumina, a compound (originally aluminum)", 
			"14    Si    Silicon    from the Latin silex, flint (originally silicium)", "15    P    Phosphorus    the Greek phoosphoros, carrying light",
			"16    S    Sulfur    Latin sulphur, sulfur", "17    Cl    Chlorine    the Greek chloros, greenish yellow", "18    Ar    Argon    the Greek argos, idle", 
			"K, Potassium", "Ca, Calcium", "Sc, Scandium",
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

		public MasterTableView (IntPtr handle) : base (handle)
		{
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return elementNames.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// in a Storyboard, Dequeue will ALWAYS return a cell, 
			var cell = tableView.DequeueReusableCell (CELL_IDENTIFIER);
			// now set the properties as normal
			cell.TextLabel.Text = elementNames[indexPath.Row];

			return cell;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "elementSegue") { // set in Storyboard
				var detailController = segue.DestinationViewController as DetailViewController;
				if (detailController != null) {
					//var source = TableView.Source as DwarfDataSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					//var item = source.GetItem(rowPath.Row);

					detailController.ElementInfo = elementInfo[rowPath.Row]; // to be defined on the DetailViewController
				}
			}
		}
	}
}
