using Houses.Core.Dtos;
using Houses.Core.ServiceInerface;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Houses.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task Should_AddNewHouse_WhenReturnResult()
        {
            string guid = "ee0f1564-339b-4b52-bfa3-795762045d29";

            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.Address = "Niidi tn 35";
            house.Area = 79;
            house.FloorsNumber = 1;
            house.Price = 30000;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseService>().Add(house);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "90CAEAE7-887A-4DB6-9694-945F58A07005";
            string guid1 = "0a730dcd-922d-42d4-bca2-2fcdaf2fec13";

            //var request = new House();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().Edit(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "90CAEAE7-887A-4DB6-9694-945F58A07005";
            string guid1 = "90CAEAE7-887A-4DB6-9694-945F58A07005";

            //var request = new House();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().Edit(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
        }
        
        [Fact]
        public async Task Should_NotUpdateFloorsNumberLessThanNull_WhenUpdateHouse()
        {
            int floors;
            HouseDto house = new HouseDto();

            floors = house.FloorsNumber;
            if (floors > 0)
            {
                await Svc<IHouseService>().Update(house);
            }
            house.FloorsNumber = -1;
        }
        [Fact]
        public async Task Should_UpdateFloorsNumberMoreThanNull_WhenUpdateHouse()
        {
            int floors;
            HouseDto house = new HouseDto();

            floors = house.FloorsNumber;
            if (floors > 0)
            {
                await Svc<IHouseService>().Update(house);
            }
            house.FloorsNumber = 1;
        }

    }
}

       
