﻿using GamesStores.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStores.Persistence.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{

    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property<decimal?>(game => game.Price)
            .HasPrecision(5, 2);
    }

}
