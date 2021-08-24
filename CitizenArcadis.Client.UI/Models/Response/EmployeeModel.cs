namespace CitizenArcadis.Client.UI.Models.Response
{
    public class EmployeeModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        public override string ToString()
        {
            return $@"ID: {ID} #  Name: {Name} # Group: {Group}";
        }
    }
}
