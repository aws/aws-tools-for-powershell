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
using System.Threading;
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the number of resources that are compliant and the number that are noncompliant.
    /// You can specify one or more resource types to get these numbers for each resource
    /// type. The maximum number returned is 100.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceSummaryByResourceType")]
    [OutputType("Amazon.ConfigService.Model.ComplianceSummaryByResourceType")]
    [AWSCmdlet("Calls the AWS Config GetComplianceSummaryByResourceType API operation.", Operation = new[] {"GetComplianceSummaryByResourceType"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ComplianceSummaryByResourceType or Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ComplianceSummaryByResourceType objects.",
        "The service call response (type Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGComplianceSummaryByResourceTypeCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specify one or more resource types to get the number of resources that are compliant
        /// and the number that are noncompliant for each resource type.</para><para>For this request, you can specify an Amazon Web Services resource type such as <c>AWS::EC2::Instance</c>.
        /// You can specify that the resource type is an Amazon Web Services account by specifying
        /// <c>AWS::::Account</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComplianceSummariesByResourceType'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComplianceSummariesByResourceType";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse, GetCFGComplianceSummaryByResourceTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
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
            var request = new Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeRequest();
            
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
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
        
        private Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetComplianceSummaryByResourceType");
            try
            {
                return client.GetComplianceSummaryByResourceTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ResourceType { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse, GetCFGComplianceSummaryByResourceTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComplianceSummariesByResourceType;
        }
        
    }
}
