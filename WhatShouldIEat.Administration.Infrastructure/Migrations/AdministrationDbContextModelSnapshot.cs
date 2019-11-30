﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using WhatShouldIEat.Administration.Infrastructure.DbContexts;

namespace WhatShouldIEat.Administration.Infrastructure.Migrations
{
    [DbContext(typeof(AdministrationDbContext))]
    partial class AdministrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhatShouldIEat.Administration.Domain.Ingredients.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Allergens")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Requirements")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"),
                            Allergens = 0,
                            Name = "Chicken",
                            Requirements = 8
                        },
                        new
                        {
                            Id = new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"),
                            Allergens = 0,
                            Name = "Rice",
                            Requirements = 13
                        },
                        new
                        {
                            Id = new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"),
                            Allergens = 1,
                            Name = "Oatmeal",
                            Requirements = 13
                        },
                        new
                        {
                            Id = new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"),
                            Allergens = 1,
                            Name = "Milk",
                            Requirements = 13
                        });
                });

            modelBuilder.Entity("WhatShouldIEat.Administration.Domain.Ingredients.Entities.IngredientMacroNutrient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MacroNutrient")
                        .HasColumnType("int");

                    b.Property<double>("ParticipationInIngredient")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasAlternateKey("Id", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("IngredientMacroNutrient");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9e97f241-f3d6-4a7c-abfc-8fc9e35d14e5"),
                            IngredientId = new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"),
                            MacroNutrient = 2,
                            ParticipationInIngredient = 0.20000000000000001
                        },
                        new
                        {
                            Id = new Guid("6651ab54-35ff-43cf-a82a-601bea2cf4c9"),
                            IngredientId = new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"),
                            MacroNutrient = 4,
                            ParticipationInIngredient = 0.10000000000000001
                        },
                        new
                        {
                            Id = new Guid("1c85e237-1876-421d-8c2e-bd1cf503dae0"),
                            IngredientId = new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"),
                            MacroNutrient = 8,
                            ParticipationInIngredient = 0.59999999999999998
                        },
                        new
                        {
                            Id = new Guid("1da7da72-7fbd-4c63-ade8-abca0ac58765"),
                            IngredientId = new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"),
                            MacroNutrient = 2,
                            ParticipationInIngredient = 0.80000000000000004
                        },
                        new
                        {
                            Id = new Guid("99165298-34e7-4125-b36d-cebeb244b11a"),
                            IngredientId = new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"),
                            MacroNutrient = 4,
                            ParticipationInIngredient = 0.0
                        },
                        new
                        {
                            Id = new Guid("9ebe6a04-16fe-4d2a-8f9d-0dac4ffa2162"),
                            IngredientId = new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"),
                            MacroNutrient = 8,
                            ParticipationInIngredient = 0.20000000000000001
                        },
                        new
                        {
                            Id = new Guid("99377e62-81f9-403c-8927-e2f78c1c8d5d"),
                            IngredientId = new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"),
                            MacroNutrient = 2,
                            ParticipationInIngredient = 0.69999999999999996
                        },
                        new
                        {
                            Id = new Guid("1297933b-3550-45bf-96b8-e54768e94484"),
                            IngredientId = new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"),
                            MacroNutrient = 4,
                            ParticipationInIngredient = 0.10000000000000001
                        },
                        new
                        {
                            Id = new Guid("29022244-6093-4bd2-b093-8fd5cef17d6f"),
                            IngredientId = new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"),
                            MacroNutrient = 8,
                            ParticipationInIngredient = 0.20000000000000001
                        },
                        new
                        {
                            Id = new Guid("5c98bc26-1ff7-4bfd-9cd8-1685525269ef"),
                            IngredientId = new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"),
                            MacroNutrient = 2,
                            ParticipationInIngredient = 0.20000000000000001
                        },
                        new
                        {
                            Id = new Guid("e64653ef-cb11-4fe8-8b35-27ae6740c5e2"),
                            IngredientId = new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"),
                            MacroNutrient = 4,
                            ParticipationInIngredient = 0.10000000000000001
                        },
                        new
                        {
                            Id = new Guid("459c640a-9597-44da-8cf5-3254aa687996"),
                            IngredientId = new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"),
                            MacroNutrient = 8,
                            ParticipationInIngredient = 0.20000000000000001
                        });
                });

            modelBuilder.Entity("WhatShouldIEat.Administration.Domain.Recipes.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"),
                            Description = "Default recipe description",
                            Name = "Chicken with rise"
                        },
                        new
                        {
                            Id = new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"),
                            Description = "Default recipe description",
                            Name = "Chicken with rise"
                        });
                });

            modelBuilder.Entity("WhatShouldIEat.Administration.Domain.Recipes.Entities.RecipeIngredient", b =>
                {
                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Grams")
                        .HasColumnType("float");

                    b.HasKey("IngredientId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredients");

                    b.HasData(
                        new
                        {
                            IngredientId = new Guid("9817c714-9534-42f1-bf58-fc9c9c177a0f"),
                            RecipeId = new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"),
                            Grams = 50.0
                        },
                        new
                        {
                            IngredientId = new Guid("b4ec88f0-0a0d-4ad5-945f-32a4642fafc9"),
                            RecipeId = new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"),
                            Grams = 150.0
                        },
                        new
                        {
                            IngredientId = new Guid("66f46fbb-2270-4948-9468-e0d0b3c698cf"),
                            RecipeId = new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"),
                            Grams = 200.0
                        },
                        new
                        {
                            IngredientId = new Guid("0392aabc-37c7-4591-882d-5f00acfb4cae"),
                            RecipeId = new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"),
                            Grams = 100.0
                        });
                });

            modelBuilder.Entity("WhatShouldIEat.Administration.Domain.Ingredients.Entities.IngredientMacroNutrient", b =>
                {
                    b.HasOne("WhatShouldIEat.Administration.Domain.Ingredients.Entities.Ingredient", null)
                        .WithMany("MacroNutrientsParticipants")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhatShouldIEat.Administration.Domain.Recipes.Entities.Recipe", b =>
                {
                    b.OwnsOne("WhatShouldIEat.Administration.Domain.Recipes.Entities.RecipeDetails", "RecipeDetails", b1 =>
                        {
                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("ApproximateCost")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("DifficultyLevel")
                                .HasColumnType("int");

                            b1.Property<int>("MealTypes")
                                .HasColumnType("int");

                            b1.Property<int>("PreparationTime")
                                .HasColumnType("int");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.HasData(
                                new
                                {
                                    RecipeId = new Guid("2d31f6f2-9156-4c4f-a338-ece6c8b85816"),
                                    ApproximateCost = 8m,
                                    DifficultyLevel = 2,
                                    MealTypes = 18,
                                    PreparationTime = 15
                                },
                                new
                                {
                                    RecipeId = new Guid("6eccf36d-e922-496f-aca3-79a8b08a09f8"),
                                    ApproximateCost = 10m,
                                    DifficultyLevel = 2,
                                    MealTypes = 12,
                                    PreparationTime = 30
                                });
                        });
                });

            modelBuilder.Entity("WhatShouldIEat.Administration.Domain.Recipes.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("WhatShouldIEat.Administration.Domain.Ingredients.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhatShouldIEat.Administration.Domain.Recipes.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}