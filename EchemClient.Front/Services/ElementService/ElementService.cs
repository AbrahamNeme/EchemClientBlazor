using EchemClient.Front.Models;

namespace EchemClient.Front.Services.ElementService
{
    public class ElementService : IElementService
    {
        public List<Element> Elements => new() {
                new Element("H", "Hydrogen", "reactive non-metals", 1, 1.008),
                new Element("He", "Helium", "noble gases", 2, 4.0026),
                new Element("Li", "Lithium", "alkali metals", 3, 6.94),
                new Element("Be", "Beryllium", "alkaline earth metals", 4, 9.0122),
                new Element("B", "Boron", "metalloids", 5, 10.81),
                new Element("C", "Carbon", "reactive non-metals", 6, 12.011),
                new Element("N", "Nitrogen", "reactive non-metals", 7, 14.007),
                new Element("O", "Oxygen", "reactive non-metals", 8, 15.999),
                new Element("F", "Fluorine", "reactive non-metals", 9, 18.998),
                new Element("Ne", "Neon", "noble gases", 10, 20.180),
                new Element("Na", "Sodium", "alkali metals", 11, 22.990),
                new Element("Mg", "Magnesium", "alkaline earth metals", 12, 24.305),
                new Element("Al", "Aluminum", "post-transition metals", 13, 26.982),
                new Element("Si", "Silicon", "metalloids", 14, 28.085),
                new Element("P", "Phosphorus", "reactive non-metals", 15, 30.974),
                new Element("S", "Sulfur", "reactive non-metals", 16, 32.06),
                new Element("Cl", "Chlorine", "reactive non-metals", 17, 35.45),
                new Element("Ar", "Argon", "noble gases", 18, 39.948),
                new Element("K", "Potassium", "alkali metals", 19, 39.098),
                new Element("Ca", "Calcium", "alkaline earth metals", 20, 40.078),
                new Element("Sc", "Scandium", "transition metals", 21, 44.956),
                new Element("Ti", "Titanium", "transition metals", 22, 47.867),
                new Element("V", "Vanadium", "transition metals", 23, 50.942),
                new Element("Cr", "Chromium", "transition metals", 24, 51.996),
                new Element("Mn", "Manganese", "transition metals", 25, 54.938),
                new Element("Fe", "Iron", "transition metals", 26, 55.845),
                new Element("Ni", "Nickel", "transition metals", 28, 58.693),
                new Element("Co", "Cobalt", "transition metals", 27, 58.933),
                new Element("Cu", "Copper", "transition metals", 29, 63.546),
                new Element("Zn", "Zinc", "transition metals", 30, 65.38),
                new Element("Ga", "Gallium", "post-transition metals", 31, 69.723),
                new Element("Ge", "Germanium", "metalloids", 32, 72.630),
                new Element("As", "Arsenic", "metalloids", 33, 74.922),
                new Element("Se", "Selenium", "reactive non-metals", 34, 78.971),
                new Element("Br", "Bromine", "reactive non-metals", 35, 79.904),
                new Element("Kr", "Krypton", "noble gases", 36, 83.798),
                new Element("Rb", "Rubidium", "alkali metals", 37, 85.468),
                new Element("Sr", "Strontium", "alkaline earth metals", 38, 87.62),
                new Element("Y", "Yttrium", "transition metals", 39, 88.906),
                new Element("Zr", "Zirconium", "transition metals", 40, 91.224),
                new Element("Nb", "Niobium", "transition metals", 41, 92.906),
                new Element("Mo", "Molybdenum", "transition metals", 42, 95.95),
                new Element("Tc", "Technetium", "transition metals", 43, 98),
                new Element("Ru", "Ruthenium", "transition metals", 44, 101.07),
                new Element("Rh", "Rhodium", "transition metals", 45, 102.91),
                new Element("Pd", "Palladium", "transition metals", 46, 106.42),
                new Element("Ag", "Silver", "transition metals", 47, 107.87),
                new Element("Cd", "Cadmium", "transition metals", 48, 112.41),
                new Element("In", "Indium", "post-transition metals", 49, 114.82),
                new Element("Sn", "Tin", "post-transition metals", 50, 118.71),
                new Element("Sb", "Antimony", "metalloids", 51, 121.76),
                new Element("Te", "Tellurium", "metalloids", 52, 127.60),
                new Element("I", "Iodine", "reactive non-metals", 53, 126.90),
                new Element("Xe", "Xenon", "noble gases", 54, 131.29),
                new Element("Cs", "Cesium", "alkali metals", 55, 132.91),
                new Element("Ba", "Barium", "alkaline earth metals", 56, 137.33),
                new Element("La", "Lanthanum", "lanthanoids", 57, 138.91),
                new Element("Ce", "Cerium", "lanthanoids", 58, 140.12),
                new Element("Pr", "Praseodymium", "lanthanoids", 59, 140.91),
                new Element("Nd", "Neodymium", "lanthanoids", 60, 144.24),
                new Element("Pm", "Promethium", "lanthanoids", 61, 145),
                new Element("Sm", "Samarium", "lanthanoids", 62, 150.36),
                new Element("Eu", "Europium", "lanthanoids", 63, 151.96),
                new Element("Gd", "Gadolinium", "lanthanoids", 64, 157.25),
                new Element("Tb", "Terbium", "lanthanoids", 65, 158.93),
                new Element("Dy", "Dysprosium", "lanthanoids", 66, 162.50),
                new Element("Ho", "Holmium", "lanthanoids", 67, 164.93),
                new Element("Er", "Erbium", "lanthanoids", 68, 167.26),
                new Element("Tm", "Thulium", "lanthanoids", 69, 168.93),
                new Element("Yb", "Ytterbium", "lanthanoids", 70, 173.04),
                new Element("Lu", "Lutetium", "lanthanoids", 71, 174.97),
                new Element("Hf", "Hafnium", "transition metals", 72, 178.49),
                new Element("Ta", "Tantalum", "transition metals", 73, 180.95),
                new Element("W", "Tungsten", "transition metals", 74, 183.84),
                new Element("Re", "Rhenium", "transition metals", 75, 186.21),
                new Element("Os", "Osmium", "transition metals", 76, 190.23),
                new Element("Ir", "Iridium", "transition metals", 77, 192.22),
                new Element("Pt", "Platinum", "transition metals", 78, 195.08),
                new Element("Au", "Gold", "transition metals", 79, 196.97),
                new Element("Hg", "Mercury", "transition metals", 80, 200.59),
                new Element("Tl", "Thallium", "post-transition metals", 81, 204.38),
                new Element("Pb", "Lead", "post-transition metals", 82, 207.2),
                new Element("Bi", "Bismuth", "post-transition metals", 83, 208.98),
                new Element("Po", "Polonium", "post-transition metals", 84, 209),
                new Element("At", "Astatine", "metalloids", 85, 210),
                new Element("Rn", "Radon", "noble gases", 86, 222),
                new Element("Fr", "Francium", "alkali metals", 87, 223),
                new Element("Ra", "Radium", "alkaline earth metals", 88, 226),
                new Element("Ac", "Actinium", "actinoids", 89, 227),
                new Element("Th", "Thorium", "actinoids", 90, 232.04),
                new Element("Pa", "Protactinium", "actinoids", 91, 231.04),
                new Element("U", "Uranium", "actinoids", 92, 238.03),
                new Element("Np", "Neptunium", "actinoids", 93, 237),
                new Element("Pu", "Plutonium", "actinoids", 94, 244),
                new Element("Am", "Americium", "actinoids", 95, 243),
                new Element("Cm", "Curium", "actinoids", 96, 247),
                new Element("Bk", "Berkelium", "actinoids", 97, 247),
                new Element("Cf", "Californium", "actinoids", 98, 251),
                new Element("Es", "Einsteinium", "actinoids", 99, 252),
                new Element("Fm", "Fermium", "actinoids", 100, 257),
                new Element("Md", "Mendelevium", "actinoids", 101, 258),
                new Element("No", "Nobelium", "actinoids", 102, 259),
                new Element("Lr", "Lawrencium", "actinoids", 103, 262),
                new Element("Rf", "Rutherfordium", "transition metals", 104, 267),
                new Element("Db", "Dubnium", "transition metals", 105, 270),
                new Element("Sg", "Seaborgium", "transition metals", 106, 271),
                new Element("Bh", "Bohrium", "transition metals", 107, 270),
                new Element("Hs", "Hassium", "transition metals", 108, 277),
                new Element("Mt", "Meitnerium", "unknown", 109, 276),
                new Element("Ds", "Darmstadtium", "unknown", 110, 281),
                new Element("Rg", "Roentgenium", "unknown", 111, 280),
                new Element("Cn", "Copernicium", "unknown", 112, 285),
                new Element("Nh", "Nihonium", "unknown", 113, 284),
                new Element("Fl", "Flerovium", "unknown", 114, 289),
                new Element("Mc", "Moscovium", "unknown", 115, 288),
                new Element("Lv", "Livermorium", "unknown", 116, 293),
                new Element("Ts", "Tennessine", "unknown", 117, 294),
                new Element("Og", "Oganesson", "unknown", 118, 294),
        };

        public Element GetElementBySymbol(string symbol)
        {
            return Elements.Where(e => e.Symbol == symbol).First();
        }

        public List<Element> FromStringToList(string elements)
        {
            List<string> stringsList = elements.Split(' ').ToList();
            List<Element> elementsList = [];

            if (stringsList.Count > 0)
            {
                foreach (string element in stringsList)
                {
                    elementsList.AddRange(Elements.Where(e => e.Symbol == element).ToList());
                }
            }
            return elementsList;
        }
    }
}
