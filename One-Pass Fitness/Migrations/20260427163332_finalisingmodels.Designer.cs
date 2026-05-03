using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using One_Pass_Fitness.Data;

#nullable disable

namespace One_Pass_Fitness.Migrations
{
    [DbContext(typeof(OnePassFitnessContext))]
    [Migration("20260427163332_finalisingmodels")]
    partial class finalisingmodels
    {
        
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("One_Pass_Fitness.Models.Classes", b =>
                {
                    b.Property<int>("ClassesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassesId"));

                    b.Property<string>("Availability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Endtime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("Starttime")
                        .HasColumnType("time");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClassesId");

                    b.HasIndex("UserId");

                    b.ToTable("Classes", (string)null);
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Membership", b =>
                {
                    b.Property<int>("Membershipid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Membershipid"));

                    b.Property<DateOnly>("Enddate")
                        .HasColumnType("date");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("Startdate")
                        .HasColumnType("date");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Membershipid");

                    b.HasIndex("Userid");

                    b.ToTable("Membership", (string)null);
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Personalinfo", b =>
                {
                    b.Property<int>("Personalinfoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Personalinfoid"));

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("Usersid")
                        .HasColumnType("int");

                    b.HasKey("Personalinfoid");

                    b.HasIndex("Usersid");

                    b.ToTable("Personalinfo", (string)null);
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Roles", b =>
                {
                    b.Property<int>("Roleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Roleid"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Roleid");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Users", b =>
                {
                    b.Property<int>("Usersid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Usersid"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Personid")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("RolesRoleid")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Usersid");

                    b.HasIndex("Personid");

                    b.HasIndex("RoleId");

                    b.HasIndex("RolesRoleid");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Classes", b =>
                {
                    b.HasOne("One_Pass_Fitness.Models.Users", "User")
                        .WithMany("Classes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Membership", b =>
                {
                    b.HasOne("One_Pass_Fitness.Models.Users", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Personalinfo", b =>
                {
                    b.HasOne("One_Pass_Fitness.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("Usersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Users", b =>
                {
                    b.HasOne("One_Pass_Fitness.Models.Personalinfo", "Person")
                        .WithMany()
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("One_Pass_Fitness.Models.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("One_Pass_Fitness.Models.Roles", null)
                        .WithMany("Users")
                        .HasForeignKey("RolesRoleid");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Roles", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("One_Pass_Fitness.Models.Users", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
