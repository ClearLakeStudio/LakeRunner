/*
 * Filename: Map.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Defines the most generic map type.
 */

/*
 * List methods a publisher must have.
 */
public interface IPublisher
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void Notify();
}

/*
 * Lists methods a subscriber must have.
 */
public interface ISubscriber
{
    void Init(string levelName);
    void Update(IPublisher publisher);
}
