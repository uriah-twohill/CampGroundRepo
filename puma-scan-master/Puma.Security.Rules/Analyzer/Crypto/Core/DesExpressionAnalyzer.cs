﻿/* 
 * Copyright(c) 2016 - 2019 Puma Security, LLC (https://www.pumascan.com)
 * 
 * Project Leader: Eric Johnson (eric.johnson@pumascan.com)
 * Lead Developer: Eric Mead (eric.mead@pumascan.com)
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 */

using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using Puma.Security.Rules.Common;

namespace Puma.Security.Rules.Analyzer.Crypto.Core
{
    internal class DesExpressionAnalyzer : IDesExpressionAnalzyer
    {
        public bool IsVulnerable(SemanticModel model, ObjectCreationExpressionSyntax syntax, DiagnosticId ruleId)
        {
            //Check for the type
            if (!ContainsTypeName(syntax)) return false;

            //If we found it, verify the namespace
            var symbol = model.GetSymbolInfo(syntax).Symbol;

            if (!IsType(symbol)) return false;

            return true;
        }

        private static bool ContainsTypeName(ObjectCreationExpressionSyntax syntax)
        {
            return syntax.Type.ToString().Equals("DESCryptoServiceProvider");
        }

        private bool IsType(ISymbol symbol)
        {
            if (symbol == null)
                return false;

            return symbol.ContainingNamespace.ToString().Equals("System.Security.Cryptography");
        }
    }
}