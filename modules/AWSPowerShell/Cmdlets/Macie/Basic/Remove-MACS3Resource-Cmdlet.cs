/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Macie;
using Amazon.Macie.Model;

namespace Amazon.PowerShell.Cmdlets.MAC
{
    /// <summary>
    /// Removes specified S3 resources from being monitored by Amazon Macie Classic. If memberAccountId
    /// isn't specified, the action removes specified S3 resources from Macie Classic for
    /// the current Macie Classic administrator account. If memberAccountId is specified,
    /// the action removes specified S3 resources from Macie Classic for the specified member
    /// account.
    /// </summary>
    [Cmdlet("Remove", "MACS3Resource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Macie.Model.FailedS3Resource")]
    [AWSCmdlet("Calls the Amazon Macie DisassociateS3Resources API operation.", Operation = new[] {"DisassociateS3Resources"}, SelectReturnType = typeof(Amazon.Macie.Model.DisassociateS3ResourcesResponse))]
    [AWSCmdletOutput("Amazon.Macie.Model.FailedS3Resource or Amazon.Macie.Model.DisassociateS3ResourcesResponse",
        "This cmdlet returns a collection of Amazon.Macie.Model.FailedS3Resource objects.",
        "The service call response (type Amazon.Macie.Model.DisassociateS3ResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveMACS3ResourceCmdlet : AmazonMacieClientCmdlet, IExecutor
    {
        
        #region Parameter AssociatedS3Resource
        /// <summary>
        /// <para>
        /// <para>The S3 resources (buckets or prefixes) that you want to remove from being monitored
        /// and classified by Amazon Macie Classic. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AssociatedS3Resources")]
        public Amazon.Macie.Model.S3Resource[] AssociatedS3Resource { get; set; }
        #endregion
        
        #region Parameter MemberAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Macie Classic member account whose resources you want to remove
        /// from being monitored by Macie Classic. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemberAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedS3Resources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie.Model.DisassociateS3ResourcesResponse).
        /// Specifying the name of a property of type Amazon.Macie.Model.DisassociateS3ResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedS3Resources";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MemberAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MACS3Resource (DisassociateS3Resources)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie.Model.DisassociateS3ResourcesResponse, RemoveMACS3ResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociatedS3Resource != null)
            {
                context.AssociatedS3Resource = new List<Amazon.Macie.Model.S3Resource>(this.AssociatedS3Resource);
            }
            #if MODULAR
            if (this.AssociatedS3Resource == null && ParameterWasBound(nameof(this.AssociatedS3Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedS3Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemberAccountId = this.MemberAccountId;
            
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
            var request = new Amazon.Macie.Model.DisassociateS3ResourcesRequest();
            
            if (cmdletContext.AssociatedS3Resource != null)
            {
                request.AssociatedS3Resources = cmdletContext.AssociatedS3Resource;
            }
            if (cmdletContext.MemberAccountId != null)
            {
                request.MemberAccountId = cmdletContext.MemberAccountId;
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
        
        private Amazon.Macie.Model.DisassociateS3ResourcesResponse CallAWSServiceOperation(IAmazonMacie client, Amazon.Macie.Model.DisassociateS3ResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie", "DisassociateS3Resources");
            try
            {
                #if DESKTOP
                return client.DisassociateS3Resources(request);
                #elif CORECLR
                return client.DisassociateS3ResourcesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Macie.Model.S3Resource> AssociatedS3Resource { get; set; }
            public System.String MemberAccountId { get; set; }
            public System.Func<Amazon.Macie.Model.DisassociateS3ResourcesResponse, RemoveMACS3ResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedS3Resources;
        }
        
    }
}
