using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using FreedomApi.Models;

namespace FreedomApi.Data
{
    public partial class FreedomContext : DbContext
    {
        public FreedomContext()
        {
        }

        public FreedomContext(DbContextOptions<FreedomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterRemarkableTrait> CharacterRemarkableTrait { get; set; }
        public virtual DbSet<CharacterStatus> CharacterStatus { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<RemarkableTrait> RemarkableTrait { get; set; }
        public virtual DbSet<Restriction> Restriction { get; set; }
        public virtual DbSet<SkillLearned> SkillLearned { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Talent> Talent { get; set; }
        public virtual DbSet<TalentLearned> TalentLearned { get; set; }
        public virtual DbSet<TechniqueLearned> TechniqueLearned { get; set; }
        public virtual DbSet<TechniqueRestriction> TechniqueRestriction { get; set; }
        public virtual DbSet<Techniques> Techniques { get; set; }
        public virtual DbSet<FreedomApi.Models.Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserParty> UserParty { get; set; }

        // Unable to generate entity type for table 'password_resets'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=freedom;uid=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId, e.PartyId })
                    .HasName("PRIMARY");

                entity.ToTable("character");

                entity.HasIndex(e => e.PartyId)
                    .HasName("fk_CHARACTER_PARTY1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_CHARACTER_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PartyId)
                    .HasColumnName("party_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CharacterPoints)
                    .HasColumnName("character_points")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComplicationLevel)
                    .HasColumnName("complication_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.DestinoPoints)
                    .HasColumnName("destino_points")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExhaustionLevel)
                    .HasColumnName("exhaustion_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CHARACTER_PARTY1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CHARACTER_USER1");
            });

            modelBuilder.Entity<CharacterRemarkableTrait>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CharacterId, e.RemarkableTraitId })
                    .HasName("PRIMARY");

                entity.ToTable("character_remarkable_trait");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_CHARACTER_has_REMARKABLE_TRAIT_CHARACTER1_idx");

                entity.HasIndex(e => e.RemarkableTraitId)
                    .HasName("fk_CHARACTER_has_REMARKABLE_TRAIT_REMARKABLE_TRAIT1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("character_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RemarkableTraitId)
                    .HasColumnName("remarkable_trait_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ObtainedAt)
                    .HasColumnName("obtained_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CharacterStatus>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.StatusId })
                    .HasName("PRIMARY");

                entity.ToTable("character_status");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_CHARACTER_has_STATUS_CHARACTER1_idx");

                entity.HasIndex(e => e.StatusId)
                    .HasName("fk_CHARACTER_has_STATUS_STATUS1_idx");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("character_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CharacterStatus)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CHARACTER_has_STATUS_STATUS1");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.IdCharacter, e.IdItem })
                    .HasName("PRIMARY");

                entity.ToTable("inventory");

                entity.HasIndex(e => e.IdCharacter)
                    .HasName("fk_ITEM_has_CHARACTER_CHARACTER1_idx");

                entity.HasIndex(e => e.IdItem)
                    .HasName("fk_ITEM_has_CHARACTER_ITEM1_idx");

                entity.Property(e => e.IdCharacter)
                    .HasColumnName("id_character")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdItem)
                    .HasColumnName("id_item")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CharacterId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("item");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_ITEM_CHARACTER1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_ITEM_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("character_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Charge)
                    .HasColumnName("charge")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Exhaustion)
                    .HasColumnName("exhaustion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaximumCharge)
                    .HasColumnName("maximum_charge")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ITEM_USER1");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => new { e.IdItem, e.IdType })
                    .HasName("PRIMARY");

                entity.ToTable("item_type");

                entity.HasIndex(e => e.IdItem)
                    .HasName("fk_ITEM_has_ITEM_TYPE_ITEM1_idx");

                entity.HasIndex(e => e.IdType)
                    .HasName("fk_ITEM_has_ITEM_TYPE_ITEM_TYPE1_idx");

                entity.Property(e => e.IdItem)
                    .HasColumnName("id_item")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdType)
                    .HasColumnName("id_type")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.ItemType)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ITEM_has_ITEM_TYPE_ITEM_TYPE1");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .HasColumnName("migration")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.ToTable("party");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<RemarkableTrait>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("remarkable_trait");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_REMARKABLE_TRAIT_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RemarkableTrait)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_REMARKABLE_TRAIT_USER1");
            });

            modelBuilder.Entity<Restriction>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("restriction");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_RESTRICTION_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Restriction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RESTRICTION_USER1");
            });

            modelBuilder.Entity<SkillLearned>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CharacterId, e.SkillId })
                    .HasName("PRIMARY");

                entity.ToTable("skill_learned");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_CHARACTER_has_SKILL_CHARACTER1_idx");

                entity.HasIndex(e => e.SkillId)
                    .HasName("fk_CHARACTER_has_SKILL_SKILL1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("character_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Experience)
                    .HasColumnName("experience")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LearnedAt)
                    .HasColumnName("learned_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("skills");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_SKILL_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SKILL_USER1");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Complication)
                    .HasColumnName("complication")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Exhaustion)
                    .HasColumnName("exhaustion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Talent>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("talent");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_TALENT_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Talent)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TALENT_USER1");
            });

            modelBuilder.Entity<TalentLearned>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CharacterId, e.TalentId })
                    .HasName("PRIMARY");

                entity.ToTable("talent_learned");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_CHARACTER_has_TALENT_CHARACTER1_idx");

                entity.HasIndex(e => e.TalentId)
                    .HasName("fk_CHARACTER_has_TALENT_TALENT1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("character_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TalentId)
                    .HasColumnName("talent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LearnedAt)
                    .HasColumnName("learned_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TechniqueLearned>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CharacterId, e.TechniqueId })
                    .HasName("PRIMARY");

                entity.ToTable("technique_learned");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_CHARACTER_has_TECHNIQUE_CHARACTER1_idx");

                entity.HasIndex(e => e.TechniqueId)
                    .HasName("fk_CHARACTER_has_TECHNIQUE_TECHNIQUE1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("character_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TechniqueId)
                    .HasColumnName("technique_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LearnedAt)
                    .HasColumnName("learned_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TechniqueRestriction>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TechniqueId, e.RestrictionId })
                    .HasName("PRIMARY");

                entity.ToTable("technique_restriction");

                entity.HasIndex(e => e.RestrictionId)
                    .HasName("fk_TECHNIQUE_has_RESTRICTION_RESTRICTION1_idx");

                entity.HasIndex(e => e.TechniqueId)
                    .HasName("fk_TECHNIQUE_has_RESTRICTION_TECHNIQUE1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TechniqueId)
                    .HasColumnName("technique_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RestrictionId)
                    .HasColumnName("restriction_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AppliedAt)
                    .HasColumnName("applied_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Techniques>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("techniques");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_TECHNIQUE_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Difficulty)
                    .HasColumnName("difficulty")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Effect)
                    .HasColumnName("effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Execution)
                    .HasColumnName("execution")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Form)
                    .HasColumnName("form")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Restriction)
                    .HasColumnName("restriction")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Techniques)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TECHNIQUE_USER1");
            });

            modelBuilder.Entity<FreedomApi.Models.Type>(entity =>
            {
                entity.ToTable("type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<UserParty>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId, e.PartyId })
                    .HasName("PRIMARY");

                entity.ToTable("user_party");

                entity.HasIndex(e => e.PartyId)
                    .HasName("fk_USER_has_PARTY_PARTY1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_USER_has_PARTY_USER1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PartyId)
                    .HasColumnName("party_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.JoinedAt)
                    .HasColumnName("joined_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Master)
                    .HasColumnName("master")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.UserParty)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_USER_has_PARTY_PARTY1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserParty)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_USER_has_PARTY_USER1");
            });
        }
    }
}
