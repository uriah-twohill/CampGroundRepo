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

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

using System.Linq;

using Puma.Security.Rules.Analyzer.Core;
using Puma.Security.Rules.Common;
using Puma.Security.Rules.Diagnostics;

using Puma.Security.Rules.Analyzer.Core.Factories;
using Puma.Security.Rules.Analyzer.Injection.Ldap.Core;

namespace Puma.Security.Rules.Analyzer.Injection.Ldap
{

    [SupportedDiagnostic(DiagnosticId.SEC0119)]
    internal class LdapDirectorySearcherFilterAssignmentAnalyzer : BaseCodeBlockAnalyzer, ISyntaxAnalyzer
    {
        private readonly ILdapDirectorySearcherFilterAssignmentExpressionAnalyzer _expressionSyntaxAnalyzer;
        private readonly IAssignmentExpressionVulnerableSyntaxNodeFactory _vulnerableSyntaxNodeFactory;

        internal LdapDirectorySearcherFilterAssignmentAnalyzer() : this(new LdapDirectorySearcherFilterAssignmentExpressionAnalyzer(), new AssignmentExpressionVulnerableSyntaxNodeFactory()) { }

        private LdapDirectorySearcherFilterAssignmentAnalyzer(
            ILdapDirectorySearcherFilterAssignmentExpressionAnalyzer expressionSyntaxAnalyzer,
            IAssignmentExpressionVulnerableSyntaxNodeFactory vulnerableSyntaxNodeFactory)
            
        {
            _expressionSyntaxAnalyzer = expressionSyntaxAnalyzer;
            _vulnerableSyntaxNodeFactory = vulnerableSyntaxNodeFactory;
        }

        public SyntaxKind SinkKind => SyntaxKind.SimpleAssignmentExpression;

        public override void GetSinks(SyntaxNodeAnalysisContext context, DiagnosticId ruleId)
        {
            var syntax = context.Node as AssignmentExpressionSyntax;

            if (!_expressionSyntaxAnalyzer.IsVulnerable(context.SemanticModel, syntax, ruleId))
                return;

            if (VulnerableSyntaxNodes.All(p => p.Sink.GetLocation() != syntax?.Left.GetLocation()))
                VulnerableSyntaxNodes.Push(_vulnerableSyntaxNodeFactory.Create(syntax));
        }
    }
    }
