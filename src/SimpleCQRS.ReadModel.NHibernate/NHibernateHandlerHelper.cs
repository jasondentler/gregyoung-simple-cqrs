using System;
using NHibernate;

namespace SimpleCQRS.ReadModel.NHibernate
{
	public class NHibernateHandlerHelper<TDto>
		: IHandlerHelper<TDto>
		where TDto : class, IDto
	{

		private readonly IStatelessSession _session;

		public NHibernateHandlerHelper(
			IStatelessSession session)
		{
			_session = session;
		}

		public void InsertDto(TDto dto)
		{
			Transact(() => _session.Insert(dto));
		}

		public void DeleteDto(Guid id)
		{
			var hql = string.Format("delete from {0} dto where dto.id = :id",
			                        typeof (TDto).Name);
			var query = _session.CreateQuery(hql)
				.SetGuid("id", id);
			Transact(() => query.ExecuteUpdate());
		}

		public void UpdateDto(Guid id, Action<TDto> action)
		{
			Transact(() =>
			         	{
			         		var dto = _session.Get<TDto>(id);
			         		action.Invoke(dto);
			         		_session.Update(dto);
			         	});
		}
		
		protected virtual TResult Transact<TResult>(Func<TResult> func)
		{
			if (!_session.Transaction.IsActive)
			{
				// Wrap in transaction
				TResult result;
				using (var tx = _session.BeginTransaction())
				{
					result = func.Invoke();
					tx.Commit();
				}
				return result;
			}

			// Don't wrap;
			return func.Invoke();
		}

		protected virtual void Transact(Action action)
		{
			Transact<bool>(() =>
			{
				action.Invoke();
				return false;
			});
		}


	}
}
