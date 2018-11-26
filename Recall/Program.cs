using System;

namespace Recall
{
    public class TextEditor
    {

        public void CreateCode(string code)
        {

        }

        public void Save() { }
    }

    public class Compiler
    {
        public void Compile() { }
    }

    public class CLR
    {
        public void Execute()
        {

        }

        public void Finish() { }
    }

    public class VisualStudioFacade
    {
        protected TextEditor _textEditor;
        protected Compiler _compiler;
        protected CLR _clr;

        public VisualStudioFacade()
        {
            _textEditor = new TextEditor();
            _compiler = new Compiler();
            _clr = new CLR();
        }

        public void Start(string code)
        {
            _textEditor.CreateCode(code);
            _textEditor.Save();

            _compiler.Compile();

            _clr.Execute();

        }

        public void Stop()
        {
            _clr.Finish();
        }
    }

    public class Programmer
    {
        public void Run(VisualStudioFacade facade, string code)
        {
            facade.Start(code);
            facade.Stop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VisualStudioFacade facade = new VisualStudioFacade();
            Programmer programmer = new Programmer();

            programmer.Run(facade, "myCode");
        }
    }
}
