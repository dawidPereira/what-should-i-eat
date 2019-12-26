using Domain.Common.Filters;

namespace Domain.RecipesDetails.Filters.FiltersCriteria
{
	public struct RangeFilterCriteria : IFilterCriteria
	{
		private readonly double _deviation;
		private readonly double _lowerLimit;
		private readonly double _upperLimit;

		public RangeFilterCriteria(double? deviation, double lowerLimit, double upperLimit)
		{
			_deviation = deviation ??= 0;
			_lowerLimit = lowerLimit;
			_upperLimit = upperLimit;
		}

		public double LowerLimit => _lowerLimit - _lowerLimit * _deviation;
		public double UpperLimit => _upperLimit + _upperLimit * _deviation;
	}
}