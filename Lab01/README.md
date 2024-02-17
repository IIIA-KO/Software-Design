# Principles of Programming Demonstrated in the Provided Code

### 1. DRY (Don't Repeat Yourself):
- The code uses this principle to avoid code repetition. For example, the validity of integer and fractional parts of money is checked in the Money class constructor and overload operators, and not in other methods that use them.
     ```csharp
     public Money(int wholePart, int fractionalPart, Currency currency)
     {
      if (wholePart < 0)
      {
         throw new ArgumentException("Whole part cannot has value less than 0", nameof(wholePart));
      }

      if (fractionalPart < 0 || fractionalPart > 99)
      {
         throw new ArgumentException("Fractional part can only has values from 0 to 99", nameof(fractionalPart));
      }

      this.WholePart = wholePart;
      this.FractionalPart = fractionalPart;
      this.Currency = currency;
     }
     ```
### 2. KISS (Keep It Simple, Stupid):
- The KISS principle is followed because the code is quite simple and straightforward. For example, the methods of the `Warehouse` class are simple and do one specific job - adding, deleting, and retrieving warehouse units.
```csharp
public void AddUnit(WarehouseUnit unit)
{
   if (unit == null)
   {
      throw new ArgumentNullException(nameof(unit), "Unit cannot be null.");
   }
   
   this._units[unit.ProductName] = unit;
}

public bool RemoveUnit(WarehouseUnit unit)
{
   if (unit == null)
   {
      throw new ArgumentNullException(nameof(unit), "Unit cannot be null.");
   }
   
   return this._units.Remove(unit.ProductName);
}

public WarehouseUnit GetUnitByName(string productName)
{
   if (string.IsNullOrWhiteSpace(productName))
   {
      throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
   }
   
   this._units.TryGetValue(productName, out var unit);
   
   return unit ?? throw new InvalidOperationException($"No unit found with product name {productName}.");
}

public bool Exists(string productName)
{
   if (string.IsNullOrWhiteSpace(productName))
   {
      throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
   }
   
   return this._units.ContainsKey(productName);
}

public IEnumerable<WarehouseUnit> GetUnits()
{
   return this._units.Values;
}

public int GetTotalQuantity()
{
   return this._units.Values.Sum(u => u.Quantity);
}


public void Clear()
{
   this._units.Clear();
}
```

### 3. Fail Fast:
- The fail fast principle is a design pattern used in software development to immediately report any exception in an application, rather than trying to continue execution. For example, int the `Money` class comparison operators, the exception is thrown when Currencies are not equal.
   ```csharp
   public static bool operator >(Money a, Money b) =>
      a.Currency == b.Currency ? a.Amount > b.Amount
      : RaiseCurrencyComparisonError(a, b);

   public static bool operator <(Money a, Money b) =>
      a.Currency == b.Currency ? a.Amount < b.Amount
      : RaiseCurrencyComparisonError(a, b);

   public static bool operator >=(Money a, Money b) =>
      a.Currency == b.Currency ? a.Amount >= b.Amount
      : RaiseCurrencyComparisonError(a, b);
       
   public static bool operator <=(Money a, Money b) =>
      a.Currency == b.Currency ? a.Amount <= b.Amount
      : RaiseCurrencyComparisonError(a, b);
   ```

### 4. Composition Over Inheritance:
- The code demonstrates the use of composition instead of inheritance. For example, the `WarehouseUnit` class contains a ``_product`` instance of type `Product` instead of inheriting from `Product`.
   ```csharp
   public void UpdateProductPrice(Money newPrice)
   {
       this._product.ChangePrice(newPrice);
   }
   
   public void IncreaseProductPrice(Money amount)
   {
       this._product.IncreasePrice(amount);
   }
   
   public void DecreaseProductPrice(Money amount)
   {
       this._product.DecreasePrice(amount);
   }
   ```

### 5. **YAGNI (You Ain't Gonna Need It)**:
- The code follows YAGNI principle by avoiding speculative features or functionalities that are not immediately needed. It provides only the necessary functionality for managing warehouse inventory and reporting.

### 6. SOLID Principles:
   - **Single Responsibility Principle (SRP)**:
      - Each class has a single responsibility. For example, the `Product` class is responsible for representing a product, while the `Warehouse` class manages the storage of products.
   - **Open/Closed Principle (OCP)**:
      - The code is designed to be easily extensible without modifying existing code. For example, new types of products can be added without changing the existing `Warehouse` or `WarehouseUnit` classes.
   - **Liskov Substitution Principle (LSP)**:
      - The code demonstrates LSP by allowing substitution of base classes with their derived classes without affecting the functionality. For instance, `DiscountedProduct` and `StandartProduct` are subclasses of `Product` and can be used interchangeably.
         ```csharp
         var product1 = new StandartProduct("Standart Product", price1);
         var product2 = new DiscountedProduct("DiscountProduct", price2, 0.25m);

         var unit1 = new WarehouseUnit(product1, "pcs", 100, DateTime.Now.AddDays(-10));
         var unit2 = new WarehouseUnit(product2, "kg", 50, DateTime.Now.AddDays(-5));

         var warehouse = new Warehouse();
         warehouse.AddUnit(unit1);
         warehouse.AddUnit(unit2);
         ```
   - **Dependency Inversion Principle (DIP)**:
      - The code follows DIP by depending on abstractions rather than concrete implementations. For example, the `WarehouseUnit` class depends on the abstract `Product` class, allowing flexibility in swapping implementations.