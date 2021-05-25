namespace Testing
{
    public class Player{
        public Player(){}
        public Player(string name){
            Name = name;
            Team = new Team("NewTeam");
        }
        public Player(string name, Team team){
            Name = name;
            Team = team;
        }
        public string Name{get; set;}
        public Team Team{get; set;}
        
    }

    public class Team
    {
        public Team(string name)
        {
            Name = name;
        }

        public string Name{get; set;}
    }
}