using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sybd_lab5
{
    public partial class Sushi_barContext : DbContext
    {
        public Sushi_barContext()
        {
        }

        public Sushi_barContext(DbContextOptions<Sushi_barContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersMeni> OrdersMeni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=192.168.43.168;Port=5432;Database=Sushi_bar;Username=postgres;Password=boot");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("buyer");

                entity.HasComment("Таблица, хранящая в себе всю нужную информацию о клиенте");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.NameBuyer)
                    .IsRequired()
                    .HasColumnName("name_buyer")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Имя клиента отсутствует '::character varying")
                    .HasComment("Имя клиента");

                entity.Property(e => e.NumberBuyer)
                    .IsRequired()
                    .HasColumnName("number_buyer")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Номер телефона отствует'::character varying")
                    .HasComment("Номер телефона клиента");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("fio")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Не указано ФИО сотрудника'::character varying")
                    .HasComment("ФИО сотрудника");

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasColumnName("post")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Не указана должность'::character varying")
                    .HasComment("Должность сотрудника");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Gram)
                    .HasColumnName("gram")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("0")
                    .HasComment("Граммы");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Нету названия блюда'::character varying")
                    .HasComment("Наименование блюда");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(50,0)")
                    .HasComment("Цена блюда");

                entity.Property(e => e.Volume)
                    .HasColumnName("volume")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("0")
                    .HasComment("Объем");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Buyerid)
                    .HasColumnName("buyerid")
                    .HasDefaultValueSql("1")
                    .HasComment("Внешний ключ на запись в  таблице buyer");

                entity.Property(e => e.DataOrders)
                    .HasColumnName("data_orders")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата заказа");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("employeeid")
                    .HasDefaultValueSql("1")
                    .HasComment("Внешний ключ на запись в таблице employee");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Buyerid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("buyer_fk");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("employee_fk");
            });

            modelBuilder.Entity<OrdersMeni>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.OrdersId })
                    .HasName("pkorders_meni");

                entity.ToTable("orders_meni");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasDefaultValueSql("1")
                    .HasComment("Первичный ключ меню");

                entity.Property(e => e.OrdersId)
                    .HasColumnName("orders_id")
                    .HasDefaultValueSql("1")
                    .HasComment("Первичный ключ заказа");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.OrdersMeni)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("orders_meni_menu_id_fkey");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrdersMeni)
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("orders_meni_orders_id_fkey");
            });

            modelBuilder.HasSequence("buyer_id_seq");

            modelBuilder.HasSequence("employee_id_seq");

            modelBuilder.HasSequence("menu_id_seq");

            modelBuilder.HasSequence("orders_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
