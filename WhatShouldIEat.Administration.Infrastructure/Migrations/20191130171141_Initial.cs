using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatShouldIEat.Administration.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Allergens = table.Column<int>(nullable: false),
                    Requirements = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RecipeDetails_DifficultyLevel = table.Column<int>(nullable: true),
                    RecipeDetails_PreparationTime = table.Column<int>(nullable: true),
                    RecipeDetails_ApproximateCost = table.Column<decimal>(nullable: true),
                    RecipeDetails_MealTypes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientMacroNutrient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false),
                    MacroNutrient = table.Column<int>(nullable: false),
                    ParticipationInIngredient = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMacroNutrient", x => x.Id);
                    table.UniqueConstraint("AK_IngredientMacroNutrient_Id_IngredientId", x => new { x.Id, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredientMacroNutrient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false),
                    Grams = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Allergens", "Name", "Requirements" },
                values: new object[,]
                {
                    { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 0, "Chicken", 8 },
                    { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 0, "Rice", 13 },
                    { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 1, "Oatmeal", 13 },
                    { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 1, "Milk", 13 }
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
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Grams" },
                values: new object[,]
                {
                    { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"), 50.0 },
                    { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"), 150.0 },
                    { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"), 200.0 },
                    { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"), 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMacroNutrient_IngredientId",
                table: "IngredientMacroNutrient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMacroNutrient");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
