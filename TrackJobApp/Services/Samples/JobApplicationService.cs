using System.Linq;
using TrackJobApp.Models.EntityModels;

namespace TrackJobApp.Services.Samples
{
    public class JobApplicationService : IJobApplicationService
    {
        public IEnumerable<JobApplication> GetApplications()
        {
            var exampleJobApplications = _createJobApplications();

            if (exampleJobApplications.Count() > 1)
            {
                return exampleJobApplications;
            }
            else
            {
                return [];
            }
        }

        public JobApplication GetApplicationById(int id)
        {
            var jobApplication = GetApplications().First(application => application.Id == id);

            if (jobApplication is not null)
            {
                return jobApplication;
            }

            return new JobApplication() { Id = 1, PositionName = "No Position Available!" };
        }

        private static IEnumerable<JobApplication> _createJobApplications()
        {
            var currentIndex = 0;
            var jobs = new List<JobApplication>();
            _getCsvJobApplicationArray().ToList().ForEach(arrayElement =>
            {
                var spreadsheetColumns = arrayElement.Split(';');
                jobs.Add(new JobApplication()
                {
                    Id = currentIndex,
                    PositionName = spreadsheetColumns[(int)ColumnIndex.PositionName].Trim(),
                    Company = new Company() { Name = spreadsheetColumns[(int)ColumnIndex.Company].Trim(), IsDomestic = false },
                    Location = new Location() { FullLocation = spreadsheetColumns[(int)ColumnIndex.Place].Trim() },
                    ListedOnSite = new Uri($"https://www.{spreadsheetColumns[(int)ColumnIndex.ListedOn].ToLower().Trim()}"),
                    ApplicationDate = DateOnly.Parse(spreadsheetColumns[(int)ColumnIndex.DateApplied]),
                    StatusAsString = spreadsheetColumns[(int)ColumnIndex.Status].Trim(),
                    Notes = spreadsheetColumns[(int)ColumnIndex.Notes].Trim(),
                    Description = new PositionDescription() { DescriptionText = spreadsheetColumns[(int)ColumnIndex.JobDescription].Trim() }
                });
                currentIndex++;
            });

            return jobs;
        }

        private static string[] _getCsvJobApplicationArray()
        {
            return ["Software Engineer;Awesome Company LLC;Remote;07.05.2024;Helloworld.rs;Pending;CV sent without a cover letter;",
                    "Application Security Engineer;Software Facade Inc.;\"San Francisco, USA\";07.05.2024;Helloworld.rs;Pending;Applied through a third-party site;",
                    ".NET Developer;WeWriteWords LLC;Remote;07.05.2024;;Pending;LinkedIn Easy Apply;",
                    "Software Engineer;Las Vegas Software Inc;\"Las Vegas, USA (Hybrid)\";08.05.2024;LinkedIn.com;Pending;E-mail not confirmed;",
                    "Back End Developer;ESD ltd;\"London, UK (On-Site)\";08.05.2024;LinkedIn.com;Pending;;",
                    "Full Stack Software Engineer;Softclose doo;\"Belgrade, SRB (Hybrid)\";09.05.2024;;Rejected;Not enough relevant experience;",
                    "Full Stack Developer;HiTecc1;Remote;10.05.2024;LinkedIn.com;Pending;;",
                    "DevOps Engineer;Upp & Daun AG;\"Berlin, DE (On-Site)\";12.05.2024;LinkedIn.com;Pending;;",
                    "Software Developer;Superb Development Industries;;12.05.2024;LinkedIn.com;Interview;Applied through their website;",
                    "Front End Developer;NorDev AS;\"Oslo, Norway \";15.05.2024;LinkedIn.com;Pending;Application sent with LinkedIn Easy Apply;"];
        }

        enum ColumnIndex
        {
            PositionName = 0,
            Company = 1,
            Place = 2,
            DateApplied = 3,
            ListedOn = 4,
            Status = 5,
            Notes = 6,
            JobDescription = 7
        }
    }
}

