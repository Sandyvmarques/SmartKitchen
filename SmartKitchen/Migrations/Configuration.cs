namespace SmartKitchen.Migrations
{
	using SmartKitchen.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartKitchen.Models.SmartKitchenDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartKitchen.Models.SmartKitchenDB context)
        {
			//*****************************************************************************************************************************
			// adiciona Clientes
			var Cliente = new List<Clientes> {
				new Clientes {Cliente_ID=1, NomeCliente="Susana Marta", Contacto=912637284, CodigoPostal="3003-313",Morada="Rua da Liberdade", Email="susMart@mail.com",Username="susMart",Password="1AssdABHN2"},
				new Clientes {Cliente_ID=2, NomeCliente="Maria Marques", Contacto=917263284,  CodigoPostal="1542-170",Morada="Rua do Centro Republicano", Email="mariaMarq@mail.com",Username="mariaMarq",Password="AD2483mdfn9"},
				new Clientes {Cliente_ID=3, NomeCliente="Pedro Silva", Contacto=96284327, CodigoPostal="4785-150",  Morada="Rua de Marte", Email="pedroSilv@mail.com",Username="pedroSilv",Password="12MDndj9384"},
				new Clientes {Cliente_ID=4, NomeCliente="António Rocha", Contacto=927281634, CodigoPostal="3654-215",  Morada="Rua Roberto Duarte Silva", Email="AntR@mail.com",Username="AntR",Password="834h84Ak"},
				new Clientes {Cliente_ID=5, NomeCliente="Rute Roque", Contacto=916342728, CodigoPostal="1240-102",  Morada="Avenida 25 de Abril", Email="Rutxi@mail.com",Username="Rutxi",Password="238njf3DJ"},
				new Clientes {Cliente_ID=6, NomeCliente="Zé Manel", Contacto=911272634, CodigoPostal="2040-112", Morada="Rua Garrett", Email="Zeca@mail.com",Username="Zeca",Password="24984NJDFJn"}
			};
			Cliente.ForEach(cc => context.Clientes.AddOrUpdate(c => c.NomeCliente, cc));
			context.SaveChanges();

			//*****************************************************************************************************************************
			// Adiciona as 3 Categorias
			var Categorias = new List<Categorias> {
				new Categorias {Cat_ID=1, NomeCateg="Baking Tools & Gadgets", Icon="BakingTools&Gadgets.jpg" },
				new Categorias {Cat_ID=2, NomeCateg="Kitchen Tools", Icon="KitchenTools.jpg"},
				new Categorias {Cat_ID=3, NomeCateg="Cooking Gadgets", Icon="CookingGadgets.jpg"},
			 };
			Categorias.ForEach(cc => context.Categorias.AddOrUpdate(c => c.NomeCateg, cc));
			context.SaveChanges();

			//*****************************************************************************************************************************
			// adiciona os Produtos (10 produtos p/ cada Categoria)
			var produtos = new List<Produtos> {
	                                                      /*Utensílios e Gadgets de Patelaria*/
                new Produtos {Prod_ID=1, NomeProduto="OXO", CategoriasFK=1,PrecoVenda=12.99M,IVAVenda=23,Stock=10,Descricao="Imagine a world where 450 Degree truly means 450 Degree. An accurate thermometer is a must for safe and precise oven cooking, " +
				"baking, roasting and braising, but our pet peeve when using them is that they simply don't stay put. We created our chef's precision oven thermometer to stay securely in place in a wide range of ovens (we tested it in over 50 different models to be sure) " +
				"and to withstand the opening, closing, rotating and General wear and tear that comes with active oven use. The integrated clip has a unique, Inverted v-shape that grips oven racks snugly when hanging, and an angled base to provide extra stability when standing." +
				" With large, easy-to-read numbers for quick temperature readings, this sturdy thermometer will stand the test of time (and temperature)."},
				new Produtos {Prod_ID=2, NomeProduto="Pastry Cookies Piping Nozzle ", CategoriasFK=1, PrecoVenda=12.99M, IVAVenda=23,Stock=10,Descricao ="With the icing piping sets, you'll soon be decorating like a professional.Various shapes allow you and your kids set free your imagination to DIY cake/ dessert / biscuit / pastry / profitterol for birthday / family / festival party.Good choice for the professional confectionery cake decor as well",},
				new Produtos {Prod_ID=3, NomeProduto="Swirl 3 Coupler",CategoriasFK=1,PrecoVenda=4.99M,IVAVenda=23,Stock=5,Descricao="The Colour Swirl 3-Colour Coupler seamlessly blends 2-3 colour icings as you pipe. Choose from double swirl or triple swirl colours. " +
				"The interlocking coupler pieces connect multiple decorating bags, allowing you to swirl 2 or 3 colours together with one simple piping motion. Just connect and secure with the included ring. Perfect for cupcakes. Works with large tips1 m1a 2C and 4B and 16 inch decorating bags (sold separately)." +
				" This package contains three colour couplers and one cap to connect them. Hand wash only"},
				new Produtos {Prod_ID=4, NomeProduto="Cake Folder Leaf",CategoriasFK=1,  PrecoVenda=2.28M,IVAVenda=23,Stock=5,Descricao="Description " +
				"Features: " +
				"100 % Brand new and high quality. " +
				"Specially designed, easy to clean, easy to store, easy to cut, food grade plastic, ease of use. It is easy to be used and can make the cake to be leaf shape." +
				"Material: Plastic." +
				"Size: 25.5cm x 4.5cm x 4.2cm - 10.04inch x 1.77inch x 1.65inch.Color: sent at random"},
				new Produtos {Prod_ID=5, NomeProduto="Cake Ring Cutter", CategoriasFK=1,  PrecoVenda=11.99M,  IVAVenda=23  , Stock=5, Descricao="Specifications:" +
				"Material: Stainless steel" +
				"Handy and easy to use" +
				"Diameter: 6 - 7.8inch"},
				new Produtos {Prod_ID=6, NomeProduto="Bogey Man Egg Separator ", CategoriasFK=1,  PrecoVenda=6.47M,IVAVenda=23  ,  Stock=10 ,Descricao="Simply break the egg into the head of the Bogeyman Egg Separator.  " +
				"The yolk remains in the top of his head whilst the white dribbles out of his nose.  Gross or what! It may be a little distgusting, and we dont recommend you show your dinner guests your culinary skills prior to serving dinner - " +
				"but its a great little gadget to have handy in the kitchen. " },
				new Produtos {Prod_ID=7, NomeProduto="Batter Dispenser", CategoriasFK=1,  PrecoVenda=9.99M, IVAVenda=23  ,  Stock=5 ,Descricao="MisterChef® proudly presents to you our durable and reliable Pancake Batter Dispenser! " +
				"and the quick close valve makes pouring the perfect pancake like a pro seem like child's play! " +
				"Best of all, it's 1.27cm wide ",},
				new Produtos {Prod_ID=8, NomeProduto="Cake Tin Pan", CategoriasFK=1,  PrecoVenda=13.60M, IVAVenda=23  , Stock=5,   Descricao="The most amazing Cake tin pan that allows you to  Creat Cakes in shape of Letters or Numbers! "},
				new Produtos {Prod_ID=9, NomeProduto="Wisk Wiper",CategoriasFK=1,  PrecoVenda=10.12M,   IVAVenda=23  , Stock=10, Descricao="Whisk Wiper® is the popular multipurpose whisk-cleaning kitchen tool. Cleaning a whisk no longer has to be messy, wasteful, and tedious. ",},
				new Produtos {Prod_ID=10, NomeProduto="Self-leveling Measuring Spoons",  CategoriasFK=1,  PrecoVenda=18.59M,  IVAVenda=23 ,Stock=5,   Descricao="Levoons are our ingenious leveling measuring spoons. " +
				"They look like regular measuring spoons until you squeeze their handles to make a scraper swipe across and push off all the excess ingredients, giving you a perfectly level and accurate measurement. They are a set of 4 measuring spoons that snap together for storage," +
				" fan out for easy selection and can be easily snapped apart so you only have to wash the dirty ones. "},
   
  		                                                        /*Utensílios de Cozinha*/
                new Produtos {Prod_ID=11, NomeProduto="Vegetable Chopper Mandoline   ",  CategoriasFK=2 , PrecoVenda=25.99M, IVAVenda=23 ,Stock=10,   Descricao="The Fullstar Chop ‘n Slice PRO lets you tackle all of your slicing," +
				" dicing and grating needs with just 1 convenient kitchen tool. Dice onions quickly and skip the tears. Cube cheese in just seconds when unexpected guests drop buy." +
				" Treat your family to healthy meal. Nicer than competing choppers with fewer accessories, " +
				"the Chop ‘n Slice PRO lets you deftly prepare homemade breakfasts, " +
				"lunches and dinners to tantalize your family’s taste buds."},
				new Produtos {Prod_ID=12, NomeProduto="Ronco Handi Slicer " ,CategoriasFK=2,  PrecoVenda=12.99M,IVAVenda=23,  Stock=10,Descricao=" Cut fruits and veggies with 5 times the speed of a knife " },
				new Produtos {Prod_ID=13, NomeProduto="Defrosting Tray ", CategoriasFK=2,  PrecoVenda=4.99M, IVAVenda=23  , Stock=5, Descricao="Defrosting Tray with Enamel-Coated Surface and Removable Base, Green and Grey "},
				new Produtos {Prod_ID=14, NomeProduto="Avocado Slicer 3-in-1",  CategoriasFK=2,  PrecoVenda=2.28M, IVAVenda=23  , Stock=5, Descricao="Splits, pits and slices avocados safely and effectively. Perfect for salads and sandwiches. "},
				new Produtos {Prod_ID=15, NomeProduto="Watermelon Slicer ",  CategoriasFK=2,  PrecoVenda=11.99M, IVAVenda=23  ,Stock=5, Descricao=" A whole watermelon sliced up perfectly in just seconds. Sounds too good to be true, but it's real. Check out our cool slicer and see for yourself how neat and easy life can be. No dirty, sticky and wet counters. You create a bowl out of the rind, so no fruit or juice is wasted! An ideal gift for a family member," +
				" friend.Dishwasher safe and easy to store in any drawer. "},
				new Produtos {Prod_ID=16, NomeProduto="Drink Frother Wand ", CategoriasFK=2,  PrecoVenda=6.47M,  IVAVenda=23  ,Stock=10, Descricao="Ultra-low-power design, elegant look, energy saving and sustainable for use anywhere anytime. " +
				"Ergonomic handle design of beer frother wand fits snugly in hand, providing excellent control for creating latte art or stencils." +
				"Easy to use.You just need to put one side into the bottle with the beer and it will make foams in several seconds. "},
				new Produtos {Prod_ID=17,  NomeProduto="Steam Ship Lids ",CategoriasFK=2, PrecoVenda=9.99M, IVAVenda=23  ,  Stock=5,  Descricao="This pack of 3 exciting and unique steamer lids is an ideal microwave and stove top lid that will make cooking a fun time for all." +
				"Watch as the steam puffs out of the funnels of the ship that rides on top of the lid. This steam lid is constructed from heavy duty silicone. It's a product that combines fun and functionality in one." +
				"Comes in 3 different sizes to suit a variety of cooking pots. Small (14cm), Medium (20cm), Large (26cm)"},
				new Produtos {Prod_ID=18, NomeProduto="The Dipr the Ultimate Cookie Spoon ", CategoriasFK=2,  PrecoVenda=13.60M, IVAVenda=23  , Stock=5,  Descricao="he dipr is a spoon that holds your sandwich cookie while you dip it in milk or" +
				" other liquid. "},
				new Produtos {Prod_ID=19,NomeProduto="Citrus Fruit Sprayer ",CategoriasFK=2,  PrecoVenda=10.12M, IVAVenda=23  , Stock=10, Descricao="Citrus Fruit Sprayer " +
				"Ideal for Lemons, Limes, Grapefruit all type of citrus fruits" +
				"Includes dish for holding / storing the fruit whilst in use "},
				new Produtos {Prod_ID=20, NomeProduto="3 IN 1 APPLE FRUIT PEELER",  CategoriasFK=2, PrecoVenda=18.59M, IVAVenda=23  , Stock=5, Descricao="Simply place the apple on the three pronged fork and rotate the handle to peel, core and slice " +
				"the apple in one easy action. " +
				"Adjustable blades for peeling, slicing and coring. (Note: All blades are adjustable and within seconds you can either jut core and slice the apple, or remove the corer and slicer blade to give just a wonderfully peeled apple.)" +
				"Enameler steel body with stainless steel cutters. " },
  
   												        /*Gadgets de Cozinha*/
                new Produtos {Prod_ID=21,NomeProduto="SUSHEZI  ",  CategoriasFK=3,  PrecoVenda=25.99M, IVAVenda=23  , Stock=10,  Descricao="Entertain your guests with perfect sushi every time with the Sushi Bazooka." +
				"All it takes is three easy steps to provide roll after roll of perfect sushi that will stun and surprise your guests." +
				"Tha bazooka comes with easy to follow instructions taking out the guesswork allowing you to avoid trial and error. Instead of sticking to the tried and tested rolls you can be as creative as you want making is simply to accomodate fussy eaters and those who intolerances." +
				"Why keep it to main cause of fish based sushi - try some dessert options." },
				new Produtos {Prod_ID=22, NomeProduto="Divided Frying Pan for All-in-One Cooked Breakfast & More! ",  CategoriasFK=3,  PrecoVenda=12.99M,  IVAVenda=23  ,Stock=10, Descricao="Our mission at MasterPan is to provide you with quality innovative" +
				" cookware that we feel will make a difference in your kitchen. Professional cooks and regular home cooks just like you have tested and loved our products. Now it’s your turn to own and try one. Our company has years of innovation in product design and development for many large corporates allowing " +
				"us to now deliver a market leading quality product directly to you. We firmly believe our designers passion for cooking and a love of food is all you need in creating the perfect MasterPan. With more new designs to follow, like us on Facebook and subscribe to see what will be the next new thing we " +
				"create that you won’t be able to live without ! " },
				new Produtos {Prod_ID=23,NomeProduto="Quick Breakfast Sandwich Burger Muffin ", CategoriasFK=3, PrecoVenda=11.99M, IVAVenda=23  ,  Stock=5, Descricao=": Breakfast Sandwich Maker. Quick and fun way to make breakfast " +
				"in just 5 minutes, yes 5 minutes and you're done ! Café style breakfast sandwiches can now be made in your own home. You can use any ingredients, eggs, cheese etc. All parts are dishwasher safe with rubber skid proof feet & a non-stick coated plate. "},
				new Produtos {Prod_ID=24, NomeProduto="Tupperware MicroPro Grill ",   CategoriasFK=3,  PrecoVenda=6.47M,IVAVenda=23  , Stock=10,  Descricao="Dinnertime has officially been changed forever with the introduction of our latest " +
				"product—the MicroPro™ Grill. Tupperware is grilling in the microwave. We know, it sounds a little crazy. But once you’ve tried it, there’s no going back to conventional mealtime. This revolutionary product heats up to 425° F/220° C and is programed to stop at that temperature, grilling or " +
				"cooking your meals to perfection in the microwave. You’ll be amazed when you hear the beep—followed by a sizzle. "},
				new Produtos {Prod_ID=25,NomeProduto="Hot Dog Steamer",  CategoriasFK=3,  PrecoVenda=13.60M, IVAVenda=23  ,Stock=5,  Descricao="CuiZen's Hotdog Steamer gives you the best possible way to enjoy hotdogs at home." +
				" Steams up to 12 Hot Dogs & 12 Buns at one time. The steamer can even be used on a wide variety of other foods. Includes a recipe booklet with 40 variations. " },
				new Produtos {Prod_ID=26,NomeProduto="3-in-1 Multifunction Breakfast Center ",  CategoriasFK=3,  PrecoVenda=10.12M, IVAVenda=23  , Stock=10,  Descricao="The Breakfast Center is small and compact," +
				" making it the perfect appliance for smaller kitchens, dorm rooms and RV’s. Brew fresh coffee, toast or warm biscuits, and fry bacon all with one single appliance. This all-in-one appliance is compact, easy to clean, and durable. "},
				new Produtos {Prod_ID=27, NomeProduto="Portable Cheese Melt ",  CategoriasFK=3,  PrecoVenda=18.59M,IVAVenda=23  ,  Stock=5,Descricao="For those with a soft spot for fromage, it's okay" +
				" to get a little cheesy now and then. With this portable melter, you can transform your favorite cheese into melty magnificence in just four minutes with the heat of three tea lights. Use the included mini-spatula to scoop the melted cheese onto crostini or crackers. " +
				"The tray and heating base fold up for compact storage and picnic portability, and the base is perforated with a pattern of Swiss cheese holes for a touch of whimsy. The solid sapele wood and metal construction make this tempting tool a lasting addition to your cheese accoutrements." +
				" sapele wood sourced from Germany; assembled in Taiwan." },
				new Produtos {Prod_ID=28,NomeProduto="Dash Clear View Toaster", CategoriasFK=3, PrecoVenda=20.12M,IVAVenda=23  ,  Stock=5,Descricao="Imagine perfect toast, every time. With 7 browning levels, the Dash Clear View Toaster" +
				" takes the guesswork out of toasting. Don't take our word for it - see with your own eyes via the glass window. The toaster features one-touch buttons for defrosting, bagels and re-heating as well as an auto-shut off function for safety. With an extra long slot, you can toast a wide " +
				"variety of breads and baked goods. Unprocess your food with the recipe book that is included with purchase, and gain access to our database of thousands of recipes for free "},
				new Produtos {Prod_ID=29, NomeProduto="Bacon Express Grill ",CategoriasFK=3, PrecoVenda=25.42M,  IVAVenda=23 ,Stock=5, Descricao="Introducing a healthier way to cook bacon to delicious perfection!" +
				" Easily cook up to 6-strips of lean thin cut bacon in just minutes – no need to flip! Simply adjust the illuminated dial timer to your desired cooking preference, and allow the unique vertical cooking method to drain away fat and grease for fast, healthy cooking." },
				new Produtos {Prod_ID=30, NomeProduto="Outdoor Pizza Oven", CategoriasFK=3,  PrecoVenda=5.64M,  IVAVenda=23  ,Stock=10, Descricao="The Cuisinart Alfrescamoré Outdoor Pizza Oven is designed to replicate" +
				" the perfect pizza environment of a brick oven, using convection, conduction, and reflected heat to create even cooking temperatures. This ensures crisp, evenly cooked, delicious homemade pizzas that are cooked from the bottom up the way they are supposed to." +
				" Built to the highest quality standards that Cuisinart is famous for. "},
			};
			produtos.ForEach(vv => context.Produtos.AddOrUpdate(v => v.NomeProduto, vv));
			context.SaveChanges();
			//*****************************************************************************************************************************
			// adiciona  max 3 Imagens por cada Produto 
			var Imagem = new List<Imagens> {
                /*Utensílios e Gadgets de Patelaria*/
                new Imagens {Imagem_ID=11, Img="OXO.jpg",Ordem="",Produto=produtos[0]},
				new Imagens {Imagem_ID=12, Img="OXO2.jpg",Ordem="",Produto=produtos[0]},
				new Imagens {Imagem_ID=13,Img="PastryCookies.jpg",Ordem="",Produto=produtos[1]},
				new Imagens {Imagem_ID=14,Img="PastryCookies2.jpg",Ordem="",Produto=produtos[1]},
				new Imagens {Imagem_ID=16, Img="Swirl.jpg",Ordem="",Produto=produtos[2]},
				new Imagens {Imagem_ID=17, Img="Swirl2.jpg",Ordem="",Produto=produtos[2]},
				new Imagens {Imagem_ID=5, Img="CakeFolder.jpg",Ordem="",Produto=produtos[3]},
				new Imagens {Imagem_ID=6, Img="CakeFolder2.jpg",Ordem="",Produto=produtos[3]},
				new Imagens {Imagem_ID=7,Img="CakeRing.jpg",Ordem="",Produto=produtos[4]},
				new Imagens {Imagem_ID=8,Img="CakeRing2.jpg",Ordem="",Produto=produtos[4]},
				new Imagens {Imagem_ID=3,Img="BogeyMan.jpg",Ordem="",Produto=produtos[5]},
				new Imagens {Imagem_ID=4, Img="BogeyMan2.jpg",Ordem="" ,Produto=produtos[5]},
				new Imagens {Imagem_ID=1,Img="BatterDispenser.jpg",Ordem="",Produto=produtos[6]},
				new Imagens {Imagem_ID=2,Img="BatterDispenser2.jpg",Ordem="",Produto=produtos[6]},
				new Imagens {Imagem_ID=9,Img="CakeTin.jpg",Ordem="",Produto=produtos[7]},
				new Imagens {Imagem_ID=10, Img="CakeTin2.jpg",Ordem="" ,Produto=produtos[7]},
				new Imagens {Imagem_ID=18,Img="Whisk.jpg",Ordem="",Produto=produtos[8]},
				new Imagens {Imagem_ID=19,Img="Whisk2.jpg",Ordem="",Produto=produtos[8]},
				new Imagens {Imagem_ID=15,Img="SelfLeveling.jpg",Ordem="",Produto=produtos[9]},

                      /*Utensílios de Cozinha*/
                new Imagens {Imagem_ID=40,Img="VegetableChopper.jpg",Ordem="",Produto=produtos[10]},
				new Imagens {Imagem_ID=41,Img="VegetableChopper2.jpg",Ordem="",Produto=produtos[10]},
				new Imagens {Imagem_ID=42, Img="VegetableChopper3.jpg",Ordem="",Produto=produtos[10]},
				new Imagens {Imagem_ID=32, Img="RoncoSlicer1.jpg",Ordem="",Produto=produtos[11]},
				new Imagens {Imagem_ID=33,Img="RoncoSlicer2.jpg",Ordem="",Produto=produtos[11]},
				new Imagens {Imagem_ID=34,Img="RoncoSlicer3.jpg",Ordem="",Produto=produtos[11]},
				new Imagens {Imagem_ID=26,Img="DefrostingTray.jpg",Ordem="",Produto=produtos[12]},
				new Imagens {Imagem_ID=28,Img="DefrostingTray2.jpg",Ordem="",Produto=produtos[12]},
				new Imagens {Imagem_ID=22,Img="AvocadoSlicer.jpg",Ordem="",Produto=produtos[13]},
				new Imagens {Imagem_ID=23, Img="AvocadoSlicer2.jpg" ,Ordem="",Produto=produtos[13]},
				new Imagens {Imagem_ID=43, Img="WatermelonSlicer.jpg",Ordem="",Produto=produtos[14]},
				new Imagens {Imagem_ID=44,Img="WatermelonSlicer2.jpg",Ordem="",Produto=produtos[14]},
				new Imagens {Imagem_ID=29,Img="DrinkWand.jpg",Ordem="",Produto=produtos[15]},
				new Imagens {Imagem_ID=30, Img="DrinkWand2.jpg" ,Ordem="",Produto=produtos[15]},
				new Imagens {Imagem_ID=31, Img="DrinkWand3.jpg",Ordem="",Produto=produtos[15]},
				new Imagens {Imagem_ID=35,Img="SteamLids.jpg",Ordem="",Produto=produtos[16]},
				new Imagens {Imagem_ID=36, Img="SteamLids2.jpg",Ordem="",Produto=produtos[16] },
				new Imagens {Imagem_ID=37, Img="SteamLids3.jpg",Ordem="",Produto=produtos[16]},
				new Imagens {Imagem_ID=38,Img="TheDipr.jpg",Ordem="",Produto=produtos[17]},
				new Imagens {Imagem_ID=39,Img="TheDipr2.jpg",Ordem="",Produto=produtos[17]},
				new Imagens {Imagem_ID=24, Img="CitrusSprayer.jpg",Ordem="",Produto=produtos[18]},
				new Imagens {Imagem_ID=25, Img="CitrusSprayer2.jpg",Ordem="",Produto=produtos[18]},
				new Imagens {Imagem_ID=20,Img="AppleFruiter.jpg",Ordem="",Produto=produtos[19]},
				new Imagens {Imagem_ID=21,Img="AppleFruiter2.jpg",Ordem="",Produto=produtos[19]},
        
                          /*Gadgets de Cozinha*/
                new Imagens {Imagem_ID=65,Img="SUSHEZI2.jpg",Ordem="",Produto=produtos[20]},
				new Imagens {Imagem_ID=66, Img="SUSHEZI3.jpg",Ordem="",Produto=produtos[20]},
				new Imagens {Imagem_ID=67, Img="SUSHEZI.jpg",Ordem="",Produto=produtos[20]},
				new Imagens {Imagem_ID=49, Img="DividedFryingPan.jpg",Ordem="",Produto=produtos[21]},
				new Imagens {Imagem_ID=50, Img="DividedFryingPan2.jpg", Ordem="",Produto=produtos[21]},
				new Imagens {Imagem_ID=62, Img="QuickBreakfastMuffin.jpg", Ordem="",Produto=produtos[22]},
				new Imagens {Imagem_ID=63, Img="QuickBreakfastMuffin2.jpg", Ordem="",Produto=produtos[22]},
				new Imagens {Imagem_ID=64, Img="QuickBreakfastMuffin3.jpg", Ordem="",Produto=produtos[22]},
				new Imagens {Imagem_ID=68, Img="TupperwareMicroPro.jpg", Ordem="",Produto=produtos[23]},
				new Imagens {Imagem_ID=69, Img="TupperwareMicroPro2.jpg", Ordem="",Produto=produtos[23]},
				new Imagens {Imagem_ID=70, Img="TupperwareMicroPro3.jpg", Ordem="",Produto=produtos[23]},
				new Imagens {Imagem_ID=51, Img="HotDogSteamer.jpg", Ordem="",Produto=produtos[24]},
				new Imagens {Imagem_ID=52, Img="HotDogSteamer2.jpg", Ordem="",Produto=produtos[24]},
				new Imagens {Imagem_ID=53, Img="MultifunctionBreakfast.jpg", Ordem="",Produto=produtos[25]},
				new Imagens {Imagem_ID=54, Img="MultifunctionBreakfast2.jpg", Ordem="",Produto=produtos[25]},
				new Imagens {Imagem_ID=55, Img="MultifunctionBreakfast3.jpg", Ordem="",Produto=produtos[25]},
				new Imagens {Imagem_ID=59, Img="PortableCheese .jpg", Ordem="",Produto=produtos[26]},
				new Imagens {Imagem_ID=60, Img="PortableCheese 2.jpg", Ordem="",Produto=produtos[26]},
				new Imagens {Imagem_ID=61, Img="PortableCheese 3.jpg", Ordem="",Produto=produtos[26]},
				new Imagens {Imagem_ID=47, Img="DashToaster.jpg", Ordem="",Produto=produtos[27]},
				new Imagens {Imagem_ID=48, Img="DashToaster2.jpg", Ordem="" ,Produto=produtos[27]},
				new Imagens {Imagem_ID=45, Img="BaconGrill.jpg", Ordem="",Produto=produtos[28]},
				new Imagens {Imagem_ID=46, Img="BaconGrill2.jpg", Ordem="",Produto=produtos[28]},
				new Imagens {Imagem_ID=56, Img="OutdoorPizzaOven.jpg", Ordem="",Produto=produtos[29]},
				new Imagens {Imagem_ID=57, Img="OutdoorPizzaOven2.jpg", Ordem="",Produto=produtos[29]},
				new Imagens {Imagem_ID=58, Img="OutdoorPizzaOven3.jpg", Ordem="",Produto=produtos[29]},

			 };
			Imagem.ForEach(cc => context.Imagens.AddOrUpdate(c => c.Imagem_ID, cc));
			context.SaveChanges();
			//*****************************************************************************************************************************
			// adiciona Encomendas 
			var Encomenda = new List<Encomendas> {
				new Encomendas {Encomenda_ID=1, DataVenda=new DateTime(2018,12,15), ClienteFK=1, PrecoTotal=36.45M},
				new Encomendas {Encomenda_ID=2, DataVenda=new DateTime(2018,5,25), ClienteFK=2, PrecoTotal= 4.99M},
				new Encomendas {Encomenda_ID=3, DataVenda=new DateTime(2018,10,2), ClienteFK=3, PrecoTotal= 43.98M},
				new Encomendas {Encomenda_ID=4, DataVenda=new DateTime(2018,9,3), ClienteFK=4, PrecoTotal=18.46M},
				new Encomendas {Encomenda_ID=5, DataVenda=new DateTime(2018,11,30), ClienteFK=5, PrecoTotal=52.27M},
				new Encomendas {Encomenda_ID=6, DataVenda=new DateTime(2018,2,12), ClienteFK=6, PrecoTotal= 5.99M}
			};
			Encomenda.ForEach(cc => context.Encomendas.AddOrUpdate(c => c.DataVenda, cc));
			context.SaveChanges();
			//*****************************************************************************************************************************
			//ligação entre as encomendas e os produtos comprados 
			var EncomendaProduto = new List<EncProd> {
				new EncProd {EncomendasFK=1, Produto=produtos[1], QuantidVendida=3, PrecoCompra=11.99M,IVA_Compra=23},
				new EncProd {EncomendasFK=1, Produto=produtos[29], QuantidVendida=23, PrecoCompra=5.00M,IVA_Compra=23},
				new EncProd {EncomendasFK=1, Produto=produtos[23], QuantidVendida=30, PrecoCompra=5.47M,IVA_Compra=23},
				new EncProd {EncomendasFK=1, Produto=produtos[11], QuantidVendida=3, PrecoCompra=13.99M,IVA_Compra=23},
				new EncProd {EncomendasFK=2, Produto=produtos[2], QuantidVendida=4, PrecoCompra=4.99M,IVA_Compra=23},
				new EncProd {EncomendasFK=3, Produto=produtos[0], QuantidVendida=1, PrecoCompra=12.99M,IVA_Compra=23},
				new EncProd {EncomendasFK=3, Produto=produtos[25], QuantidVendida=1, PrecoCompra=10.12M,IVA_Compra=23},
				new EncProd {EncomendasFK=3, Produto=produtos[13], QuantidVendida=1, PrecoCompra=2.28M,IVA_Compra=23},
				new EncProd {EncomendasFK=3, Produto=produtos[26], QuantidVendida=1, PrecoCompra=18.59M,IVA_Compra=23},
				new EncProd {EncomendasFK=4, Produto=produtos[5], QuantidVendida=2, PrecoCompra=6.47M,IVA_Compra=23},
				new EncProd {EncomendasFK=4, Produto=produtos[4], QuantidVendida=2, PrecoCompra=11.99M,IVA_Compra=23},
				new EncProd {EncomendasFK=5, Produto=produtos[10], QuantidVendida=4, PrecoCompra=24.99M,IVA_Compra=23},
				new EncProd {EncomendasFK=5, Produto=produtos[20], QuantidVendida=4, PrecoCompra=25.00M,IVA_Compra=23},
				new EncProd {EncomendasFK=5, Produto=produtos[3], QuantidVendida=4, PrecoCompra=2.28M,IVA_Compra=23},
				new EncProd {EncomendasFK=6, Produto=produtos[12], QuantidVendida=5, PrecoCompra=5.99M,IVA_Compra=23 }
			 };
			EncomendaProduto.ForEach(cc => context.EncProd.AddOrUpdate(c => c.EncomendasFK, cc));
			context.SaveChanges();
		}
    }
}
