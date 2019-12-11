namespace Domain.Common.Filters
{
	public interface IFilter<in T> where T : class
	{
		bool Satisfy(T toFilter);
	}
}