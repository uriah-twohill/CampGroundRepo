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

using System.Linq;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

using Puma.Security.Rules.Analyzer.Core;

using Puma.Security.Rules.Analyzer.Core.Factories;
using Puma.Security.Rules.Analyzer.Injection.Ldap.Core;
using Puma.Security.Rules.Common;
using Puma.Security.Rules.Diagnostics;

namespace Puma.Security.Rules.Analyzer.Injection.Ldap
{
    [SupportedDiagnostic(DiagnosticId.SEC0114)]
    internal class LdapDirectoryEntryPathCreationAnalyzer : BaseCodeBlockAnalyzer, ISyntaxAnalyzer
    {
        private readonly ILdapDirectoryEntryPathInjectionExpressionAnalyzer _expressionSyntaxAnalyzer;
        private readonly IObjectCreationExpressionVulnerableSyntaxNodeFactory _vulnerableSyntaxNodeFactory;

        internal LdapDirectoryEntryPathCreationAnalyzer() : this(new LdapDirectoryEntryPathInjectionExpressionAnalyzer(), new ObjectCreationExpressionVulnerableSyntaxNodeFactory()) { }

        private LdapDirectoryEntryPathCreationAnalyzer(
            ILdapDirectoryEntryPathInjectionExpressionAnalyzer expressionSyntaxAnalyzer,
            IObjectCreationExpressionVulnerableSyntaxNodeFactory vulnerableSyntaxNodeFactory)
            
        {
            _expressionSyntaxAnalyzer = expressionSyntaxAnalyzer;
            _vulnerableSyntaxNodeFactory = vulnerableSyntaxNodeFactory;
        }

        public SyntaxKind SinkKind => SyntaxKind.ObjectCreationExpression;

        public override void GetSinks(SyntaxNodeAnalysisContext context, DiagnosticId ruleId)
        {
            var syntax = context.Node as ObjectCreationExpressionSyntax;

            if (!_expressionSyntaxAnalyzer.IsVulnerable(context.SemanticModel, syntax, this.GetDiagnosticId()))
                return;

            if (VulnerableSyntaxNodes.All(p => p.Sink.GetLocation() != syntax?.GetLocation()))
                VulnerableSyntaxNodes.Push(_vulnerableSyntaxNodeFactory.Create(syntax));
        }
    }
}