using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AWSPowerShellGenerator.Writers
{
    public class IndentedTextWriter : TextWriter
    {
        #region Private members

        private bool _justSawNewline = true;
        private TextWriter _writer;
        private void WriteIndents()
        {
            for (int i = 0; i < Indents; i++)
                _writer.Write(Indent);
        }

        #endregion

        #region Public members

        private int Indents { get; set; }
        public const string Indent = "    ";
        public void OpenRegion(string regionDelimiter = "{")
        {
            WriteLine(regionDelimiter);
            Indents++;
        }
        public void CloseRegion(string regionDelimiter = "}")
        {
            Indents--;
            WriteLine(regionDelimiter);
        }
        public void IncreaseIndent()
        {
            Indents++;
        }
        public void DecreaseIndent()
        {
            Indents--;
            Indents = Math.Max(0, Indents);
        }

        #endregion

        #region Constructors

        public IndentedTextWriter(TextWriter baseWriter)
            : this(baseWriter, 0) { }
        public IndentedTextWriter(TextWriter baseWriter, int indents)
        {
            if (baseWriter == null) throw new ArgumentNullException("baseWriter");
            _writer = baseWriter;
            Indents = indents;
        }

        #endregion

        #region Overrides

        public override void Write(char value)
        {
            if (value != '\r')
            {
                if (_justSawNewline)
                {
                    WriteIndents();
                    _justSawNewline = false;
                }

                if (value == '\n')
                {
                    foreach (char c in NewLine)
                    {
                        _writer.Write(c);
                    }
                    _justSawNewline = true;
                }
                else
                {
                    _writer.Write(value);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_writer != null)
            {
                _writer.Dispose();
                _writer = null;
            }
        }

        public override Encoding Encoding
        {
            get { return _writer.Encoding; }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }

        public override void Close()
        {
            _writer.Close();
        }

        public override void Flush()
        {
            _writer.Flush();
        }

        public override IFormatProvider FormatProvider
        {
            get
            {
                return _writer.FormatProvider;
            }
        }

        public override string NewLine
        {
            get
            {
                return _writer.NewLine;
            }
            set
            {
                _writer.NewLine = value;
            }
        }

        #endregion
    }
}
