![modelLINQ Logo](https://thegrizzlyenglish.com/img/modelLINQ_Logo.png)

------------

modelLINQ is a simple library to help you build and reuse expression tree data transfer object modeling from some source (generally a database) to another source. Removing all the burden of writing all the types of Expressions needed to generate a simple model, allowing you to only worry about the bindings between objects.

[Documentation](https://thegrizzlyenglish.com/files/documentation/modellinq)

## How to use

dotnet cli

    dotnet add package modelLINQ

Package Manager

    Install-Package modelLINQ

Or see on [Nuget](https://www.nuget.org/packages/modelLINQ/)

Begin writing DTO bindings!

## How to write bindings

Let's say we have a class. Let's also assume it is a context class.


	public class Customer
    {
        public int Id { get; set; }
	    public Person Person { get; set; }
    }

And we want to be able to map to a an object - Keeping it simple.

	public class CustomerModel
	{
		public int Id { get; set; }
		// Let's just assume this is defined
		public PersonModel PersonModel { get; set;}
	}

With modelLINQ we can create a reusable expression tree to build this model. Lets look at the basic bindings.

    // By taking a parameter expression we can define the bindings
    static Func<Expression, MemeberAssignment[]> bindings = param =>
    {
	    return new MemberAssignment[] {
		    param.DirectBind<CustomerModel>("Id"),
		    // Notice we can easily reuse previously made bindings
		    param.ObjectBind<CustomerModel, Person, PersonModel>(
			    "PersonModel", PersonModel.bindings, "Person")
	    };
	};

And now we can use our bindings to project the `CustomerModel`

    databse.Customers.Select(bindings.Model<Customer, CustomerModel>()).ToList()

## Additional Information

I left all the functions public to allow the developer to create additional binding trees based on the existing. If you notice there are missing functions that you find yourself using a lot, please open an issue!

Made with <span style="color: #e25555;">&#9829;</span> by Ryan English
