namespace MSTests
{
    [TestClass]
    public class UnitTest1
    {
        public void AddConsultation_AddsNewConsultationToDatabase()
        {
            // Arrange
            using (var dbContext = new HealthCentreContext())
            {
                // Create an instance of the class that contains the database logic
                var consultationManager = new ConsultationManager(dbContext);

                var newConsultation = new Consultation
                {
                    Date = DateTime.Now,
                    Recommendation = "Sample recommendation"
                    // Set other properties accordingly
                };

                // Act
                consultationManager.AddConsultation(newConsultation);
                dbContext.SaveChanges();

                // Assert
                var addedConsultation = dbContext.Consultations.FirstOrDefault(c => c.Id == newConsultation.Id);
                Assert.IsNotNull(addedConsultation);
            }
        }
    }
}