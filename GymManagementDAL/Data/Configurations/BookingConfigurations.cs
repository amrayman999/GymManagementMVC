using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Data.Configurations
{
	internal class BookingConfigurations : IEntityTypeConfiguration<Booking>
	{
		public void Configure(EntityTypeBuilder<Booking> builder)
		{
			builder.Ignore(X => X.Id);
			builder.Property(X => X.CreatedAt)
				   .HasColumnName("BookingDate")
				   .HasDefaultValueSql("GETDATE()");

			builder.HasOne(X => X.Session)
				   .WithMany(X => X.SessionMembers)
				   .HasForeignKey(X => X.SessionId);

			builder.HasOne(X => X.Member)
				   .WithMany(X => X.MemberSessions)
				   .HasForeignKey(X => X.MemberId);

			builder.HasKey(X => new { X.SessionId, X.MemberId });
		}
	}
}
