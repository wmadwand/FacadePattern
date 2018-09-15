using System;
namespace Facade1
{
    #region Classes of VisualStudio's IDE subsystem
    public class TextEditor
    {
        public void CreateCode(string code)
        {
            Console.WriteLine("Create code");
        }

        public void Save()
        {
            Console.WriteLine("Save code");
        }
    }

    public class Compiler
    {
        public void Compile()
        {
            Console.WriteLine("Compile");
        }
    }

    public class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Execute");
        }

        public void Finish()
        {
            Console.WriteLine("Finish");
        }
    }
    #endregion

    public class VisualStudioFacade
    {
        private TextEditor _textEd;
        private Compiler _compiler;
        private CLR _clr;

        public VisualStudioFacade()
        {
            _textEd = new TextEditor();
            _compiler = new Compiler();
            _clr = new CLR();
        }

        public VisualStudioFacade(TextEditor textEd, Compiler compiler, CLR clr)
        {
            _textEd = textEd;
            _compiler = compiler;
            _clr = clr;
        }

        public void Start(string code)
        {
            _textEd.CreateCode(code);
            _textEd.Save();

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
        public void CreateApp(VisualStudioFacade facade, string code)
        {
            facade.Start(code);
            facade.Stop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Programmer prog = new Programmer();
            VisualStudioFacade facade = new VisualStudioFacade();

            prog.CreateApp(facade, "MyCode");
        }
    }
}
