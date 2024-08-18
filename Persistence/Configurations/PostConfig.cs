using Domain.Entities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(ur => (CorrectUser)ur.User)
              .WithMany(u => u.Posts)
              .HasForeignKey(ur => ur.UserId);

        }
    }
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(ur => (CorrectUser)ur.User)
              .WithMany(u => u.Messages)
              .HasForeignKey(ur => ur.UserId);
            // Map the base class to the "Messages" table
            builder.ToTable("Messages");
        }
    }
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.HasBaseType<Message>();

            builder.Property(e => e.PostId).IsRequired();
            builder.HasOne(c => c.Post)
            .WithMany(ch => ch.Comments)
            .HasForeignKey(c => c.PostId);

            builder.ToTable("Comments");
        }
    }
    public class ChatMessageConfig : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            // Inherit from Message
            builder.HasBaseType<Message>();

        
            builder.Property(e => e.ChatId).IsRequired();

            builder.HasOne(c => c.Chat)
                .WithMany(p => p.ChatMessages)
                .HasForeignKey(c => c.ChatId);

            // Map to a separate table
            builder.ToTable("ChatMessages");
        }
    }
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(ch => ch.Class)
            .WithOne(cl => cl.Chat)
            .HasForeignKey<Class>(cl => cl.ChatId);

            builder.HasMany(ch => ch.ChatMessages)
             .WithOne(c => c.Chat)
             .HasForeignKey(c => c.ChatId);

        }
    }
}
