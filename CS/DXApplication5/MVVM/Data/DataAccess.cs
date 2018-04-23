using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DXApplication5.MVVM.Data {
    public class DataAccessHelper {
        public static BindingList<Customer> GetCustomers() {
            BindingList<Customer> dt = new BindingList<Customer>();
            for (int i = 0; i < 1000; i++) {
                dt.Add(new Customer { ID = i, FirstName = string.Format("Name {0}", i), LastName = string.Format("Last Name {0}", i) });
            }
            return dt;
        }
    }
}
