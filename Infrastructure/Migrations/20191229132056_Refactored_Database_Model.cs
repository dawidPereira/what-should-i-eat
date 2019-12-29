using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Refactored_Database_Model : Migration
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
                    RecipeInfo_DifficultyLevel = table.Column<int>(nullable: true),
                    RecipeInfo_PreparationTime = table.Column<int>(nullable: true),
                    RecipeInfo_ApproximateCost = table.Column<decimal>(nullable: true),
                    RecipeInfo_MealTypes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MacroNutrientShares",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(nullable: false),
                    MacroNutrient = table.Column<int>(nullable: false),
                    Share = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacroNutrientShares", x => new { x.MacroNutrient, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_MacroNutrientShares_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false),
                    Grams = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipes_RecipeId",
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
                    { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 0, "Chicken", 4 },
                    { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 0, "Rice", 7 },
                    { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 1, "Oatmeal", 7 },
                    { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 1, "Milk", 7 }
                });
            
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "RecipeInfo_ApproximateCost", "RecipeInfo_DifficultyLevel", "RecipeInfo_MealTypes", "RecipeInfo_PreparationTime" },
                values: new object[,]
                {
                    { new Guid("4977032a-2085-4ac2-821a-45ef6269edb3"), "Default recipe description", "Oatmeal with milk", 8m, 2, 18, 15 },
                    { new Guid("f904b5e7-f430-42d7-9258-c853ea2a3b68"), "Default recipe description", "Chicken with rise", 10m, 2, 12, 30 }
                });

            migrationBuilder.InsertData(
                table: "MacroNutrientShares",
                columns: new[] { "MacroNutrient", "IngredientId", "Share" },
                values: new object[,]
                {
                    { 1, new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 0.20000000000000001 },
                    { 2, new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 0.10000000000000001 },
                    { 4, new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), 0.59999999999999998 },
                    { 1, new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 0.80000000000000004 },
                    { 2, new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 0.0 },
                    { 4, new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), 0.20000000000000001 },
                    { 1, new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 0.69999999999999996 },
                    { 2, new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 0.10000000000000001 },
                    { 4, new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), 0.20000000000000001 },
                    { 1, new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 0.20000000000000001 },
                    { 2, new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 0.10000000000000001 },
                    { 4, new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), 0.20000000000000001 }
                });
            
            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "IngredientId", "RecipeId", "Grams" },
                values: new object[,]
                {
                    { new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"), new Guid("4977032a-2085-4ac2-821a-45ef6269edb3"), 50.0 },
                    { new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"), new Guid("4977032a-2085-4ac2-821a-45ef6269edb3"), 150.0 },
                    { new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"), new Guid("f904b5e7-f430-42d7-9258-c853ea2a3b68"), 200.0 },
                    { new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"), new Guid("f904b5e7-f430-42d7-9258-c853ea2a3b68"), 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MacroNutrientShares_IngredientId",
                table: "MacroNutrientShares",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MacroNutrientShares");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
