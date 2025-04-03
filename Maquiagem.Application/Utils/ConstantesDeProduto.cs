using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.Utils
{

	public class ConstantesDeProduto
	{
		public static readonly Dictionary<string, string> Tags = new Dictionary<string, string>
		{
			{"Canadian", "Canadense"},
			{"CertClean", "Certificado Limpo"},
			{"Chemical Free", "Livre de Químicos"},
			{"Dairy Free", "Sem Lácteos"},
			{"EWG Verified", "Verificado pelo EWG"},
			{"EcoCert", "EcoCertificado"},
			{"Fair Trade", "Comércio Justo"},
			{"Gluten Free", "Sem Glúten"},
			{"Hypoallergenic", "Hipoalergênico"},
			{"Natural", "Natural"},
			{"No Talc", "Sem Talco"},
			{"Non-GMO", "Não Transgênico"},
			{"Organic", "Orgânico"},
			{"Peanut Free Product", "Produto sem Amendoim"},
			{"Sugar Free", "Sem Açúcar"},
			{"USDA Organic", "Orgânico Certificado USDA"},
			{"Vegan", "Vegano"},
			{"alcohol free", "Sem Álcool"},
			{"cruelty free", "Sem Crueldade Animal"},
			{"oil free", "Sem Óleo"},
			{"purpicks", "Purpicks (selo ecológico)"}, // Mantido por ser marca/selo
		    {"silicone free", "Sem Silicone"},
			{"water free", "Sem Água"}
		};

		public static readonly Dictionary<string, string> Categorias = new Dictionary<string, string>
		{
			{ "Powder", "Pó" },
			{ "Cream", "Creme" },
			{ "Pencil", "Lápis" },
			{ "Liquid", "Líquido" },
			{ "Gel", "Gel" },
			{ "Palette", "Paleta" },
			{ "Concealer", "Corretivo" },
			{ "Contour", "Contorno" },
			{ "Bb cc", "BB/CC Cream" },
			{ "Mineral", "Mineral" },
			{ "Highlighter", "Iluminador" },
			{ "Lipstick", "Batom" },
			{ "Lip gloss", "Brilho Labial" },
			{ "Lip stain", "Tinta Labial" }
		};

		public static readonly string[] Brands = new[]
		{
			"almay",
			"alva",
			"anna sui",
			"annabelle",
			"benefit",
			"boosh",
			"burt's bees",
			"butter london",
			"c'est moi",
			"cargo cosmetics",
			"china glaze",
			"clinique",
			"coastal classic creation",
			"colourpop",
			"covergirl",
			"dalish",
			"deciem",
			"dior",
			"dr. hauschka",
			"e.l.f.",
			"essie",
			"fenty",
			"glossier",
			"green people",
			"iman",
			"l'oreal",
			"lotus cosmetics usa",
			"maia's mineral galaxy",
			"marcelle",
			"marienatie",
			"maybelline",
			"milani",
			"mineral fusion",
			"misa",
			"mistura",
			"moov",
			"nudus",
			"nyx",
			"orly",
			"pacifica",
			"penny lane organics",
			"physicians formula",
			"piggy paint",
			"pure anada",
			"rejuva minerals",
			"revlon",
			"sally b's skin yummies",
			"salon perfect",
			"sante",
			"sinful colours",
			"smashbox",
			"stila",
			"suncoat",
			"w3llpeople",
			"wet n wild",
			"zorah",
			"zorah biocosmetiques"
		};
	}
}
