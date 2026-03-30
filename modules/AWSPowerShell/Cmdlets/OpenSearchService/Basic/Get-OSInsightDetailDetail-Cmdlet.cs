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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Describes the details of an existing insight for an Amazon OpenSearch Service domain.
    /// Returns detailed fields associated with the specified insight, such as text descriptions
    /// and metric data.
    /// </summary>
    [Cmdlet("Get", "OSInsightDetailDetail")]
    [OutputType("Amazon.OpenSearchService.Model.InsightField")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service DescribeInsightDetails API operation.", Operation = new[] {"DescribeInsightDetails"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.InsightField or Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse",
        "This cmdlet returns a collection of Amazon.OpenSearchService.Model.InsightField objects.",
        "The service call response (type Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOSInsightDetailDetailCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InsightId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the insight to describe.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InsightId { get; set; }
        #endregion
        
        #region Parameter ShowHtmlContent
        /// <summary>
        /// <para>
        /// <para>Specifies whether to show response with HTML content in response or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ShowHtmlContent { get; set; }
        #endregion
        
        #region Parameter Entity_Type
        /// <summary>
        /// <para>
        /// <para>The type of the entity. Possible values are <c>Account</c> and <c>DomainName</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpenSearchService.InsightEntityType")]
        public Amazon.OpenSearchService.InsightEntityType Entity_Type { get; set; }
        #endregion
        
        #region Parameter Entity_Value
        /// <summary>
        /// <para>
        /// <para>The value of the entity. For <c>DomainName</c>, this is the domain name. For <c>Account</c>,
        /// this is the Amazon Web Services account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Entity_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Fields'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Fields";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse, GetOSInsightDetailDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Entity_Type = this.Entity_Type;
            #if MODULAR
            if (this.Entity_Type == null && ParameterWasBound(nameof(this.Entity_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Entity_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Entity_Value = this.Entity_Value;
            context.InsightId = this.InsightId;
            #if MODULAR
            if (this.InsightId == null && ParameterWasBound(nameof(this.InsightId)))
            {
                WriteWarning("You are passing $null as a value for parameter InsightId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShowHtmlContent = this.ShowHtmlContent;
            
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
            var request = new Amazon.OpenSearchService.Model.DescribeInsightDetailsRequest();
            
            
             // populate Entity
            var requestEntityIsNull = true;
            request.Entity = new Amazon.OpenSearchService.Model.InsightEntity();
            Amazon.OpenSearchService.InsightEntityType requestEntity_entity_Type = null;
            if (cmdletContext.Entity_Type != null)
            {
                requestEntity_entity_Type = cmdletContext.Entity_Type;
            }
            if (requestEntity_entity_Type != null)
            {
                request.Entity.Type = requestEntity_entity_Type;
                requestEntityIsNull = false;
            }
            System.String requestEntity_entity_Value = null;
            if (cmdletContext.Entity_Value != null)
            {
                requestEntity_entity_Value = cmdletContext.Entity_Value;
            }
            if (requestEntity_entity_Value != null)
            {
                request.Entity.Value = requestEntity_entity_Value;
                requestEntityIsNull = false;
            }
             // determine if request.Entity should be set to null
            if (requestEntityIsNull)
            {
                request.Entity = null;
            }
            if (cmdletContext.InsightId != null)
            {
                request.InsightId = cmdletContext.InsightId;
            }
            if (cmdletContext.ShowHtmlContent != null)
            {
                request.ShowHtmlContent = cmdletContext.ShowHtmlContent.Value;
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
        
        private Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.DescribeInsightDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "DescribeInsightDetails");
            try
            {
                return client.DescribeInsightDetailsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.OpenSearchService.InsightEntityType Entity_Type { get; set; }
            public System.String Entity_Value { get; set; }
            public System.String InsightId { get; set; }
            public System.Boolean? ShowHtmlContent { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.DescribeInsightDetailsResponse, GetOSInsightDetailDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Fields;
        }
        
    }
}
