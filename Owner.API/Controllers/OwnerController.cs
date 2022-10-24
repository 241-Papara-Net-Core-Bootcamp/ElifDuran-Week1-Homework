using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Owner.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class OwnerController : ControllerBase
    {
        [Route("AllOwners")]
        [HttpGet]
        public List<Owner.API.Modal.Owner> GetAllOwners()
        {
            List<Owner.API.Modal.Owner> ownerList = new List<Owner.API.Modal.Owner>();
            DateTime today = DateTime.Now;
            Owner.API.Modal.Owner owner1 = new Owner.API.Modal.Owner()
            {
                Id = 1,
                Name = "Elif",
                Surname = "Duran",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                Type = "Type1",
                Date = today                
            };
            ownerList.Add(owner1);

            Owner.API.Modal.Owner owner2 = new Owner.API.Modal.Owner()
            {
                Id = 2,
                Name = "Sena",
                Surname = "Duran",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                Type = "Type2",
                Date = today                
            };

            ownerList.Add(owner2);

            Owner.API.Modal.Owner owner3 = new Owner.API.Modal.Owner()
            {
                Id = 3,
                Name = "Çağlar",
                Surname = "Duran",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                Type = "Type3",
                Date = today
            };

            ownerList.Add(owner3);
            return ownerList;
        }

        [Route("DeleteOwner/{id}")]
        [HttpDelete]
        public bool DeleteOwner(int ownerId)
        {
            List<Owner.API.Modal.Owner> ownerList = new List<Owner.API.Modal.Owner>();
            DateTime today = DateTime.Now;
            Owner.API.Modal.Owner owner1 = new Owner.API.Modal.Owner()
            {
                Id = 1,
                Name = "Elif",
                Surname = "Duran",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                Type = "Type1",
                Date = today
            };

            ownerList.Add(owner1);

            Owner.API.Modal.Owner owner2 = new Owner.API.Modal.Owner()
            {
                Id = 2,
                Name = "Sena",
                Surname = "Duran",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                Type = "Type2",
                Date = today
            };

            ownerList.Add(owner2);

            var selectedOwner = ownerList.FirstOrDefault(x=> x.Id == ownerId);

            return ownerList.Remove(selectedOwner);           
           
        }

        [Route("UpdateOwner")]
        [HttpPut]
        public Owner.API.Modal.Owner UpdateOwner(Owner.API.Modal.Owner owner)
        {
            var allOwners = GetAllOwners();
            var updatedOwner = allOwners.Find(x => x.Id == owner.Id);
            updatedOwner.Id = owner.Id;
            updatedOwner.Name = owner.Name;
            updatedOwner.Surname = owner.Surname;
            updatedOwner.Description = owner.Description;
            updatedOwner.Date = owner.Date;
            updatedOwner.Type = owner.Type;

            return updatedOwner;
        }

        [ConsumesAttribute("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Modal.Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Modal.Owner))]
        [Route("CheckDescripton")]
        [HttpPost]
        public IActionResult CheckOwnerDescription([FromBody]string keyword)
        {
            var owners = GetAllOwners();
            var lowerCaseWord = keyword.ToLower();
            var isKeywordFound = owners.Any(x => x.Description.Contains(lowerCaseWord));
            if (isKeywordFound)
            {
                return Ok("Keyword found in description");
            }
            else
            {
                return NotFound("Keyword does not found in description!");
            }
        }
    }
}
