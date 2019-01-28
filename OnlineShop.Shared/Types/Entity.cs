using System;

namespace OnlineShop.Shared.Types
{
	public abstract class Entity : IIdentifiable
	{
		public Guid Id { get; }
		public DateTime CreatedDate { get; }
		public DateTime UpdatedDate { get; protected set; }

		protected Entity(Guid id)
		{
			Id = id;
			CreatedDate = DateTime.UtcNow;

			SetUpdateDate();
		}

		protected void SetUpdateDate()
		{
			UpdatedDate = DateTime.UtcNow;
		}

		public override bool Equals(object obj)
		{
			var entity = obj as Entity;

			if (entity == null)
				return false;

			if (GetType() != entity.GetType())
				return false;

			if (Id == Guid.Empty || entity.Id == Guid.Empty)
				return false;

			if (ReferenceEquals(this, entity))
				return true;

			return Id == entity.Id;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id);
		}

		public static bool operator ==(Entity left, Entity right)
		{
			if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
				return true;

			if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
				return false;

			return left.Equals(right);
		}

		public static bool operator !=(Entity left, Entity right)
		{
			return !(left == right);
		}
	}
}
