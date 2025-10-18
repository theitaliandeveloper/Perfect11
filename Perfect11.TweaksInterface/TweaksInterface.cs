namespace Perfect11.TweaksInterface
{
    public interface IPlugin
    {
        /// <summary>
        /// The display name of the tweak.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A short description of what the tweak does.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The category of the tweak
        /// </summary>
        string Category { get; }

        /// <summary>
        /// Executes the plugin’s main logic.
        /// </summary>
        string Execute();
    }
}
