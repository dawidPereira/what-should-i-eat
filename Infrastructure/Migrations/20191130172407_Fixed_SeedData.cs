using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Fixed_SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("1297933b-3550-45bf-96b8-e54768e94484"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("1c85e237-1876-421d-8c2e-bd1cf503dae0"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("1da7da72-7fbd-4c63-ade8-abca0ac58765"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("29022244-6093-4bd2-b093-8fd5cef17d6f"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("459c640a-9597-44da-8cf5-3254aa687996"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("5c98bc26-1ff7-4bfd-9cd8-1685525269ef"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("6651ab54-35ff-43cf-a82a-601bea2cf4c9"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("99165298-34e7-4125-b36d-cebeb244b11a"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("99377e62-81f9-403c-8927-e2f78c1c8d5d"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("9e97f241-f3d6-4a7c-abfc-8fc9e35d14e5"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("9ebe6a04-16fe-4d2a-8f9d-0dac4ffa2162"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("e64653ef-cb11-4fe8-8b35-27ae6740c5e2"));

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816") });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"));

            migrationBuilder.InsertData(
                table: "IngredientMacroNutrient",
                columns: new[] { "Id", "IngredientId", "MacroNutrient", "ParticipationInIngredient" },
                values: new object[,]
                {
                    { new Guid("57f65e80-a3aa-4ee3-b951-7d84e56e99ae"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 2, 0.20000000000000001 },
                    { new Guid("08974804-0522-455f-b27c-74dee5c82cc6"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 4, 0.10000000000000001 },
                    { new Guid("e6063871-5cc4-4b85-8a63-6678065c99ed"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 8, 0.59999999999999998 },
                    { new Guid("e338f2c2-19e5-4c59-9a62-004e5e45f0bf"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 2, 0.80000000000000004 },
                    { new Guid("2e1f4904-6269-4c78-944a-6798ad2f2c8e"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 4, 0.0 },
                    { new Guid("e8e7d7b3-f1b9-4912-903a-9bc16f87e6dc"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 8, 0.20000000000000001 },
                    { new Guid("f2046a3c-49bf-4e1a-bd24-52a118dcc608"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 2, 0.69999999999999996 },
                    { new Guid("aa6e2c5d-5f9b-4537-92b7-38e964cba602"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 4, 0.10000000000000001 },
                    { new Guid("601583fe-ce9e-490e-aaa5-15eb9f6e6c5f"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 8, 0.20000000000000001 },
                    { new Guid("b740b3ba-66d3-4df1-8741-72d5d62d0c04"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 2, 0.20000000000000001 },
                    { new Guid("c6be0199-141a-45aa-a5b6-10cb156f7403"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 4, 0.10000000000000001 },
                    { new Guid("47d10650-8632-477e-8367-629d915350dc"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 8, 0.20000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "RecipeDetails_ApproximateCost", "RecipeDetails_DifficultyLevel", "RecipeDetails_MealTypes", "RecipeDetails_PreparationTime" },
                values: new object[,]
                {
                    { new Guid("e634f353-beab-443c-93a8-2988218ba59e"), "Default recipe description", "Oatmeal with milk", 8m, 2, 18, 15 },
                    { new Guid("641962f1-6c81-4c7e-af5e-b08e843e2f12"), "Default recipe description", "Chicken with rise", 10m, 2, 12, 30 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Grams" },
                values: new object[,]
                {
                    { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("e634f353-beab-443c-93a8-2988218ba59e"), 50.0 },
                    { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("e634f353-beab-443c-93a8-2988218ba59e"), 150.0 },
                    { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("641962f1-6c81-4c7e-af5e-b08e843e2f12"), 200.0 },
                    { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("641962f1-6c81-4c7e-af5e-b08e843e2f12"), 100.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("08974804-0522-455f-b27c-74dee5c82cc6"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("2e1f4904-6269-4c78-944a-6798ad2f2c8e"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("47d10650-8632-477e-8367-629d915350dc"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("57f65e80-a3aa-4ee3-b951-7d84e56e99ae"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("601583fe-ce9e-490e-aaa5-15eb9f6e6c5f"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("aa6e2c5d-5f9b-4537-92b7-38e964cba602"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("b740b3ba-66d3-4df1-8741-72d5d62d0c04"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("c6be0199-141a-45aa-a5b6-10cb156f7403"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("e338f2c2-19e5-4c59-9a62-004e5e45f0bf"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("e6063871-5cc4-4b85-8a63-6678065c99ed"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("e8e7d7b3-f1b9-4912-903a-9bc16f87e6dc"));

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumn: "Id",
                keyValue: new Guid("f2046a3c-49bf-4e1a-bd24-52a118dcc608"));

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("641962f1-6c81-4c7e-af5e-b08e843e2f12") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("641962f1-6c81-4c7e-af5e-b08e843e2f12") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("e634f353-beab-443c-93a8-2988218ba59e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("e634f353-beab-443c-93a8-2988218ba59e") });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("641962f1-6c81-4c7e-af5e-b08e843e2f12"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e634f353-beab-443c-93a8-2988218ba59e"));

            migrationBuilder.InsertData(
                table: "IngredientMacroNutrient",
                columns: new[] { "Id", "IngredientId", "MacroNutrient", "ParticipationInIngredient" },
                values: new object[,]
                {
                    { new Guid("9e97f241-f3d6-4a7c-abfc-8fc9e35d14e5"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 2, 0.20000000000000001 },
                    { new Guid("6651ab54-35ff-43cf-a82a-601bea2cf4c9"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 4, 0.10000000000000001 },
                    { new Guid("1c85e237-1876-421d-8c2e-bd1cf503dae0"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 8, 0.59999999999999998 },
                    { new Guid("1da7da72-7fbd-4c63-ade8-abca0ac58765"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 2, 0.80000000000000004 },
                    { new Guid("99165298-34e7-4125-b36d-cebeb244b11a"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 4, 0.0 },
                    { new Guid("9ebe6a04-16fe-4d2a-8f9d-0dac4ffa2162"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 8, 0.20000000000000001 },
                    { new Guid("99377e62-81f9-403c-8927-e2f78c1c8d5d"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 2, 0.69999999999999996 },
                    { new Guid("1297933b-3550-45bf-96b8-e54768e94484"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 4, 0.10000000000000001 },
                    { new Guid("29022244-6093-4bd2-b093-8fd5cef17d6f"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 8, 0.20000000000000001 },
                    { new Guid("5c98bc26-1ff7-4bfd-9cd8-1685525269ef"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 2, 0.20000000000000001 },
                    { new Guid("e64653ef-cb11-4fe8-8b35-27ae6740c5e2"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 4, 0.10000000000000001 },
                    { new Guid("459c640a-9597-44da-8cf5-3254aa687996"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 8, 0.20000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "RecipeDetails_ApproximateCost", "RecipeDetails_DifficultyLevel", "RecipeDetails_MealTypes", "RecipeDetails_PreparationTime" },
                values: new object[,]
                {
                    { new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"), "Default recipe description", "Chicken with rise", 8m, 2, 18, 15 },
                    { new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"), "Default recipe description", "Chicken with rise", 10m, 2, 12, 30 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Grams" },
                values: new object[,]
                {
                    { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"), 50.0 },
                    { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"), 150.0 },
                    { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"), 200.0 },
                    { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"), 100.0 }
                });
        }
    }
}
