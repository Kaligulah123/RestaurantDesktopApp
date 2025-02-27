﻿namespace RestaurantDesktopApp.Data
{
    public static class SeedData
    {
        #region Ingles
        //    public static List<MenuCategory> GetMenuCategories()
        //    {
        //        return new List<MenuCategory>
        //    {
        //        new MenuCategory { Id = 1, Name = "Beverages", Icon = "drink.png" },
        //        new MenuCategory { Id = 2, Name = "Main Course", Icon = "meal.png" },
        //        new MenuCategory { Id = 3, Name = "Snacks", Icon = "snacks.png" },
        //        new MenuCategory { Id = 4, Name = "Desserts", Icon = "cake.png" },
        //        new MenuCategory { Id = 5, Name = "Fast Food", Icon = "fast_food.png" }
        //    };
        //    }

        //    public static List<MenuItem> GetMenuItems()
        //    {
        //        return new List<MenuItem>
        //{
        //    new MenuItem { Id = 1, Name = "Beer", Icon = "beer.png", Description = "Chilled beer", Price = 4.99m },
        //    new MenuItem { Id = 2, Name = "Biryani", Icon = "biryani.png", Description = "Spicy chicken biryani", Price = 7.99m },
        //    new MenuItem { Id = 3, Name = "Buns", Icon = "buns.png", Description = "Freshly baked buns", Price = 2.99m },
        //    new MenuItem { Id = 4, Name = "Burger and Fries Combo", Icon = "burger_fries_combo.png", Description = "Burger with fries", Price = 5.99m },
        //    new MenuItem { Id = 5, Name = "Cake", Icon = "cake.png", Description = "Delicious chocolate cake", Price = 3.99m },
        //    new MenuItem { Id = 6, Name = "Chocolate", Icon = "chocolate.png", Description = "Rich chocolate bar", Price = 1.99m },
        //    new MenuItem { Id = 7, Name = "Cocktail", Icon = "cocktail.png", Description = "Refreshing cocktail", Price = 6.99m },
        //    new MenuItem { Id = 8, Name = "Coffee", Icon = "coffee.png", Description = "Hot coffee", Price = 1.99m },
        //    new MenuItem { Id = 9, Name = "Cupcake", Icon = "cupcake.png", Description = "Sweet cupcake", Price = 2.49m },
        //    new MenuItem { Id = 10, Name = "Donut", Icon = "donut.png", Description = "Glazed donut", Price = 1.49m },
        //    new MenuItem { Id = 11, Name = "Energy Drink", Icon = "energy_drink.png", Description = "Energy drink", Price = 2.99m },
        //    new MenuItem { Id = 12, Name = "Fast Food", Icon = "fast_food.png", Description = "Quick and tasty fast food", Price = 5.99m },
        //    new MenuItem { Id = 13, Name = "Fish and Chips", Icon = "fish_and_chips.png", Description = "Crispy fish and chips", Price = 6.99m },
        //    new MenuItem { Id = 14, Name = "Fish", Icon = "fish.png", Description = "Grilled fish", Price = 7.99m },
        //    new MenuItem { Id = 15, Name = "French Fries", Icon = "french_fries.png", Description = "Crispy french fries", Price = 2.99m },
        //    new MenuItem { Id = 16, Name = "Fried Chicken", Icon = "fried_chicken.png", Description = "Crispy fried chicken", Price = 5.99m },
        //    new MenuItem { Id = 17, Name = "Fried Egg", Icon = "fried_egg.png", Description = "Sunny_side_up fried egg", Price = 1.49m },
        //    new MenuItem { Id = 18, Name = "Fried Rice", Icon = "fried_rice.png", Description = "Savory fried rice", Price = 4.99m },
        //    new MenuItem { Id = 19, Name = "Hamburger", Icon = "hamburger.png", Description = "Juicy hamburger", Price = 4.99m },
        //    new MenuItem { Id = 20, Name = "Hotdog", Icon = "hotdog.png", Description = "Grilled hotdog", Price = 3.49m },
        //    new MenuItem { Id = 21, Name = "Ice Cream", Icon = "ice_cream.png", Description = "Cold ice cream", Price = 2.99m },
        //    new MenuItem { Id = 22, Name = "Idli Platter", Icon = "idli_platter.png", Description = "South Indian idli platter", Price = 3.99m },
        //    new MenuItem { Id = 23, Name = "Kebab", Icon = "kebab.png", Description = "Grilled kebab", Price = 5.99m },
        //    new MenuItem { Id = 24, Name = "Kimchi Jjigae", Icon = "kimchi_jjiage.png", Description = "Spicy kimchi stew", Price = 6.99m },
        //    new MenuItem { Id = 25, Name = "Laddu", Icon = "laddu.png", Description = "Sweet laddu", Price = 1.99m },
        //    new MenuItem { Id = 26, Name = "Lobster", Icon = "lobster.png", Description = "Fresh lobster", Price = 15.99m },
        //    new MenuItem { Id = 27, Name = "Mango", Icon = "mango.png", Description = "Ripe mango", Price = 1.49m },
        //    new MenuItem { Id = 28, Name = "Masala Dosa", Icon = "masala_dosa.png", Description = "Crispy masala dosa", Price = 4.99m },
        //    new MenuItem { Id = 29, Name = "Meal", Icon = "meal.png", Description = "Complete meal", Price = 9.99m },
        //    new MenuItem { Id = 30, Name = "Nachos", Icon = "nachos.png", Description = "Cheesy nachos", Price = 3.99m },
        //    new MenuItem { Id = 31, Name = "Noodles", Icon = "noodles.png", Description = "Stir_fried noodles", Price = 4.99m },
        //    new MenuItem { Id = 32, Name = "Orange Juice", Icon = "orange_juice.png", Description = "Fresh orange juice", Price = 2.49m },
        //    new MenuItem { Id = 33, Name = "Pancakes", Icon = "pancakes.png", Description = "Fluffy pancakes", Price = 3.99m },
        //    new MenuItem { Id = 34, Name = "Paneer", Icon = "paneer.png", Description = "Paneer curry", Price = 4.99m },
        //    new MenuItem { Id = 35, Name = "Pasta", Icon = "pasta.png", Description = "Italian pasta", Price = 5.99m },
        //    new MenuItem { Id = 36, Name = "Pie", Icon = "pie.png", Description = "Fruit pie", Price = 3.99m },
        //    new MenuItem { Id = 37, Name = "Pizza Slice", Icon = "pizza_slice.png", Description = "Slice of pizza", Price = 2.99m },
        //    new MenuItem { Id = 38, Name = "Pizza", Icon = "pizza.png", Description = "Whole pizza", Price = 8.99m },
        //    new MenuItem { Id = 39, Name = "Ramen", Icon = "ramen.png", Description = "Japanese ramen", Price = 6.99m },
        //    new MenuItem { Id = 40, Name = "Rice", Icon = "rice.png", Description = "Steamed rice", Price = 1.99m },
        //    new MenuItem { Id = 41, Name = "Roasted Chicken", Icon = "roasted_chicken.png", Description = "Roasted chicken", Price = 7.99m },
        //    new MenuItem { Id = 42, Name = "Salad Bowl", Icon = "salad_bowl.png", Description = "Fresh salad bowl", Price = 4.99m },
        //    new MenuItem { Id = 43, Name = "Salad Plate", Icon = "salad_plate.png", Description = "Fresh salad plate", Price = 4.99m },
        //    new MenuItem { Id = 44, Name = "Samosa", Icon = "samosa.png", Description = "Crispy samosa", Price = 1.99m },
        //    new MenuItem { Id = 45, Name = "Sandwich", Icon = "sandwich.png", Description = "Tasty sandwich", Price = 3.99m },
        //    new MenuItem { Id = 46, Name = "Snacks", Icon = "snacks.png", Description = "Various snacks", Price = 2.99m },
        //    new MenuItem { Id = 47, Name = "Soda", Icon = "soda.png", Description = "Refreshing soda", Price = 1.49m },
        //    new MenuItem { Id = 48, Name = "Soft Drink", Icon = "soft_drink.png", Description = "Cold soft drink", Price = 1.99m },
        //    new MenuItem { Id = 49, Name = "Soju", Icon = "soju.png", Description = "Korean soju", Price = 3.99m },
        //    new MenuItem { Id = 50, Name = "Spaghetti", Icon = "spaghetti.png", Description = "Italian spaghetti", Price = 5.99m },
        //    new MenuItem { Id = 51, Name = "Sushi", Icon = "sushi.png", Description = "Assorted sushi", Price = 8.99m },
        //    new MenuItem { Id = 52, Name = "Taco", Icon = "taco.png", Description = "Mexican taco", Price = 3.99m },
        //    new MenuItem { Id = 53, Name = "Thai Food", Icon = "thai_food.png", Description = "Spicy Thai food", Price = 6.99m },
        //    new MenuItem { Id = 54, Name = "Thali", Icon = "thali.png", Description = "Indian thali", Price = 7.99m },
        //    new MenuItem { Id = 55, Name = "Wrap", Icon = "wrap.png", Description = "Healthy wrap", Price = 4.99m }
        //};
        //    }
        #endregion

        public static List<MenuCategory> GetMenuCategories()
        {
            return new List<MenuCategory>
            {
                new MenuCategory { Id = 1, Name = "Bebidas", Icon = "bebidas.png" },
                new MenuCategory { Id = 2, Name = "Plato Principal", Icon = "plato_principal.png" },
                new MenuCategory { Id = 3, Name = "Bocadillos", Icon = "bocadillos.png" },
                new MenuCategory { Id = 4, Name = "Postres", Icon = "postres.png" },
                new MenuCategory { Id = 5, Name = "Comida Rápida", Icon = "comida_rapida.png" }
            };
        }

        public static List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Cerveza", Icon = "cerveza.png", Description = "Cerveza fría", Price = 4.99m },               
                new MenuItem { Id = 2, Name = "Pescado Frito", Icon = "pescado_patatas.png", Description = "Pescado crujiente con patatas fritas", Price = 6.99m },
                new MenuItem { Id = 3, Name = "Panecillos", Icon = "panecillos.png", Description = "Panecillos recién horneados", Price = 2.99m },
                new MenuItem { Id = 4, Name = "Combo de Hamburguesa y Patatas Fritas", Icon = "hamburguesa.png", Description = "Hamburguesa con patatas fritas", Price = 5.99m },
                new MenuItem { Id = 5, Name = "Pastel", Icon = "pastel.png", Description = "Delicioso pastel de chocolate", Price = 3.99m },
                new MenuItem { Id = 6, Name = "Chocolate", Icon = "chocolate.png", Description = "Barra de chocolate rico", Price = 1.99m },
                new MenuItem { Id = 7, Name = "Cóctel", Icon = "cocktail.png", Description = "Cóctel refrescante", Price = 6.99m },
                new MenuItem { Id = 8, Name = "Café", Icon = "cafe.png", Description = "Café caliente", Price = 1.99m },
                new MenuItem { Id = 9, Name = "Cupcake", Icon = "cupcake.png", Description = "Dulce cupcake", Price = 2.49m },
                new MenuItem { Id = 10, Name = "Donut", Icon = "donut.png", Description = "Donut glaseado", Price = 1.49m },
                new MenuItem { Id = 11, Name = "Bebida Energética", Icon = "bebida_energetica.png", Description = "Bebida energética", Price = 2.99m },
                new MenuItem { Id = 12, Name = "Comida Rápida", Icon = "comida_rapida.png", Description = "Comida rápida y sabrosa", Price = 5.99m },
                new MenuItem { Id = 13,Name = "Biryani", Icon = "biryani.png", Description = "Biryani de pollo picante", Price = 7.99m },
                new MenuItem { Id = 14, Name = "Pescado", Icon = "pescado_parrilla.png", Description = "Pescado a la parrilla", Price = 7.99m },
                new MenuItem { Id = 15, Name = "Patatas Fritas", Icon = "patatas_fritas.png", Description = "Patatas fritas crujientes", Price = 2.99m },
                new MenuItem { Id = 16, Name = "Pollo Frito", Icon = "pollo_frito.png", Description = "Pollo frito crujiente", Price = 5.99m },
                new MenuItem { Id = 17, Name = "Huevo Frito", Icon = "huevo_frito.png", Description = "Huevo frito a la plancha", Price = 1.49m },
                new MenuItem { Id = 18, Name = "Arroz Frito", Icon = "arroz_frito.png", Description = "Arroz frito sabroso", Price = 4.99m },
                new MenuItem { Id = 19, Name = "Hamburguesa", Icon = "hamburguesa.png", Description = "Jugosa hamburguesa", Price = 4.99m },
                new MenuItem { Id = 20, Name = "Hotdog", Icon = "hotdog.png", Description = "Hotdog a la parrilla", Price = 3.49m },
                new MenuItem { Id = 21, Name = "Helado", Icon = "helado.png", Description = "Helado frío", Price = 2.99m },
                new MenuItem { Id = 22, Name = "Plato de Idli", Icon = "idli.png", Description = "Plato de idli al estilo sur de la India", Price = 3.99m },
                new MenuItem { Id = 23, Name = "Kebab", Icon = "kebab.png", Description = "Kebab a la parrilla", Price = 5.99m },
                new MenuItem { Id = 24, Name = "Kimchi Jjigae", Icon = "kimchi.png", Description = "Estofado de kimchi picante", Price = 6.99m },
                new MenuItem { Id = 25, Name = "Laddu", Icon = "laddu.png", Description = "Dulce laddu", Price = 1.99m },
                new MenuItem { Id = 26, Name = "Langosta", Icon = "langosta.png", Description = "Langosta fresca", Price = 15.99m },
                new MenuItem { Id = 27, Name = "Mango", Icon = "mango.png", Description = "Mango maduro", Price = 1.49m },
                new MenuItem { Id = 28, Name = "Masala Dosa", Icon = "masala.png", Description = "Masala dosa crujiente", Price = 4.99m },
                new MenuItem { Id = 29, Name = "Comida", Icon = "comida.png", Description = "Comida completa", Price = 9.99m },
                new MenuItem { Id = 30, Name = "Nachos", Icon = "nachos.png", Description = "Nachos con queso", Price = 3.99m },
                new MenuItem { Id = 31, Name = "Fideos", Icon = "fideos.png", Description = "Fideos salteados", Price = 4.99m },
                new MenuItem { Id = 32, Name = "Jugo de Naranja", Icon = "zumo_naranja.png", Description = "Jugo de naranja fresco", Price = 2.49m },
                new MenuItem { Id = 33, Name = "Panqueques", Icon = "panqueques.png", Description = "Panqueques esponjosos", Price = 3.99m },
                new MenuItem { Id = 34, Name = "Paneer", Icon = "paneer.png", Description = "Curry de paneer", Price = 4.99m },
                new MenuItem { Id = 35, Name = "Pasta", Icon = "pasta.png", Description = "Pasta italiana", Price = 5.99m },
                new MenuItem { Id = 36, Name = "Tarta", Icon = "tarta.png", Description = "Tarta de frutas", Price = 3.99m },
                new MenuItem { Id = 37, Name = "Rebanada de Pizza", Icon = "rebanada_pizza.png", Description = "Rebanada de pizza", Price = 2.99m },
                new MenuItem { Id = 38, Name = "Pizza", Icon = "pizza.png", Description = "Pizza completa", Price = 8.99m },
                new MenuItem { Id = 39, Name = "Ramen", Icon = "ramen.png", Description = "Ramen japonés", Price = 6.99m },
                new MenuItem { Id = 40, Name = "Arroz", Icon = "arroz.png", Description = "Arroz al vapor", Price = 1.99m },
                new MenuItem { Id = 41, Name = "Pollo Asado", Icon = "pollo_asado.png", Description = "Pollo asado", Price = 7.99m },
                new MenuItem { Id = 42, Name = "Ensalada en Bol", Icon = "ensalada.png", Description = "Ensalada fresca en bol", Price = 4.99m },
                new MenuItem { Id = 43, Name = "Plato de Ensalada", Icon = "plato_ensalada.png", Description = "Plato de ensalada fresca", Price = 4.99m },
                new MenuItem { Id = 44, Name = "Samosa", Icon = "samosa.png", Description = "Samosa crujiente", Price = 1.99m },
                new MenuItem { Id = 45, Name = "Sándwich", Icon = "sandwich.png", Description = "Sándwich sabroso", Price = 3.99m },
                new MenuItem { Id = 46, Name = "Bocadillos", Icon = "bocadillos.png", Description = "Bocadillos variados", Price = 2.99m },
                new MenuItem { Id = 47, Name = "Refresco", Icon = "refresco.png", Description = "Refresco refrescante", Price = 1.49m },
                new MenuItem { Id = 48, Name = "Bebida Gaseosa", Icon = "bebida_gaseosa.png", Description = "Bebida gaseosa fría", Price = 1.99m },
                new MenuItem { Id = 49, Name = "Soju", Icon = "soju.png", Description = "Soju coreano", Price = 3.99m },
                new MenuItem { Id = 50, Name = "Espaguetis", Icon = "spaghetti.png", Description = "Espaguetis italianos", Price = 5.99m },
                new MenuItem { Id = 51, Name = "Sushi", Icon = "sushi.png", Description = "Sushi variado", Price = 8.99m },
                new MenuItem { Id = 52, Name = "Taco", Icon = "taco.png", Description = "Taco mexicano", Price = 3.99m },
                new MenuItem { Id = 53, Name = "Comida Tailandesa", Icon = "comida_tailandesa.png", Description = "Comida tailandesa picante", Price = 6.99m },
                new MenuItem { Id = 54, Name = "Thali", Icon = "thali.png", Description = "Thali indio", Price = 7.99m },
                new MenuItem { Id = 55, Name = "Wrap", Icon = "wrap.png", Description = "Wrap saludable", Price = 4.99m }
            };
        }

        public static List<MenuItemCategoryMapping> GetMenuItemCategoryMappings()
        {
            return new List<MenuItemCategoryMapping>
            {
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 1 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 6 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 7 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 8 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 10 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 11 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 32 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 47 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 48 },
                new MenuItemCategoryMapping { MenuCategoryId = 1, MenuItemId = 49 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 2 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 13 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 14 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 18 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 20 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 22 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 23 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 24 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 26 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 28 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 29 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 31 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 34 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 35 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 38 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 39 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 40 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 41 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 45 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 50 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 51 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 52 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 53 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 54 },
                new MenuItemCategoryMapping { MenuCategoryId = 2, MenuItemId = 55 },
                new MenuItemCategoryMapping { MenuCategoryId = 3, MenuItemId = 3 },
                new MenuItemCategoryMapping { MenuCategoryId = 3, MenuItemId = 15 },
                new MenuItemCategoryMapping { MenuCategoryId = 3, MenuItemId = 16 },
                new MenuItemCategoryMapping { MenuCategoryId = 3, MenuItemId = 17 },
                new MenuItemCategoryMapping { MenuCategoryId = 3, MenuItemId = 19 },
                new MenuItemCategoryMapping { MenuCategoryId = 3, MenuItemId = 30 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 5 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 8 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 9 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 21 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 25 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 27 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 33 },
                new MenuItemCategoryMapping { MenuCategoryId = 4, MenuItemId = 36 },
                new MenuItemCategoryMapping { MenuCategoryId = 5, MenuItemId = 4 },
                new MenuItemCategoryMapping { MenuCategoryId = 5, MenuItemId = 12 },
                new MenuItemCategoryMapping { MenuCategoryId = 5, MenuItemId = 37 },
                new MenuItemCategoryMapping { MenuCategoryId = 5, MenuItemId = 38 },
                new MenuItemCategoryMapping { MenuCategoryId = 5, MenuItemId = 45 },
                new MenuItemCategoryMapping { MenuCategoryId = 5, MenuItemId = 46 }
            };
        }
    }
}
