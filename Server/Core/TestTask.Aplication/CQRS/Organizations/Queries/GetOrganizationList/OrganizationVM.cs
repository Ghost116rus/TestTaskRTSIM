using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Aplication.CQRS.Organizations.Queries.GetOrganizationList
{
    public class OrganizationVM : IMapWith<Organization>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationVM>();
        }
    }
}
