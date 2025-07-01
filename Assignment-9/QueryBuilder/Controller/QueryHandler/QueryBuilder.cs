namespace LINQ.Controller.QueryHandler
{
    internal class QueryBuilder<T>
    {
        private List<Func<T, bool>> _filters;
        private Func<IEnumerable<T>, IOrderedEnumerable<T>>? _sorter;
        private List<T> _products;
        public QueryBuilder(List<T> _products)
        {
            this._products = _products;
            _filters = new List<Func<T, bool>>();
        }

        /// <summary>
        /// Function to add a filter to the list of filters
        /// </summary>
        /// <param name="filter">Filter function</param>
        /// <returns>The updated query builder</returns>
        public QueryBuilder<T> Filter(Func<T, bool> filter)
        {
            _filters.Add(filter);
            return this;
        }
        /// <summary>
        /// Function to apply sorting with the given key column
        /// </summary>
        /// <typeparam name="Tkey">The type of the key to sort by</typeparam>
        /// <param name="sortcolumn">Function that return s the key to sort by</param>
        /// <returns>The updated query builder</returns>
        public QueryBuilder<T> SortBy<Tkey>(Func<T, Tkey> sortcolumn)
        {
            _sorter = products => products.OrderBy(sortcolumn);
            return this;
        }
        /// <summary>
        /// Function to join two collections based on the given key columns
        /// </summary>
        /// <typeparam name="TOther">Type of elements in other collection</typeparam>
        /// <typeparam name="TKey">Type of the key that is used to join</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="otherCollection">The collection to join with</param>
        /// <param name="outerKeySelector">Function to extract key from current collection</param>
        /// <param name="innerKeySelector">Function to extract key from the other collection</param>
        /// <param name="resultSelector">Function to create a result element from match</param>
        /// <returns>A new query builder with join operation</returns>
        public QueryBuilder<TResult> Join<TOther, TKey, TResult>(
        IEnumerable<TOther> otherCollection,
        Func<T, TKey> outerKeySelector,
        Func<TOther, TKey> innerKeySelector,
        Func<T, TOther, TResult> resultSelector)
        {
            var joined = from outer in _products
                         join inner in otherCollection
                         on outerKeySelector(outer) equals innerKeySelector(inner)
                         select resultSelector(outer, inner);

            return new QueryBuilder<TResult>(joined.ToList());
        }

        /// <summary>
        /// Function to execute all added filters
        /// </summary>
        /// <returns>A collection with all executed filters and sort</returns>
        public IEnumerable<T> Execute()
        {
            IEnumerable<T> query = _products;
            foreach (var filter in _filters)
            {
                query = query.Where(filter);
            }
            if (_sorter != null)
            {
                query = _sorter(query);
            }
            return query;
        }
    }
}
