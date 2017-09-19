using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    /*
     * Here you can store player progress / player info data. Save, load, synch in cloud.. etc.
     * Inject into systems that need the info. For example actual player ship and weapons, currency state...
     * */
    public class UserData
    {
        public int Id = 0;
        public int Money = 0;
    }
}
