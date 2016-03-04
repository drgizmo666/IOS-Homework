using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace ElementSelection2
{
	partial class MasterTableView : UITableViewController
	{
		static NSString MyCellId = new NSString ("MyCellId");
		string[] tableItems;
		string[] keys;
		Dictionary<string, List<string>> indexedTableItems;
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
			"Ac, Actinium, 89, the Greek aktis (ray)",
			"Ag, Silver, 47, English word (argentum in Latin)",
			"Al, Aluminium, 13, from alumina, a compound",
			"Am, Americium, 95, The Americas, as the element was first synthesized on the continent, by analogy with europium",
			"Ar, Argon, 18, the Greek argos (idle)",
			"As, Arsenic, 33, English word (Latin arsenicum)",
			"At, Astatine, 85, the Greek astatos (unstable)",
			"Au, Gold, 79, English word (aurum in Latin)",
			"B, Boron, 5, borax, a mineral",
			"Ba, Barium, 56, the Greek barys (heavy)",
			"Be, Beryllium, 4, beryl, a mineral",
			"Bh, Bohrium, 107, Niels Bohr, physicist",
			"Bi, Bismuth, 83, German word, now obsolete",
			"Bk, Berkelium, 97, Berkeley, California, where the element was first synthesized, by analogy with terbium",
			"Br, Bromine, 35, the Greek bromos (stench)",
			"C, Carbon, 6, the Latin carbo (charcoal)",
			"Ca, Calcium, 20, the Latin calx (lime)",
			"Cd, Cadmium, 48, the New Latin cadmia, from King Kadmos",
			"Ce, Cerium, 58, the then recently-discovered asteroid Ceres, considered a planet at the time",
			"Cf, Californium, 98, California, where the element was first synthesized",
			"Cl, Chlorine, 17, the Greek chloros (greenish yellow)",
			"Cm, Curium, 96, Pierre Curie, a physicist, and Marie Curie, a physicist and chemist, named after great scientists by analogy with gadolinium",
			"Cn, Copernicium, 112, Nicolaus Copernicus, astronomer",
			"Co, Cobalt, 27, the German word Kobold (goblin)",
			"Cr, Chromium, 24, the Greek chroma (color)",
			"Cs, Caesium, 55, the Latin caesius (sky blue)",
			"Cu, Copper, 29, English word (Latin cuprum)",
			"Db, Dubnium, 105, Dubna, Russia",
			"Ds, Darmstadtium, 110, Darmstadt, Germany, where the element was first synthesized",
			"Dy, Dysprosium, 66, the Greek dysprositos (hard to get)",
			"Er, Erbium, 68, Ytterby, Sweden",
			"Es, Einsteinium, 99, Albert Einstein, physicist",
			"Eu, Europium, 63, Europe",
			"F, Fluorine, 9, the Latin fluere (to flow)",
			"Fe, Iron, 26, English word (ferrum in Latin)",
			"Fl, Flerovium, 114, Georgy Flyorov, physicist",
			"Fm, Fermium, 100, Enrico Fermi, physicist",
			"Fr, Francium, 87, Francia, the New Latin name for France",
			"Ga, Gallium, 31, Gallia, the Latin name for France",
			"Gd, Gadolinium, 64, Johan Gadolin, chemist, physicist and mineralogist",
			"Ge, Germanium, 32, Germania, the Latin name for Germany",
			"H, Hydrogen, 1, composed of the Greek elements hydro (water) and gen (forming)",
			"He, Helium, 2, the Greek helios (sun)",
			"Hf, Hafnium, 72, Hafnia, the New Latin name forCopenhagen",
			"Hg, Mercury, 80, the New Latin name mercurius, named after the Roman god (Hg from former name hydrargyrum, from Greek hydr- (water) and argyros (silver))",
			"Ho, Holmium, 67, Holmia, the New Latin name forStockholm",
			"Hs, Hassium, 108, Hesse, Germany, where the element was first synthesized",
			"I, Iodine, 53, French iode, after the Greek ioeides (violet)",
			"In, Indium, 49, indigo",
			"Ir, Iridium, 77, Iris, the Greek goddess of the rainbow",
			"K, Potassium, 19, New Latin potassa (potash) (kalium in Latin)",
			"Kr, Krypton, 36, the Greek kryptos (hidden)",
			"La, Lanthanum, 57, the Greek lanthanein (to lie hidden)",
			"Li, Lithium, 3, the Greek lithos (stone)",
			"Lr, Lawrencium, 103, Ernest O. Lawrence, physicist",
			"Lu, Lutetium, 71, Lutetia, the Latin name for Paris",
			"Lv, Livermorium, 116, Lawrence Livermore National Laboratory(in Livermore, California) which collaborated with JINR on its synthesis",
			"Md, Mendelevium, 101, Dmitri Mendeleev, chemist and inventor",
			"Mg, Magnesium, 12, Magnesia, a district of Eastern Thessalyin Greece",
			"Mn, Manganese, 25, corrupted from magnesia negra, see Magnesium",
			"Mo, Molybdenum, 42, the Greek molybdos (lead)",
			"Mt, Meitnerium, 109, Lise Meitner, physicist",
			"N, Nitrogen, 7, the Greek nitron (niter) and gen (forming)",
			"Na, Sodium, 11, the English word soda (natrium in Latin)",
			"Nb, Niobium, 41, Niobe, daughter of king Tantalus from Greek mythology",
			"Nd, Neodymium, 60, the Greek neos didymos (new twin)",
			"Ne, Neon, 10, the Greek neos (new)",
			"Ni, Nickel, 28, from Swedish kopparnickel, containing theGerman word Nickel (goblin)",
			"No, Nobelium, 102, Alfred Nobel, chemist, engineer, innovator, and armaments manufacturer",
			"Np, Neptunium, 93, Neptune, the eighth planet in the Solar System",
			"O, Oxygen, 8, from the Greek oxy (both sharp and acid) and gen (forming)",
			"Os, Osmium, 76, the Greek osmè (smell)",
			"P, Phosphorus, 15, the Greek phoosphoros (carrying light)",
			"Pa, Protactinium, 91, the Greek protos (first), and actinium, which is produced through the radioactive decay of protactinium",
			"Pb, Lead, 82, English word (plumbum in Latin)",
			"Pd, Palladium, 46, the then recently-discovered asteroid Pallas, considered a planet at the time",
			"Pm, Promethium, 61, Prometheus of Greek mythology, who stole fire from the Gods and gave it to humans",
			"Po, Polonium, 84, Polonia, the New Latin name for Poland",
			"Pr, Praseodymium, 59, the Greek praseios didymos (green twin)",
			"Pt, Platinum, 78, the Spanish platina (little silver)",
			"Pu, Plutonium, 94, Pluto, a dwarf planet in the Solar System",
			"Ra, Radium, 88, the Latin radius (ray)",
			"Rb, Rubidium, 37, the Latin rubidus (deep red)",
			"Re, Rhenium, 75, Rhenus, the Latin name for the riverRhine",
			"Rf, Rutherfordium, 104, Ernest Rutherford, chemist and physicist",
			"Rg, Roentgenium, 111, Wilhelm Conrad Röntgen, physicist",
			"Rh, Rhodium, 45, the Greek rhodos (rose coloured)",
			"Rn, Radon, 86, From radium, as it was first detected as an emission from radium during radioactive decay",
			"Ru, Ruthenium, 44, Ruthenia, the New Latin name for Russia",
			"S, Sulfur, 16, Latin sulphur (sulfur)",
			"Sb, Antimony, 51, composed from the Greek anti (against) and monos (alone)(stibium in Latin)",
			"Sc, Scandium, 21, Scandia, the Latin name for Scandinavia",
			"Se, Selenium, 34, the Greek selene (moon)",
			"Sg, Seaborgium, 106, Glenn T. Seaborg, scientist",
			"Si, Silicon, 14, from the Latin silex (flint)",
			"Sm, Samarium, 62, Samarskite, the name of the mineral from which it was first isolated",
			"Sn, Tin, 50, English word (stannum in Latin)",
			"Sr, Strontium, 38, Strontian, a small town in Scotland",
			"Ta, Tantalum, 73, King Tantalus, father of Niobe from Greek mythology",
			"Tb, Terbium, 65, Ytterby, Sweden",
			"Tc, Technetium, 43, the Greek tekhnetos (artificial)",
			"Te, Tellurium, 52, Latin tellus (earth)",
			"Th, Thorium, 90, Thor, the Scandinavian god of thunder",
			"Ti, Titanium, 22, Titans, the sons of the Earth goddess of Greek mythology",
			"Tl, Thallium, 81, the Greek thallos (green twig)",
			"Tm, Thulium, 69, Thule, the ancient name for Scandinavia",
			"U, Uranium, 92, Uranus, the seventh planet in the Solar System",
			"Uuo, Ununoctium, 118, IUPAC systematic element name",
			"Uup, Ununpentium, 115, IUPAC systematic element name",
			"Uus, Ununseptium, 117, IUPAC systematic element name",
			"Uut, Ununtrium, 113, IUPAC systematic element name",
			"V, Vanadium, 23, Vanadis, an old Norse name for the Scandinavian goddess Freyja",
			"W, Tungsten, 74, the Swedish tung sten (heavy stone)",
			"Xe, Xenon, 54, the Greek xenos (strange)",
			"Y, Yttrium, 39, Ytterby, Sweden",
			"Yb, Ytterbium, 70, Ytterby, Sweden",
			"Zn, Zinc, 30, the German Zink",
			"Zr, Zirconium, 40, Persian Zargun (gold-colored); German Zirkoon (jargoon)"
		};

		public MasterTableView (IntPtr handle) : base (handle)
		{
			TableView.RegisterClassForCellReuse (typeof(MyCell), MyCellId);
			//create a dictionary of table sections
			//key = section name, value = list os strings
			elementNames.Sort();
			indexedTableItems = new Dictionary<string, List<string>>();
			foreach (var t in elementNames) {
				if (indexedTableItems.ContainsKey (t[0].ToString ())) {
					indexedTableItems[t[0].ToString ()].Add(t);
				} else {
					indexedTableItems.Add (t[0].ToString (), new List<string>() {t});
				}
			}
			keys = indexedTableItems.Keys.ToArray ();
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return keys.Length;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			//return elementNames.Count;
			int x = 0;
			foreach (var item in elementNames) 
			{
				if (item [0].ToString () == keys [section])
					x++;
			}
			return x;
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{
			return keys;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// in a Storyboard, Dequeue will ALWAYS return a cell, 
			var cell = tableView.DequeueReusableCell (CELL_IDENTIFIER);
			// now set the properties as normal
			cell.TextLabel.Text = indexedTableItems[keys[indexPath.Section]][indexPath.Row];

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
