namespace Perfect11.TweaksInterface
{
    public interface IPlugin
    {
        /// <summary>
        /// The display name of the plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A short description of what the plugin does.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Executes the plugin’s main logic.
        /// </summary>
        void Execute();
    }
}
