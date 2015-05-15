/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CloudSearch;
using Amazon.CloudSearch.Model;

namespace Amazon.PowerShell.Cmdlets.CS
{
    /// <summary>
    /// Configures an <code><a>Expression</a></code> for the search domain. Used to create
    /// new expressions and modify existing ones. If the expression exists, the new configuration
    /// replaces the old one. For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-expressions.html" target="_blank">Configuring Expressions</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Set", "CSExpression", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearch.Model.ExpressionStatus")]
    [AWSCmdlet("Invokes the DefineExpression operation against Amazon CloudSearch.", Operation = new[] {"DefineExpression"})]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.ExpressionStatus",
        "This cmdlet returns a ExpressionStatus object.",
        "The service call response (type DefineExpressionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetCSExpressionCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String DomainName { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Expression_ExpressionName { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Expression_ExpressionValue { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CSExpression (DefineExpression)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DomainName = this.DomainName;
            context.Expression_ExpressionName = this.Expression_ExpressionName;
            context.Expression_ExpressionValue = this.Expression_ExpressionValue;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DefineExpressionRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate Expression
            bool requestExpressionIsNull = true;
            request.Expression = new Expression();
            String requestExpression_expression_ExpressionName = null;
            if (cmdletContext.Expression_ExpressionName != null)
            {
                requestExpression_expression_ExpressionName = cmdletContext.Expression_ExpressionName;
            }
            if (requestExpression_expression_ExpressionName != null)
            {
                request.Expression.ExpressionName = requestExpression_expression_ExpressionName;
                requestExpressionIsNull = false;
            }
            String requestExpression_expression_ExpressionValue = null;
            if (cmdletContext.Expression_ExpressionValue != null)
            {
                requestExpression_expression_ExpressionValue = cmdletContext.Expression_ExpressionValue;
            }
            if (requestExpression_expression_ExpressionValue != null)
            {
                request.Expression.ExpressionValue = requestExpression_expression_ExpressionValue;
                requestExpressionIsNull = false;
            }
             // determine if request.Expression should be set to null
            if (requestExpressionIsNull)
            {
                request.Expression = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DefineExpression(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Expression;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String DomainName { get; set; }
            public String Expression_ExpressionName { get; set; }
            public String Expression_ExpressionValue { get; set; }
        }
        
    }
}
