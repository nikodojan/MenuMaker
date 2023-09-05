use mm_v1;

-- GroceryCategories
insert ignore into grocerycategories VALUES (1, 'Others');
insert ignore into grocerycategories VALUES (2, 'Vegetables');
insert ignore into grocerycategories VALUES (3, 'Friuts');
insert ignore into grocerycategories VALUES (4, 'Bakery');
insert ignore into grocerycategories VALUES (5, 'Meat');
insert ignore into grocerycategories VALUES (6, 'Diary');
insert ignore into grocerycategories VALUES (7, 'Drinks');
insert ignore into grocerycategories VALUES (8, 'Alcohol');

-- Groceries
insert ignore into groceries VALUES (1, 'Tomato', 2, 'g');

-- Recipes
insert ignore into recipes VALUES (1, 'Test Soup', 'Test description', null, 'Lots of text', 1, 10);

-- Ingredients
insert ignore into ingredients VALUES (1, 1, null, null, 1, null, null, 1);
