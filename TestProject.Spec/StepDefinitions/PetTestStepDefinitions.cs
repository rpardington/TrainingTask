using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using TestProject.Models;
using TestProject.Utils;

namespace TestProject.Spec.StepDefinitions
{
    [Binding]
    public class PetTestStepDefinitions
    {
        [Given("I have a created the following pet:")]
        public void GivenIHaveACreatedTheFollowingPet(Table table)
        {
           var pet = table.CreateInstance<Pet>();
            PetStoreApiUtils.PostPet(pet);
        }

        [Then("pet name is '([^']*)' for pet '([^']*)'")]
        public void ThenPetNameIs(string petName, long petId)
        { 
            Assert.That(
                PetStoreApiUtils.GetPetById(petId).Name, 
                Is.EqualTo(petName), 
                "Pet name is not as expected");
        }

        [When("I change the pet name to '([^']*)' for pet '([^']*)'")]
        public void WhenIChangeThePetNameTo(string updatedPetName, long petId)
        {
            var pet = PetStoreApiUtils.GetPetById(petId);
            pet.Name = updatedPetName;
            PetStoreApiUtils.PutPet(pet);
        }
    }
}