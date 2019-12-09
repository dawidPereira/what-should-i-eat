using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatShouldIEat.Administration.Infrastructure.Migrations
{
    public partial class Added_PrimaryKey_To_IngredientMacroNutrients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientMacroNutrient",
                table: "IngredientMacroNutrient");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_IngredientMacroNutrient_Id_IngredientId",
                table: "IngredientMacroNutrient");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientMacroNutrient",
                table: "IngredientMacroNutrient",
                columns: new[] { "Id", "IngredientId" });

            migrationBuilder.InsertData(
                table: "IngredientMacroNutrient",
                columns: new[] { "Id", "IngredientId", "MacroNutrient", "ParticipationInIngredient" },
                values: new object[,]
                {
                    { new Guid("c128e975-3d03-4f85-b0d3-5abd95a1ca1a"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 2, 0.20000000000000001 },
                    { new Guid("f04b3c37-7c7a-44f0-838d-dfc5718bd647"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 4, 0.10000000000000001 },
                    { new Guid("923c4585-b82e-495e-bd53-f064c2029f37"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 8, 0.59999999999999998 },
                    { new Guid("313398a1-2ae0-458b-9927-a81c06083905"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 2, 0.80000000000000004 },
                    { new Guid("7e91f4c4-9eac-4e1f-b5d9-0ea1ae3cf984"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 4, 0.0 },
                    { new Guid("621a0fb8-fdba-49a2-94fc-6e6971b71310"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 8, 0.20000000000000001 },
                    { new Guid("ae9a1afa-a724-41a3-8ad8-acb8bbe4f822"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 2, 0.69999999999999996 },
                    { new Guid("52461f0d-3058-4b78-81c6-bba6e42015fa"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 4, 0.10000000000000001 },
                    { new Guid("e93910cb-114c-4d26-8db3-7963d1b7a43c"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 8, 0.20000000000000001 },
                    { new Guid("74ceb16a-2efb-4915-a974-d77d7737bcc8"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 2, 0.20000000000000001 },
                    { new Guid("5857189b-2686-4a21-8d01-cb0feadce4da"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 4, 0.10000000000000001 },
                    { new Guid("eafef89b-42f1-4017-a474-ecc62687aefc"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 8, 0.20000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "RecipeDetails_ApproximateCost", "RecipeDetails_DifficultyLevel", "RecipeDetails_MealTypes", "RecipeDetails_PreparationTime" },
                values: new object[,]
                {
                    { new Guid("595fb96e-d833-4596-89ea-e7ba0320c169"), "Default recipe description", "Oatmeal with milk", 8m, 2, 18, 15 },
                    { new Guid("5b1015b7-05d4-437a-9365-93304785ec9c"), "Default recipe description", "Chicken with rise", 10m, 2, 12, 30 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Grams" },
                values: new object[,]
                {
                    { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("595fb96e-d833-4596-89ea-e7ba0320c169"), 50.0 },
                    { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("595fb96e-d833-4596-89ea-e7ba0320c169"), 150.0 },
                    { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("5b1015b7-05d4-437a-9365-93304785ec9c"), 200.0 },
                    { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("5b1015b7-05d4-437a-9365-93304785ec9c"), 100.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientMacroNutrient",
                table: "IngredientMacroNutrient");

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("313398a1-2ae0-458b-9927-a81c06083905"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("52461f0d-3058-4b78-81c6-bba6e42015fa"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("5857189b-2686-4a21-8d01-cb0feadce4da"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("621a0fb8-fdba-49a2-94fc-6e6971b71310"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("74ceb16a-2efb-4915-a974-d77d7737bcc8"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("7e91f4c4-9eac-4e1f-b5d9-0ea1ae3cf984"), new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("923c4585-b82e-495e-bd53-f064c2029f37"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("ae9a1afa-a724-41a3-8ad8-acb8bbe4f822"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("c128e975-3d03-4f85-b0d3-5abd95a1ca1a"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("e93910cb-114c-4d26-8db3-7963d1b7a43c"), new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("eafef89b-42f1-4017-a474-ecc62687aefc"), new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9") });

            migrationBuilder.DeleteData(
                table: "IngredientMacroNutrient",
                keyColumns: new[] { "Id", "IngredientId" },
                keyValues: new object[] { new Guid("f04b3c37-7c7a-44f0-838d-dfc5718bd647"), new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("5b1015b7-05d4-437a-9365-93304785ec9c") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("5b1015b7-05d4-437a-9365-93304785ec9c") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("595fb96e-d833-4596-89ea-e7ba0320c169") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("595fb96e-d833-4596-89ea-e7ba0320c169") });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("595fb96e-d833-4596-89ea-e7ba0320c169"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("5b1015b7-05d4-437a-9365-93304785ec9c"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientMacroNutrient",
                table: "IngredientMacroNutrient",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_IngredientMacroNutrient_Id_IngredientId",
                table: "IngredientMacroNutrient",
                columns: new[] { "Id", "IngredientId" });

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
