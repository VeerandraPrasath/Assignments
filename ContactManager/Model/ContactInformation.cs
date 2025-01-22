namespace ContactManager.Model
{
    /// <summary>
    ///Store information of contact
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// Name of the contact
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email of the contact
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of contact
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Additional notes of contact
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Initialize Contact
        /// </summary>
        /// <param name="name">Name of the contact</param>
        /// <param name="email">Email of the Contact</param>
        /// <param name="phone">Phone number of Contact</param>
        /// <param name="notes">Any additional notes</param>
        public ContactInformation(string name, string email, string phone, string notes)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Notes = notes;
        }

        /// <summary>
        /// Gives the details of the contact 
        /// </summary>
        /// <returns>returns string with all details</returns>
        public override string ToString()
        {
            return $"Name :{Name} , Email :{Email} ,Phone :{Phone} ,Notes :{Notes}";
        }
    }
}