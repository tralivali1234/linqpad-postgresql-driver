﻿using DynamicLinqPadPostgreSqlDriver.Shared;
using DynamicLinqPadPostgreSqlDriver.Shared.Extensions;
using LINQPad.Extensibility.DataContext;
using System;

namespace DynamicLinqPadPostgreSqlDriver.Extensions
{
   internal static class IConnectionInfoExtensions
   {
      public static string GetTableName(this IConnectionInfo cxInfo, string tableName)
      {
         if (cxInfo.DriverData.GetDescendantValue(DriverOption.PluralizeSetAndTableProperties, Convert.ToBoolean, true))
         {
            tableName = tableName.Pluralize();
         }

         if (cxInfo.DriverData.GetDescendantValue(DriverOption.CapitalizePropertiesTablesAndColumns, Convert.ToBoolean, true))
         {
            tableName = tableName.Capitalize();
         }

         return tableName;
      }

      public static string GetTypeName(this IConnectionInfo cxInfo, string typeName)
      {
         if (cxInfo.DriverData.GetDescendantValue(DriverOption.SingularizeEntityNames, Convert.ToBoolean, true))
         {
            typeName = typeName.Singularize();
         }

         if (cxInfo.DriverData.GetDescendantValue(DriverOption.CapitalizePropertiesTablesAndColumns, Convert.ToBoolean, true))
         {
            typeName = typeName.Capitalize();
         }

         return typeName;
      }

      public static string GetColumnName(this IConnectionInfo cxInfo, string columnName)
      {
         if (cxInfo.DriverData.GetDescendantValue(DriverOption.CapitalizePropertiesTablesAndColumns, Convert.ToBoolean, true))
         {
            columnName = columnName.Capitalize();
         }

         return columnName;
      }

      public static bool UseAdvancedTypes(this IConnectionInfo cxInfo)
      {
         return cxInfo.DriverData.GetDescendantValue(DriverOption.UseExperimentalTypes, Convert.ToBoolean, false);
      }
   }
}
