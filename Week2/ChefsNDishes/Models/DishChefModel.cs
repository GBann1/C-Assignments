#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ChefsNDishes.Models;

public class DishChefModel
{
    public Dish NewDish {get; set;}
    public List<Chef> Chefs {get; set;}
}