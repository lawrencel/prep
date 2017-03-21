namespace code.utility.matching
{
    //functional def of specification
    //determine if something meets a condition
  public delegate bool Criteria<in Element>(Element element);
}