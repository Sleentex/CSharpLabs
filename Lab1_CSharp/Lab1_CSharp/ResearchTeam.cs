using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CSharp
{
    class ResearchTeam
    {
        private string _researchTopicName;
        private string _organizationName;
        private int _registerNumber;
        private TimeFrame _durationOfStudy;
        private Paper[] _papers;   

        public string ResearchTopicName { get => _researchTopicName; set => _researchTopicName = value; }
        public string OrganizationName { get => _organizationName; set => _organizationName = value; }
        public int RegisterNumber { get => _registerNumber; set => _registerNumber = value; }
        public TimeFrame DurationOfStudy { get => _durationOfStudy; set => _durationOfStudy = value; }
        public Paper[] Papers { get => _papers; set => _papers = value; }
        public bool this[TimeFrame index] { get => DurationOfStudy.Equals(index); }
        
        public ResearchTeam()
        {
            ResearchTopicName = "ResearchTopicName";
            OrganizationName = "OrganizationName";
            RegisterNumber = 12345;
            DurationOfStudy = TimeFrame.TWO_YEARS;
            Papers = new Paper[] { new Paper() };
        }

        public ResearchTeam(string researchTopicName, string organizationName, int registerNumber, TimeFrame durationOfStudy)
        {
            ResearchTopicName = researchTopicName;
            OrganizationName = organizationName;
            RegisterNumber = registerNumber;
            DurationOfStudy = durationOfStudy;
            Papers = new Paper[] {};
        }

        public Paper GetLastPublication()
        { 
            return Papers.Where(p1 => p1.Date.Equals(Papers.Max(p2 => p2.Date))).FirstOrDefault();
        }

        public void AddPapers(params Paper[] papers)
        {
            int length = Papers.Length;
            Array.Resize(ref _papers, Papers.Length + papers.Length);

            for (int i = 0; i < papers.Length ; i++)
            {         
                Papers[length++] = papers[i];
            }
        }

        public string GetPapers()
        {
            string str = "";
            int i = 1;
            foreach (Paper paper in Papers)
            {
                str = str + i++ + ") " + paper.ToString() + "\n";
            }
            return str;
        }


        public override string ToString()
        {
            return "Назва теми дослiдження: " + ResearchTopicName + "\n" + "Назва органiзацiї: " + OrganizationName + "\n" + "Реєстрацiйний номер: " +  RegisterNumber + "\n" + 
                   "Тривалiсть дослiдження: " + DurationOfStudy + "\n" + "Список публiкацiй: \n" + GetPapers(); //Papers.Select(p => p.Name);
        }

        public virtual string ToShorString()
        {
            return "Назва теми дослiдження: " + ResearchTopicName + "\n" + "Назва органiзацiї: " + OrganizationName + "\n" + "Реєстрацiйний номер: " + RegisterNumber + "\n" +
                   "Тривалiсть дослiдження: " + DurationOfStudy + "\n";
        }
    }
}
