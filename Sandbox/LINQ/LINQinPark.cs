using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    /// <summary>
    /// As the punny name suggests, holds many LINQ queries on datasets.
    /// </summary>
    public class LINQinPark
    {
        #region counting
        public static int CountDistinctValuesInColumn(DataTable table, string ColumnName)
        {
            return table.AsEnumerable().Select(x => x.Field<int>(ColumnName)).Distinct().Count();
        }

        public static int CountDistinctValuesInList(List<object> list)
        {
            return list.AsEnumerable().Distinct().Count();
        }
        #endregion

        #region grouping and sums
        public static DataTable GroupByColumnAndGetSumOfValues(DataTable table, string GroupByColumn, string SumTheseValues)
        {
            DataTable ByValueDT = new DataTable();

            if (table.Rows.Count > 0)
                ByValueDT = table.AsEnumerable()
                  .GroupBy(r => r.Field<int>(GroupByColumn))
                  .Select(g =>
                  {
                      var row = table.NewRow();

                      row[GroupByColumn] = g.Key;
                      row[SumTheseValues] = g.Sum(r => r.Field<decimal>(SumTheseValues));
                      return row;
                  }
                  ).CopyToDataTable();
            return ByValueDT;
        }

        public static DataTable GetSalesByCategory(DataTable AllSales, string Category)
        {

            DataTable SalesByCategoria = new DataTable();
            //Need to initialize every column you'll read data into.
            SalesByCategoria.Columns.Add("Categoría", typeof(string));
            SalesByCategoria.Columns.Add("Cantidad", typeof(decimal));
            SalesByCategoria.Columns.Add("Total Venta", typeof(decimal));

            SalesByCategoria = AllSales.AsEnumerable().GroupBy(x => x.Field<string>(Category)).Select(cat => SalesByCategoria.LoadDataRow(new object[]
                {
                cat.First().Field<string>(Category),
                cat.Sum(q => q.Field<decimal>("Cantidad")),
                cat.Sum(p => p.Field<decimal>("TotalVenta"))
                }, false)).CopyToDataTable();

            return SalesByCategoria;
        }

    
    #endregion

        #region combining Datatables

        public static DataTable JoinAndCombineDataFromTwoTables(DataTable Table1, DataTable Table2)
        {
            DataTable dtResult = new DataTable();
            //Initialize the columns.
            dtResult.Columns.Add("Tienda", typeof(string));
            dtResult.Columns.Add("Seccion", typeof(string));
            dtResult.Columns.Add("Marca", typeof(string));
            dtResult.Columns.Add("IDArticulo", typeof(string)); //common column, but could have diff names in each.
            dtResult.Columns.Add("Descripcion", typeof(string));
            dtResult.Columns.Add("Stock Logico", typeof(int)); //Belongs only to table 1.
            dtResult.Columns.Add("Stock Fisico", typeof(int)); //Belongs only to table2
            dtResult.Columns.Add("Diferencia", typeof(int)); //New column.
            dtResult.Columns.Add("Costo Unitario Ultima Compra", typeof(decimal));
            dtResult.Columns.Add("Fecha Ultima Compra", typeof(DateTime));
            dtResult.Columns.Add("Cantidad Ultima Compra", typeof(decimal));
            dtResult.Columns.Add("Costo Total Stock", typeof(decimal));
            dtResult.Columns.Add("Moneda", typeof(string));

            var a = (from tab1 in Table1.AsEnumerable()
                     join tab2 in Table2.AsEnumerable()
                     on tab1["ItemCode"] equals tab2["itemcode"] //common column
                     into ps //Resulting table with the joins.
                     from JoinedRows in ps.DefaultIfEmpty()
                         //where tab1.Field<decimal>("Stock Logico") != tab2.Field<decimal>("Stock Fisico") //If we wanted only rows where there was a difference.
                     select dtResult.LoadDataRow(new object[]
                    {
                            tab1.Field<string>("Tienda"),
                            tab1.Field<string>("Seccion"),
                            tab1.Field<string>("Marca"),
                            "'"+tab1.Field<string>("ItemCode"),//idarticulo
                            tab1.Field<string>("ItemName"), //descripcion
                            tab1.Field<int>("Stock"), //stock logico
                            JoinedRows == null? 0: JoinedRows.Field<int>("Unidades"),//stock fisico
                            tab1.Field<int>("Stock") - (JoinedRows == null? 0: JoinedRows.Field<int>("Unidades")),//Diferencia
                            tab1.Field<decimal>("Costo Unitario Ultima Compra"),
                            tab1.Field<DateTime>("Fecha Ultima Compra"),
                            tab1.Field<decimal>("Cantidad Ultima Compra"),
                            tab1.Field<decimal>("Costo Total Stock"),
                            tab1.Field<string>("Moneda"),
              }, false));

            return dtResult;
        }
        #endregion

}
}
