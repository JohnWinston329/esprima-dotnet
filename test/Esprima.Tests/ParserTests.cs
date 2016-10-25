﻿using System.Linq;
using Esprima.Ast;
using Xunit;

namespace Esprima.Tests
{
    public class ParserTests
    {
        [Fact]
        public void ProgramShouldBeStrict()
        {
            var parser = new JavaScriptParser("'use strict'; function p() {}");
            var program = parser.ParseProgram();

            Assert.True(program.Strict);
        }

        [Fact]
        public void ProgramShouldNotBeStrict()
        {
            var parser = new JavaScriptParser("function p() {}");
            var program = parser.ParseProgram();

            Assert.False(program.Strict);
        }

        [Fact]
        public void FunctionShouldNotBeStrict()
        {
            var parser = new JavaScriptParser("function p() {}");
            var program = parser.ParseProgram();
            var function = program.Body.First().As<FunctionDeclaration>();

            Assert.False(function.Strict);
        }

        [Fact]
        public void FunctionShouldBeStrictInProgramStrict()
        {
            var parser = new JavaScriptParser("'use strict'; function p() {}");
            var program = parser.ParseProgram();
            var function = program.Body.Skip(1).First().As<FunctionDeclaration>();

            Assert.False(function.Strict);
        }

        [Fact]
        public void FunctionShouldBeStrict()
        {
            var parser = new JavaScriptParser("function p() {'use strict'; return false;}");
            var program = parser.ParseProgram();
            var function = program.Body.First().As<FunctionDeclaration>();

            Assert.True(function.Strict);
        }

        [Fact]
        public void LabelSetShouldPointToStatement()
        {
            var parser = new JavaScriptParser("here: Hello();");
            var program = parser.ParseProgram();
            var labeledStatement = program.Body.First().As<LabeledStatement>();
            var body = labeledStatement.Body;

            Assert.Equal(labeledStatement.Label, body.LabelSet);
        }

    }
}
