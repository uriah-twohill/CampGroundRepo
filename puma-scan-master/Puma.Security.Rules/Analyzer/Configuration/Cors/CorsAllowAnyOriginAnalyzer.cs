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
using Puma.Security.Rules.Analyzer.Configuration.Cors.Core;
using Puma.Security.Rules.Analyzer.Core;
using Puma.Security.Rules.Common;
using Puma.Security.Rules.Diagnostics;

namespace Puma.Security.Rules.Analyzer.Configuration.Cors
{
    [SupportedDiagnostic(DiagnosticId.SEC0121)]
    internal class CorsAllowAnyOriginAnalyzer : BaseSemanticAnalyzer, ISyntaxAnalyzer
    {
        private readonly ICorsExpressionAnalyzer _expressionSyntaxAnalyzer;

        internal CorsAllowAnyOriginAnalyzer() : this(new CorsExpressionAnalyzer()) { }

        private CorsAllowAnyOriginAnalyzer(ICorsExpressionAnalyzer expressionSyntaxAnalyzer)
        {
            _expressionSyntaxAnalyzer = expressionSyntaxAnalyzer;
        }

        public SyntaxKind SinkKind => SyntaxKind.SimpleMemberAccessExpression;

        public override void GetSinks(SyntaxNodeAnalysisContext context, DiagnosticId ruleId)
        {
            //Standard object creation expression
            if (context.Node is MemberAccessExpressionSyntax syntax)
            {
                if (!_expressionSyntaxAnalyzer.IsVulnerable(context.SemanticModel, syntax, ruleId))
                    return;

                if (VulnerableSyntaxNodes.All(p => p.Sink.GetLocation() != syntax.GetLocation()))
                    VulnerableSyntaxNodes.Push(new VulnerableSyntaxNode(syntax));
            }
        }
    }
}
