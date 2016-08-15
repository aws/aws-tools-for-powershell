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
    /// Gets the expressions configured for the search domain. Can be limited to specific
    /// expressions by name. By default, shows all expressions and includes any pending changes
    /// to the configuration. Set the <code>Deployed</code> option to <code>true</code> to
    /// show the active configuration and exclude pending changes. For more information, see
    /// <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-expressions.html" target="_blank">Configuring Expressions</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Get", "CSExpression")]
    [OutputType("Amazon.CloudSearch.Model.ExpressionStatus")]
    [AWSCmdlet("Invokes the DescribeExpressions operation against Amazon CloudSearch.", Operation = new[] {"DescribeExpressions"})]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.ExpressionStatus",
        "This cmdlet returns a collection of ExpressionStatus objects.",
        "The service call response (type Amazon.CloudSearch.Model.DescribeExpressionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCSExpressionCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        #region Parameter Deployed
        /// <summary>
        /// <para>
        /// <para>Whether to display the deployed configuration (<code>true</code>) or include any pending
        /// changes (<code>false</code>). Defaults to <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Deployed { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain you want to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter ExpressionName
        /// <summary>
        /// <para>
        /// <para>Limits the <code><a>DescribeExpressions</a></code> response to the specified expressions.
        /// If not specified, all expressions are shown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ExpressionNames")]
        public System.String[] ExpressionName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("Deployed"))
                context.Deployed = this.Deployed;
            context.DomainName = this.DomainName;
            if (this.ExpressionName != null)
            {
                context.ExpressionNames = new List<System.String>(this.ExpressionName);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudSearch.Model.DescribeExpressionsRequest();
            
            if (cmdletContext.Deployed != null)
            {
                request.Deployed = cmdletContext.Deployed.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.ExpressionNames != null)
            {
                request.ExpressionNames = cmdletContext.ExpressionNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Expressions;
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
        
        #region AWS Service Operation Call
        
        private static Amazon.CloudSearch.Model.DescribeExpressionsResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.DescribeExpressionsRequest request)
        {
            #if DESKTOP
            return client.DescribeExpressions(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeExpressionsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? Deployed { get; set; }
            public System.String DomainName { get; set; }
            public List<System.String> ExpressionNames { get; set; }
        }
        
    }
}
