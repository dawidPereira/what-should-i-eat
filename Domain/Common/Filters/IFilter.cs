namespace Domain.Common.Filters
{
	public interface IFilter<in T> where T : new()
	{
		bool Satisfy(T toFilter);
	}
}