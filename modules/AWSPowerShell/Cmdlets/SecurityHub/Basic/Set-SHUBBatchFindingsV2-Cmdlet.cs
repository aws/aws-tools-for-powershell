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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Used by customers to update information about their investigation into a finding.
    /// Requested by delegated administrator accounts or member accounts. Delegated administrator
    /// accounts can update findings for their account and their member accounts. Member accounts
    /// can update findings for their account. <c>BatchUpdateFindings</c> and <c>BatchUpdateFindingV2</c>
    /// both use <c>securityhub:BatchUpdateFindings</c> in the <c>Action</c> element of an
    /// IAM policy statement. You must have permission to perform the <c>securityhub:BatchUpdateFindings</c>
    /// action. Updates from <c>BatchUpdateFindingsV2</c> don't affect the value of f<c>inding_info.modified_time</c>,
    /// <c>finding_info.modified_time_dt</c>, <c>time</c>, <c>time_dt for a finding</c>.
    /// </summary>
    [Cmdlet("Set", "SHUBBatchFindingsV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response")]
    [AWSCmdlet("Calls the AWS Security Hub BatchUpdateFindingsV2 API operation.", Operation = new[] {"BatchUpdateFindingsV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response",
        "This cmdlet returns an Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response object containing multiple properties."
    )]
    public partial class SetSHUBBatchFindingsV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>The updated value for a user provided comment about the finding. Minimum character
        /// length 1. Maximum character length 512.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter FindingIdentifier
        /// <summary>
        /// <para>
        /// <para>Provides information to identify a specific V2 finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FindingIdentifiers")]
        public Amazon.SecurityHub.Model.OcsfFindingIdentifier[] FindingIdentifier { get; set; }
        #endregion
        
        #region Parameter MetadataUid
        /// <summary>
        /// <para>
        /// <para>The list of finding <c>metadata.uid</c> to indicate findings to update. Finding <c>metadata.uid</c>
        /// is a globally unique identifier associated with the finding. Customers cannot use
        /// <c>MetadataUids</c> together with <c>FindingIdentifiers</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataUids")]
        public System.String[] MetadataUid { get; set; }
        #endregion
        
        #region Parameter SeverityId
        /// <summary>
        /// <para>
        /// <para>The updated value for the normalized severity identifier. The severity ID is an integer
        /// with the allowed enum values [0, 1, 2, 3, 4, 5, 99]. When customer provides the updated
        /// severity ID, the string sibling severity will automatically be updated in the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SeverityId { get; set; }
        #endregion
        
        #region Parameter StatusId
        /// <summary>
        /// <para>
        /// <para>The updated value for the normalized status identifier. The status ID is an integer
        /// with the allowed enum values [0, 1, 2, 3, 4, 5, 6, 99]. When customer provides the
        /// updated status ID, the string sibling status will automatically be updated in the
        /// finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StatusId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SHUBBatchFindingsV2 (BatchUpdateFindingsV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response, SetSHUBBatchFindingsV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Comment = this.Comment;
            if (this.FindingIdentifier != null)
            {
                context.FindingIdentifier = new List<Amazon.SecurityHub.Model.OcsfFindingIdentifier>(this.FindingIdentifier);
            }
            if (this.MetadataUid != null)
            {
                context.MetadataUid = new List<System.String>(this.MetadataUid);
            }
            context.SeverityId = this.SeverityId;
            context.StatusId = this.StatusId;
            
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
            var request = new Amazon.SecurityHub.Model.BatchUpdateFindingsV2Request();
            
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.FindingIdentifier != null)
            {
                request.FindingIdentifiers = cmdletContext.FindingIdentifier;
            }
            if (cmdletContext.MetadataUid != null)
            {
                request.MetadataUids = cmdletContext.MetadataUid;
            }
            if (cmdletContext.SeverityId != null)
            {
                request.SeverityId = cmdletContext.SeverityId.Value;
            }
            if (cmdletContext.StatusId != null)
            {
                request.StatusId = cmdletContext.StatusId.Value;
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
        
        private Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchUpdateFindingsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchUpdateFindingsV2");
            try
            {
                #if DESKTOP
                return client.BatchUpdateFindingsV2(request);
                #elif CORECLR
                return client.BatchUpdateFindingsV2Async(request).GetAwaiter().GetResult();
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
            public System.String Comment { get; set; }
            public List<Amazon.SecurityHub.Model.OcsfFindingIdentifier> FindingIdentifier { get; set; }
            public List<System.String> MetadataUid { get; set; }
            public System.Int32? SeverityId { get; set; }
            public System.Int32? StatusId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.BatchUpdateFindingsV2Response, SetSHUBBatchFindingsV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
