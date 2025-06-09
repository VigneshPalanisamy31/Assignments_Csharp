namespace LINQ.Controller.QueryHandler
{
    internal class QueryBuilder<T>
    {
        List<Func<T, bool>> filters = new List<Func<T, bool>>();
        Func<IEnumerable<T>, IOrderedEnumerable<T>>? sorter;
        List<T> products;
        public QueryBuilder(List<T>Products)
        {
            products = Products;
        }

        /// <summary>
        /// Function to add a filter to the list of filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public QueryBuilder<T> Filter(Func<T, bool> filter)
        {
            filters.Add(filter);
            return this;
        }
        /// <summary>
        /// Function to apply sorting with the given key column
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="sortcolumn"></param>
        /// <returns></returns>
        public QueryBuilder<T> SortBy<Tkey>(Func<T, Tkey> sortcolumn)
        {
            sorter = products => products.OrderBy(sortcolumn);
            return this;
        }
        /// <summary>
        /// Function to join two collections based on the given key columns
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="otherCollection"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public QueryBuilder<TResult> Join<TOther, TKey, TResult>(
        IEnumerable<TOther> otherCollection,
        Func<T, TKey> outerKeySelector,
        Func<TOther, TKey> innerKeySelector,
        Func<T, TOther, TResult> resultSelector)
        {
            var joined = from outer in products
                         join inner in otherCollection
                         on outerKeySelector(outer) equals innerKeySelector(inner)
                         select resultSelector(outer, inner);

            return new QueryBuilder<TResult>(joined.ToList());
        }

        /// <summary>
        /// Function to execute all added filters
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Execute()
        {
            IEnumerable<T> query = products;
            foreach(var filter in filters)
            {
                query=query.Where(filter);
            }
            if(sorter!=null)
            {
                query=sorter(query);
            }
            return query;
        }
    }
}
