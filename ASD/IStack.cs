namespace ASD
{
    public interface IStack<Item> 
    {
        bool isEmpty();
        Item peek();
        Item pop();
        void push(Item item);
        int size();
    }
}