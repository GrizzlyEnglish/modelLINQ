# modelLINQ
------------
A library to help your write LINQ expressions trees faster and cleaner.

------------

# What is modeLINQ
------------

modeLINQ is a simple library to help you build expression tree object modeling from some source (generally a database) to another source. Removing all the burden of writing all the types of Expressions needed to generate a simple model, allowing you to only worry about the bindings between objects.

# How to use modeLINQ
------------

Lets say we have a class

```
    public class Customer
    {
      public int Id { get; set; }
	    public Person Person { get; set; }
    }
```

And we want to map this to an object for simple querying.

```
	public class CustomerModel
	{
		public int Id { get; set; }
		public PersonModel PersonModel { get; set;}
	}
```

By utilizing modeLINQ this can be easily and quickly generated into an expression tree like so:

```
	 MemberAssignment[] assignments = new MemberAssignment[]
	{
		Expression(typeof(Customer), "source").DirectBind<CustomerModel>("Id"),
		Expression(typeof(Customer), "source").ObjectBind<CustomerModel, Person, PersonModel>("Object", objectAssigments)
	};
```

And then allowing you to easily select via the expression tree
```
CustomerModel model = 
	database.Customers.Select(assigments.Model<Customer, CustomerModel>().Compile()).FirstOrDefault();

```

# Roadmap
------------
- Add in additional "clean" methods to help improve building expression trees
- Add documentation

