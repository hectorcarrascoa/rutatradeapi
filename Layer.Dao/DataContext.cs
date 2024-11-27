using Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Dao
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            //Test
        }

        #region ----- Declaración de tablas iniciales -----
        DbSet<User> user;
        public DbSet<User> User
        {
            get
            {
                if (user == null)
                    user = base.Set<User>();
                return user;
            }
        }

        DbSet<Client> client;
        public DbSet<Client> Client
        {
            get
            {
                if (client == null)
                    client = base.Set<Client>();
                return client;
            }
        }

        DbSet<Profile> profile;
        public DbSet<Profile> Profile
        {
            get
            {
                if (profile == null)
                    profile = base.Set<Profile>();
                return profile;
            }
        }

        DbSet<Country> country;
        public DbSet<Country> Country
        {
            get
            {
                if (country == null)
                    country = base.Set<Country>();
                return country;
            }
        }

        DbSet<City> city;
        public DbSet<City> City
        {
            get
            {
                if (city == null)
                    city = base.Set<City>();
                return city;
            }
        }

        DbSet<Bot> status;
        public DbSet<Bot> Status
        {
            get
            {
                if (status == null)
                    status = base.Set<Bot>();
                return status;
            }
        }

        DbSet<Node> node;
        public DbSet<Node> Node
        {
            get
            {
                if (node == null)
                    node = base.Set<Node>();
                return node;
            }
        }

        #endregion

        #region ----- Declaración de tablas de robot -----
        DbSet<Bot> bot;
        public DbSet<Bot> Bot
        {
            get
            {
                if (bot == null)
                    bot = base.Set<Bot>();
                return bot;
            }
        }

        DbSet<Broker> broker;
        public DbSet<Broker> Broker
        {
            get
            {
                if (broker == null)
                    broker = base.Set<Broker>();
                return broker;
            }
        }

        DbSet<Indicator> indicator;
        public DbSet<Indicator> Indicator
        {
            get
            {
                if (indicator == null)
                    indicator = base.Set<Indicator>();
                return indicator;
            }
        }

        DbSet<GroupFinancialAsset> groupFinancialAsset;
        public DbSet<GroupFinancialAsset> GroupFinancialAsset
        {
            get
            {
                if (groupFinancialAsset == null)
                    groupFinancialAsset = base.Set<GroupFinancialAsset>();
                return groupFinancialAsset;
            }
        }

        DbSet<FinancialAsset> financialAsset;
        public DbSet<FinancialAsset> FinancialAsset
        {
            get
            {
                if (financialAsset == null)
                    financialAsset = base.Set<FinancialAsset>();
                return financialAsset;
            }
        }

        DbSet<Config> config;
        public DbSet<Config> Config
        {
            get
            {
                if (config == null)
                    config = base.Set<Config>();
                return config;
            }
        }

        DbSet<UserBroker> userBroker;
        public DbSet<UserBroker> UserBroker
        {
            get
            {
                if (userBroker == null)
                    userBroker = base.Set<UserBroker>();
                return userBroker;
            }
        }

        DbSet<BotInstance> botInstance;
        public DbSet<BotInstance> BotInstance
        {
            get
            {
                if (botInstance == null)
                    botInstance = base.Set<BotInstance>();
                return botInstance;
            }
        }

        DbSet<FinancialBroker> financialBroker;
        public DbSet<FinancialBroker> FinancialBroker
        {
            get
            {
                if (financialBroker == null)
                    financialBroker = base.Set<FinancialBroker>();
                return financialBroker;
            }
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ----- Mapeo de relaciones entre tablas -----

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Ciudad");

                entity.Property(e => e.CityCode)
                    .HasColumnName("citycode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdCountry)
                    .HasColumnName("idcountry");

                entity.Property(e => e.CityName)
                    .HasColumnName("cityname")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .IsRequired();

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Cliente");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdCity)
                    .HasColumnName("idcity");

                entity.Property(e => e.ClientAddress)
                    .HasColumnName("clientaddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasColumnName("clientname")
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contactemail")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasColumnName("contactname")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contactphone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasColumnName("active");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("FK_Client_City");

            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Pais");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countrycode")
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasColumnName("countryname")
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasColumnName("active");

            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Perfil");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdClient)
                   .HasColumnName("idclient")
                   .IsRequired();

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileName)
                    .HasColumnName("profilename")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasColumnName("active");
                    
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Status");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdClient)
                    .HasColumnName("idclient");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("statuscode")
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasColumnName("statusname")
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasColumnName("active");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Usuario");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active");

                entity.Property(e => e.UserFirstAccess)
                    .HasColumnName("userfirstaccess");

                entity.Property(e => e.IdProfile)
                    .HasColumnName("idprofile");

                entity.Property(e => e.IdClient)
                    .HasColumnName("idclient");

                entity.Property(e => e.LoadDate)
                     .HasColumnName("loaddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("useremail")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userid")
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastNames)
                    .HasColumnName("userlastnames")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("username")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserNames)
                    .HasColumnName("usernames")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userpassword")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasColumnName("userphone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPicture)
                    .HasColumnName("userpicture")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserTitle)
                    .HasColumnName("usertitle")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Client");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Profile1");
            });

            modelBuilder.Entity<Node>()
               .HasOne(n => n.Parent)
               .WithMany(n => n.Children)
               .HasForeignKey(n => n.ParentId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Node>(entity =>
            {
                entity.ToTable("Node");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Node");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .IsRequired();

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentid");

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bot>(entity =>
            {
                entity.ToTable("Bot");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Bot");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user");

                entity.Property(e => e.IdFinancialAsset)
                    .HasColumnName("financialasset_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Temp)
                    .HasColumnName("temp")
                    .IsUnicode(false);
                
                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Broker>(entity =>
            {
                entity.ToTable("Broker");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Broker");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .IsUnicode(false);
                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Indicator>(entity =>
            {
                entity.ToTable("Indicator");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Bot");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado");

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupFinancialAsset>(entity =>
            {
                entity.ToTable("GroupFinancialAsset");

                entity.HasKey(e => e.Id)
                    .HasName("PK_GroupFinancialAsset");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado");
            });

            modelBuilder.Entity<FinancialAsset>(entity =>
            {
                entity.ToTable("FinancialAsset");

                entity.HasKey(e => e.Id)
                    .HasName("PK_FinancialAsset");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("grupo_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("Config");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Config");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("description")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .IsRequired();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserBroker>(entity =>
            {
                entity.ToTable("BrokerUser");

                entity.HasKey(e => e.Id)
                    .HasName("PK_BrokerUser");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdBroker)
                    .HasColumnName("id_broker");

                entity.Property(e => e.IdConfig)
                    .HasColumnName("id_config");

                entity.Property(e => e.Credential1)
                    .HasColumnName("credential1")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Credential2)
                    .HasColumnName("credential2")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo");

                entity.Property(e => e.Label)
                    .HasColumnName("label")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BotInstance>(entity =>
            {
                entity.ToTable("BotInstance");

                entity.HasKey(e => e.Id)
                    .HasName("PK_BotInstance");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdBroker)
                    .HasColumnName("broker_id");

                entity.Property(e => e.IdUser)
                   .HasColumnName("id_user");

                entity.Property(e => e.IdConfig)
                    .HasColumnName("broker_config_id");

                entity.Property(e => e.IdBot)
                    .HasColumnName("bot_id")
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .IsRequired();

                entity.Property(e => e.TakeProfir)
                    .HasColumnName("take_profir")
                    .IsRequired();

                entity.Property(e => e.StopLoss)
                    .HasColumnName("stop_loss")
                    .IsRequired();

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .IsUnicode(false);

                entity.Property(e => e.Apalanca)
                    .HasColumnName("apalanca")
                    .IsRequired();

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FinancialBroker>(entity =>
            {
                entity.ToTable("BrokerFinancial");

                entity.HasKey(e => e.Id)
                    .HasName("PK_FinancialBroker");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdBroker)
                    .HasColumnName("broker_id");

                entity.Property(e => e.IdFinancial)
                    .HasColumnName("financial_id");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Apalanca)
                    .HasColumnName("apalanca");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate)
                    .HasColumnName("loaddate")
                    .HasColumnType("date");

                entity.Property(e => e.LoadUser)
                    .HasColumnName("loaduser")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upddate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdUser)
                    .HasColumnName("upduser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            #endregion
        }
    }
}
