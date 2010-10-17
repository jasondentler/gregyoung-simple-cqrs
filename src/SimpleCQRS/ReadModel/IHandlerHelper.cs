using System;
using SimpleCQRS.Eventing;

namespace SimpleCQRS.ReadModel
{
	public interface IHandlerHelper<TDto>
		where TDto : class, IDto
	{

		void InsertDto(TDto dto);

		void UpdateDto(Guid id, Action<TDto> action);

		void DeleteDto(Guid id);
		
	}
}
