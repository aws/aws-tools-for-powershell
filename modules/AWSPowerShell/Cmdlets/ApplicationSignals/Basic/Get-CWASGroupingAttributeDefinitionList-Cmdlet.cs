/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Returns the current grouping configuration for this account, including all custom
    /// grouping attribute definitions that have been configured. These definitions determine
    /// how services are logically grouped based on telemetry attributes, Amazon Web Services
    /// tags, or predefined mappings.
    /// </summary>
    [Cmdlet("Get", "CWASGroupingAttributeDefinitionList")]
    [OutputType("Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals ListGroupingAttributeDefinitions API operation.", Operation = new[] {"ListGroupingAttributeDefinitions"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse object containing multiple properties."
    )]
    public partial class GetCWASGroupingAttributeDefinitionListCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID to retrieve grouping attribute definitions for.
        /// Use this when accessing grouping configurations from a different account in cross-account
        /// monitoring scenarios.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter IncludeLinkedAccount
        /// <summary>
        /// <para>
        /// <para>If you are using this operation in a monitoring account, specify <c>true</c> to include
        /// grouping attributes from source accounts in the returned data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeLinkedAccounts")]
        public System.Boolean? IncludeLinkedAccount { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Include this value, if it was returned by the previous operation, to get the next
        /// set of grouping attribute definitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse, GetCWASGroupingAttributeDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            context.IncludeLinkedAccount = this.IncludeLinkedAccount;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.IncludeLinkedAccount != null)
            {
                request.IncludeLinkedAccounts = cmdletContext.IncludeLinkedAccount.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "ListGroupingAttributeDefinitions");
            try
            {
                #if DESKTOP
                return client.ListGroupingAttributeDefinitions(request);
                #elif CORECLR
                return client.ListGroupingAttributeDefinitionsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AwsAccountId { get; set; }
            public System.Boolean? IncludeLinkedAccount { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.ListGroupingAttributeDefinitionsResponse, GetCWASGroupingAttributeDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
