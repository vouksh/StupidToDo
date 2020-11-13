﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StupidToDo.Data;

namespace StupidToDo.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("StupidToDo.Records.ToDo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignedListID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DoReminder")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Edited")
                        .HasColumnType("TEXT");

                    b.Property<int>("Frequency")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastRepeat")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RemindDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RemindTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RepeatEvery")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RepeatOnDay")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Repeats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("AssignedListID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AssignedListID = 1,
                            Body = "Blah blah blah",
                            Completed = false,
                            Created = new DateTime(2020, 11, 13, 15, 1, 10, 282, DateTimeKind.Local).AddTicks(2020),
                            DoReminder = false,
                            Frequency = 4,
                            RepeatOnDay = 0,
                            Repeats = false,
                            Title = "Do something"
                        });
                });

            modelBuilder.Entity("StupidToDo.Records.ToDoList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Lists");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Default"
                        });
                });

            modelBuilder.Entity("StupidToDo.Records.ToDo", b =>
                {
                    b.HasOne("StupidToDo.Records.ToDoList", "AssignedList")
                        .WithMany("ToDos")
                        .HasForeignKey("AssignedListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedList");
                });

            modelBuilder.Entity("StupidToDo.Records.ToDoList", b =>
                {
                    b.Navigation("ToDos");
                });
#pragma warning restore 612, 618
        }
    }
}