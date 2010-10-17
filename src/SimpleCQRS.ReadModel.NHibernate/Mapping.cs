using System;
using ConfOrm;
using ConfOrm.NH;
using ConfOrm.Patterns;
using ConfOrm.Shop.CoolNaming;
using NHibernate;
using NHibernate.Cfg.MappingSchema;

namespace SimpleCQRS.ReadModel.NHibernate
{
	public class Mapping
	{

		public HbmMapping Map(params Type[] dtos)
		{
			var orm = new ObjectRelationalMapper();
			var mapper = new Mapper(orm, new CoolPatternsAppliersHolder(orm));

			orm.TablePerClass(dtos);

			orm.Patterns.PoidStrategies.Add(new GuidOptimizedPoidPattern());

			mapper.AddPropertyPattern(
				mi => mi.GetPropertyOrFieldType() == typeof (Decimal) &&
				      mi.Name.Contains("Price"),
				pm => pm.Type(NHibernateUtil.Currency));

			return mapper.CompileMappingFor(dtos);
		}

	}
}
