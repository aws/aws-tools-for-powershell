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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// The related resources of an Audit finding. The following resources can be returned
    /// from calling this API:
    /// 
    ///  <ul><li><para>
    /// DEVICE_CERTIFICATE
    /// </para></li><li><para>
    /// CA_CERTIFICATE
    /// </para></li><li><para>
    /// IOT_POLICY
    /// </para></li><li><para>
    /// COGNITO_IDENTITY_POOL
    /// </para></li><li><para>
    /// CLIENT_ID
    /// </para></li><li><para>
    /// ACCOUNT_SETTINGS
    /// </para></li><li><para>
    /// ROLE_ALIAS
    /// </para></li><li><para>
    /// IAM_ROLE
    /// </para></li><li><para>
    /// ISSUER_CERTIFICATE
    /// </para></li></ul><note><para>
    /// This API is similar to DescribeAuditFinding's <a href="https://docs.aws.amazon.com/iot/latest/apireference/API_DescribeAuditFinding.html">RelatedResources</a>
    /// but provides pagination and is not limited to 10 resources. When calling <a href="https://docs.aws.amazon.com/iot/latest/apireference/API_DescribeAuditFinding.html">DescribeAuditFinding</a>
    /// for the intermediate CA revoked for active device certificates check, RelatedResources
    /// will not be populated. You must use this API, ListRelatedResourcesForAuditFinding,
    /// to list the certificates.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "IOTRelatedResourcesForAuditFindingList")]
    [OutputType("Amazon.IoT.Model.RelatedResource")]
    [AWSCmdlet("Calls the AWS IoT ListRelatedResourcesForAuditFinding API operation.", Operation = new[] {"ListRelatedResourcesForAuditFinding"}, SelectReturnType = typeof(Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.RelatedResource or Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse",
        "This cmdlet returns a collection of Amazon.IoT.Model.RelatedResource objects.",
        "The service call response (type Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTRelatedResourcesForAuditFindingListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FindingId
        /// <summary>
        /// <para>
        /// <para>The finding Id.</para>
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
        public System.String FindingId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return at one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that can be used to retrieve the next set of results, or <c>null</c> if there
        /// are no additional results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RelatedResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RelatedResources";
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
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse, GetIOTRelatedResourcesForAuditFindingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FindingId = this.FindingId;
            #if MODULAR
            if (this.FindingId == null && ParameterWasBound(nameof(this.FindingId)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.IoT.Model.ListRelatedResourcesForAuditFindingRequest();
            
            if (cmdletContext.FindingId != null)
            {
                request.FindingId = cmdletContext.FindingId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ListRelatedResourcesForAuditFindingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ListRelatedResourcesForAuditFinding");
            try
            {
                return client.ListRelatedResourcesForAuditFindingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FindingId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IoT.Model.ListRelatedResourcesForAuditFindingResponse, GetIOTRelatedResourcesForAuditFindingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RelatedResources;
        }
        
    }
}
