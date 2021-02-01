using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework {
    public class Program {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base {
            public Mars Mars { get; private set; }

            [SetUp]
            public void Intialize() {
                this.Mars = new Mars();
            }

            [Test]
            public void CreateServiceListingWithOnlyRequiredFields() {
                Mars.ShareSkillPage
                    .ValidateIfLoaded()
                    .EnterShareSkill();
                Mars.ManageListingsPage
                    .ValidatePageLoaded()
                    .Listings();
            }

            [Test]
            public void EditServiceListingAfterCreating() {
                Mars.ShareSkillPage
                   .ValidateIfLoaded()
                   .EnterShareSkill();
                Mars.ManageListingsPage
                    .ValidatePageLoaded()
                   .Listings();
                Mars.ShareSkillPage
                   .EditShareSkill();
                Mars.ManageListingsPage
                    .ValidatePageLoaded()

                   .Listings();

            }
            [Test]
            public void DeleteListingAfterCreating() {
            }



        }
    }
}