using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQ
{
    internal class QueryBuilder<T>
    {
        private List<Func<T, bool>> filters = new List<Func<T, bool>>();
        private Func<IEnumerable<T>, IOrderedEnumerable<T>> sorter;
        private IEnumerable<T> joins = null;
        List<T> products;
        private List<Func<IQueryable<T>, IQueryable<T>>> _joins = new List<Func<IQueryable<T>, IQueryable<T>>>();
        public QueryBuilder(List<T>Products)
        {
            products = Products;
        }

        public QueryBuilder<T> Filter(Func<T, bool> filter)
        {
            filters.Add(filter);
            return this;
        }
        public QueryBuilder<T> SortBy<Tkey>(Func<T, Tkey> sortcolumn)
        {
            sorter = products => products.OrderBy(sortcolumn);
            return this;
        }

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
